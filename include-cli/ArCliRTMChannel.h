#pragma once
#include "../ARtmKit/IArRtmService.h"
#include "ArCliRTMTypes.h"
#include "ArCliRTMChannelEventHandler.h"

using namespace ar::rtm;
using namespace System;
using namespace System::Runtime::InteropServices;
using namespace System::Collections::Generic;

namespace ArCliLibrary {
	public ref class ArCliRTMChannel
	{
	public:
		ArCliRTMChannel(IRtmService* service, String^ id);
		~ArCliRTMChannel();

		int Join();
		int Leave();
		int SendMessage(ClrMessage^ msg);
		int SendMessage(ClrMessage^ msg,ClrSendMessageOptions^ options );
		void Release();
		property String^ Id { String^ get() { return id; }}
		int getMembers();

		AT<>::Type^ onJoinSuccess;
		AT<EnumJoinChannelErrCode>::Type^ onJoinFailure;
		AT<EnumLeaveChannelErrCode>::Type^ onLeave;
		AT<String^, ClrMessage^>::Type^ onMessageReceived;
		AT<long long, EnumChannelMessageErrCode>::Type^ onSendMessageResult;
		AT<ClrChannelMember^>::Type^ onMemberJoined;
		AT<ClrChannelMember^>::Type^ onMemberLeft;
		AT<List<ClrChannelMember^>^, EnumGetMembersErrCode>::Type^ onGetMembers;
		AT<List<ClrRtmChannelAttribute^>^>::Type^ onAttributesUpdated;
		AT<int>::Type^ onMemberCountUpdated;

		AT<String^,ClrFileMessage^>::Type^ onFileMessageReceived;
		AT<String^,ClrImageMessage^>::Type^ onImageMessageReceived;

	private:
		String^ id;
		IRtmService* service;
		IChannel* channel;
		ArCliRTMChannelEventHandler* events;
		List<GCHandle>^ gchs;

		void NativeOnJoinSuccess();
		void NativeOnJoinFailure(JOIN_CHANNEL_ERR code);
		void NativeOnLeave(LEAVE_CHANNEL_ERR code);
		void NativeOnMessageReceived(const char* userId, const IMessage* msg);
		void NativeOnSendMessageResult(long long id, CHANNEL_MESSAGE_ERR_CODE code);
		void NativeOnMemberJoined(IChannelMember* member);
		void NativeOnMemberLeft(IChannelMember* member);
		void NativeOnGetMembers(IChannelMember** members, int count, GET_MEMBERS_ERR code);
		void NativeOnAttributesUpdated(const IRtmChannelAttribute* attrs[], int count);
		void NativeOnMemberCountUpdated(int count);

		//1.3版本新增 文件+图片消息 （最大30M，服务器最多放七天）
		void NativeOnFileMessageReceived(const char * userId, const IFileMessage*  message);
		void NativeOnImageMessageReceived(const char * userId, const IImageMessage*  message);

	private:
		template<typename E, typename D>
		inline void regEvent(E& e, D^ d)
		{
			gchs->Add(GCHandle::Alloc(d));
			e = reinterpret_cast<E>(Marshal::GetFunctionPointerForDelegate(d).ToPointer());
		}

		void bindEvents();
	};

}

