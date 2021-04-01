#include "pch.h"
#include "ArCliRTMChannel.h"
#include "ArCliRTMChannelEventHandler.h"

#include <msclr/marshal_cppstd.h>
#include <string>
using namespace Collections::Generic;
using namespace msclr::interop;
using namespace ArCliLibrary;

ArCliRTMChannel::ArCliRTMChannel(IRtmService* service, String^ id)
{
	this->events = new ArCliRTMChannelEventHandler();
	IChannel* channel = service->createChannel(marshal_as<std::string>(id).c_str(), this->events);
	if (channel == nullptr) {
		delete events;
		throw gcnew System::ArgumentNullException();
	}

	this->channel = channel;
	this->id = gcnew String(id);
	this->gchs = gcnew List<GCHandle>;
	this->service = service;
	
	bindEvents();
}

ArCliRTMChannel::~ArCliRTMChannel()
{
	this->service = nullptr;
	for each (GCHandle handler in this->gchs)
	{
		handler.Free();
	}
	delete events;
	this->channel->release();
}

int ArCliRTMChannel::Join()
{
	return channel->join();
}

int ArCliRTMChannel::Leave()
{
	return channel->leave();
}

void ArCliRTMChannel::Release()
{
	channel ->release();
}

int ArCliRTMChannel::SendMessage(ClrMessage^ msg)
{
	IMessage* raw = msg->toMessage(service);
	SendMessageOptions options;
	options.enableHistoricalMessaging=false;
	options.enableOfflineMessaging = false;
	const int result = channel->sendMessage(raw,options);
	raw->release();
	return result;
}

int ArCliRTMChannel::SendMessage(ClrMessage^ msg, ClrSendMessageOptions^ options)
{
	IMessage* raw = msg->toMessage(service);
	int result = channel->sendMessage(raw,options);
	raw->release();
	return result;
}

int ArCliRTMChannel::getMembers()
{
	return channel->getMembers();
}

void ArCliRTMChannel::NativeOnJoinSuccess()
{
	if (onJoinSuccess) onJoinSuccess();
}

void ArCliRTMChannel::NativeOnJoinFailure(JOIN_CHANNEL_ERR code)
{
	if (onJoinFailure) onJoinFailure(static_cast<EnumJoinChannelErrCode>(code));
}

void ArCliRTMChannel::NativeOnLeave(LEAVE_CHANNEL_ERR code)
{
	if (onLeave) onLeave(static_cast<EnumLeaveChannelErrCode>(code));
}

void ArCliRTMChannel::NativeOnMessageReceived(const char* userId, const IMessage* msg)
{
	if (onMessageReceived)
		onMessageReceived(gcnew String(userId), gcnew ClrMessage(const_cast<IMessage*>(msg)));
}

void ArCliRTMChannel::NativeOnSendMessageResult(long long id, CHANNEL_MESSAGE_ERR_CODE code)
{
	if (onSendMessageResult)
		onSendMessageResult(id, static_cast<EnumChannelMessageErrCode>(code));
}

void ArCliRTMChannel::NativeOnMemberJoined(IChannelMember* member)
{
	if (onMemberJoined) onMemberJoined(gcnew ClrChannelMember(member));
}

void ArCliRTMChannel::NativeOnMemberLeft(IChannelMember* member)
{
	if (onMemberLeft) onMemberLeft(gcnew ClrChannelMember(member));
}

void ArCliRTMChannel::NativeOnGetMembers(IChannelMember** members, int count, GET_MEMBERS_ERR code)
{
	if (onGetMembers) {
		List<ClrChannelMember^>^ list = gcnew List<ClrChannelMember^>;
		for (int i = 0; i < count; i++)
			list->Add(gcnew ClrChannelMember(members[i]));
		onGetMembers(list, static_cast<EnumGetMembersErrCode>(code));
	}
}

void ArCliRTMChannel::NativeOnAttributesUpdated(const IRtmChannelAttribute* attrs[], int count)
{
	if (onAttributesUpdated) {
		List<ClrRtmChannelAttribute^>^ list = gcnew List<ClrRtmChannelAttribute^>;
		for (int i = 0; i < count; i++)
			list->Add(gcnew ClrRtmChannelAttribute(attrs[i]));
		onAttributesUpdated(list);
	}
}

void ArCliRTMChannel::NativeOnMemberCountUpdated(int count)
{
	if (onMemberCountUpdated) onMemberCountUpdated(count);
}

void ArCliRTMChannel::NativeOnFileMessageReceived(const char* userId, const IFileMessage* message)
{
	if (onFileMessageReceived)
		onFileMessageReceived(gcnew String(userId), gcnew ClrFileMessage(const_cast<IFileMessage*>(message)));
}

void ArCliRTMChannel::NativeOnImageMessageReceived(const char* userId, const IImageMessage* message)
{
	if (onImageMessageReceived)
		onImageMessageReceived(gcnew String(userId), gcnew ClrImageMessage(const_cast<IImageMessage*>(message)));
}

void ArCliRTMChannel::bindEvents()
{
	regEvent(events->onJoinSuccessEvent, gcnew OnJoinSuccessType::Type(this, &ArCliRTMChannel::NativeOnJoinSuccess));
	regEvent(events->onJoinFailureEvent, gcnew OnJoinFailureType::Type(this, &ArCliRTMChannel::NativeOnJoinFailure));
	regEvent(events->onLeaveEvent, gcnew OnLeaveType::Type(this, &ArCliRTMChannel::NativeOnLeave));
	regEvent(events->onMessageReceivedEvent, gcnew OnMessageReceivedType::Type(this, &ArCliRTMChannel::NativeOnMessageReceived));
	regEvent(events->onSendMessageResultEvent, gcnew OnSendMessageResultType::Type(this, &ArCliRTMChannel::NativeOnSendMessageResult));
	regEvent(events->onMemberJoinedEvent, gcnew OnMemberJoinedType::Type(this, &ArCliRTMChannel::NativeOnMemberJoined));
	regEvent(events->onMemberLeftEvent, gcnew OnMemberLeftType::Type(this, &ArCliRTMChannel::NativeOnMemberLeft));
	regEvent(events->onGetMembersEvent, gcnew OnGetMembersType::Type(this, &ArCliRTMChannel::NativeOnGetMembers));
	regEvent(events->onAttributesUpdatedEvent, gcnew OnAttributesUpdatedType::Type(this, &ArCliRTMChannel::NativeOnAttributesUpdated));

	regEvent(events->onFileMessageReceivedEvent, gcnew OnFileMessageReceivedType::Type(this, &ArCliRTMChannel::NativeOnFileMessageReceived));
	regEvent(events->onImageMessageReceivedEvent, gcnew OnImageMessageReceivedType::Type(this, &ArCliRTMChannel::NativeOnImageMessageReceived));

}
