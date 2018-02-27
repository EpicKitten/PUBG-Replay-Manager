using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PUBG_Replay_Manager
{
    public partial class Timeline : Form
    {
        public Timeline(string directory_of_recording)
        {
            InitializeComponent();
            Replay replay = new Replay(directory_of_recording);
            
            Font old_font = timelineRTB.Font;
            timelineRTB.AppendText("|----------------------------------------------------------------------------------------------------------------------|", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("| These kills and downs are from the groggy and kill files and isn't complete! |", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("| These kills and downs all happened within 1km of the recording player.      |", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("|                                   YOU HAVE BEEN WARNED                                     |", Color.Red);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText("|----------------------------------------------------------------------------------------------------------------------|", Color.White);
            timelineRTB.AppendText(Environment.NewLine);
            timelineRTB.AppendText(Environment.NewLine);
            
            foreach (IReplayEvent item in replay.Events())
            {
                switch (item.GetType().Name)
                {
                    case "ReplayKnockEvent":
                        timelineRTB.AppendText(item.ToString(), Color.Orange);
                        break;
                    
                    case "ReplayKillEvent":
                        timelineRTB.AppendText(item.ToString(), Color.Red);
                        break;
                    
                    default:
                        timelineRTB.AppendText(item.ToString());
                        break;
                }
                
                timelineRTB.AppendText(Environment.NewLine);
            }
            timelineRTB.SelectionStart = 0;
            timelineRTB.SelectionLength = 0;
            timelineRTB.ScrollToCaret();
            //timelineRTB.Font = Font.Size
            //timelineRTB.Res
        }
    }
    public static class RichTextBoxExtensions
    {
        public static void AppendText(this RichTextBox box, string text, Color color)
        {
            box.SelectionStart = box.TextLength;
            box.SelectionLength = 0;

            box.SelectionColor = color;
            box.AppendText(text);
            box.SelectionColor = box.ForeColor;
        }
    }
}
