using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ArCliLibrary;


namespace ArCliDemo
{
    public partial class Form1 : Form
    {
        private ArCliRTM artcRTM = new ArCliRTM();
        private System.Timers.Timer m_timer;
        private bool m_start;

        public Form1()
        {
            InitializeComponent();
            artcRTM.onLoginSuccess = onLoginSuccess;
            artcRTM.onLoginFailure = onLoginFailure;
        }

      
        private void onLoginSuccess()
        {
            log("Join rtm success", 0);
        }

        private void onLoginFailure(EnumLoginErrCode code)
        {
            log("Join rtm failed", 0);
        }

        private void onCameraReady()
        {
            log("Camera Ready Event", 0);
        }

        private void onJoinChannelSuccess(String channel, String uid, int elapsed)
        {
            log("join channel success in " + channel + " by " + uid, elapsed);
            m_start = true;
        }

        delegate void LogDelegate(String operation, int result);

        private void log(String operation, int result)
        {
            if (txtResult.InvokeRequired)
            {
                LogDelegate d = new LogDelegate(log);
                this.Invoke(d, new object[] { operation, result });
            } else
            {
                txtResult.AppendText(String.Format("rtm {0} result is {1}", operation, result));
                txtResult.AppendText(Environment.NewLine);
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtResult_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnStartPreview_Click(object sender, EventArgs e)
        {
            m_timer = new System.Timers.Timer(10);
            m_timer.Elapsed += pullAudioFrameTimer;
            m_timer.Enabled = true;
        }

        private void pullAudioFrameTimer(object sender, System.Timers.ElapsedEventArgs e)
        {
            if (!m_start) return;

        }

        private void btnJoinChannel_Click(object sender, EventArgs e)
        {
            log("initialize", artcRTM.initialize(txtVendorkey.Text));
            log("join channel", artcRTM.login(txtToken.Text, txtUserId.Text));
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            //log(" convert -1 to unit result is " + Convert.ToUInt32(-1), 0);
            //log("start audio recording", artc.startAudioRecording("recording.mp4", AudioRecordingQualityType.AUDIO_RECORDING_QUALITY_HIGH));
            artcRTM.logout();
        }
    }
}
