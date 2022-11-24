using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Serialization;
using DTO;

namespace QTNPP_PEPSI
{
    public partial class FormLapLich : Form
    {
        #region

        private List<List<Button>> matran;
        private PlanData job;
        private int appTime;

        private string filePath = "data.xml";

        public List<List<Button>> Matran { get => matran; set => matran = value; }
        public PlanData Job { get => job; set => job = value; }
        public int AppTime { get => appTime; set => appTime = value; }

        private List<string> dateOfWeek = new List<string>() { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };

        #endregion

        public FormLapLich()
        {
            InitializeComponent();
            LoadMaTran();

            tmNotify.Start();
            appTime = 0;
        
        }

        void LoadMaTran()
        {
            Matran = new List<List<Button>>();

            Button oldbtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, 0) };
            for (int i = 0; i < Cons.DayOfColumn; i++)
            {
                Matran.Add(new List<Button>());

                for (int j = 0; j < Cons.DayOfWeek; j++)
                {
                    Button btn = new Button() { Width = Cons.dateButtonWidth, Height = Cons.dateButtonHeight };
                    btn.Location = new Point(oldbtn.Location.X + oldbtn.Width + Cons.margin, oldbtn.Location.Y);


                    pnlMaTran.Controls.Add(btn);
                    Matran[i].Add(btn);

                    oldbtn = btn;
                }
                oldbtn = new Button() { Width = 0, Height = 0, Location = new Point(-Cons.margin, oldbtn.Location.Y + Cons.dateButtonHeight) };
            }
        }

    }
}
