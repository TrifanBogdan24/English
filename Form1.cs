using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.Office.Interop.Word; // Need to add a reference to the Microsoft Word Object Library
using System.IO;
using System.Xml.Serialization;

namespace English
{
    public partial class Form1 : Form
    {
        string q;
        int poz, nr;
        int ce_fac, timp;
        string funct;
        int whichenter;
        int nr_eror = 0;
        int sound = 1;
        string input = "";
        int nr_loop_shutting_down = 3;
        private int counting_down_shutting_down = 250; //o secunda = 60
        bool merge_cronometrul_shutting_down = false;
        bool merge_cronometrul_loading = false;
        string URL_click = "C:/Users/trifa/OneDrive/Documente/English/sunet/mettalic_gear_sounds.mp3";  // daca locatia fisierului se modifica, trebuie actualizata AICI !!
        string URL_background_song = "C:/Users/trifa/OneDrive/Documente/English/sunet/the sound of 20s-30s.mp3";  // daca locatia fisierului se modifica, trebuie actualizata AICI !!
        string URL_start_up = "C:/Users/trifa/OneDrive/Documente/English/sunet/welcome.mp3"; // daca locatia fisierului se modifica, trebuie actualizata AICI !!
        string URL_shut_down = "C:/Users/trifa/OneDrive/Documente/English/sunet/bye.mp3"; // daca locatia fisierului se modifica, trebuie actualizata AICI !!
        int loading = 0;


        WMPLib.WindowsMediaPlayer MediaPlayer1 = new WMPLib.WindowsMediaPlayer();  // melodie classy de fundal
        WMPLib.WindowsMediaPlayer MediaPlayer2 = new WMPLib.WindowsMediaPlayer();  // pentru sunetul ala enervant de click ;)
        

        //510*395
        // blue(rgb) : 57, 68, 122
        // red(rgb) : 233, 74, 95 

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.StartPosition = FormStartPosition.CenterScreen;

            MediaPlayer1.URL = URL_start_up; MediaPlayer1.settings.setMode("loop", false); MediaPlayer1.controls.play();
            sound1.BackgroundImage = sound2.BackgroundImage = sound3.BackgroundImage = sound4.BackgroundImage = Properties.Resources.soundon;
            home1.BackgroundImage = home2.BackgroundImage = home3.BackgroundImage = home4.BackgroundImage = Properties.Resources.homebutton1;

            exit1.BackgroundImage = exit2.BackgroundImage = exit3.BackgroundImage = exit4.BackgroundImage = Properties.Resources.exit1;

            shutdown.Cursor = next.Cursor = previous.Cursor = trash.Cursor = download.Cursor = exit4.Cursor = home4.Cursor = sound4.Cursor = sound1.Cursor = sound2.Cursor = sound3.Cursor = home1.Cursor = home2.Cursor = home3.Cursor = exit1.Cursor = exit2.Cursor = exit3.Cursor = logo1.Cursor = logo2.Cursor = logo3.Cursor = logo4.Cursor = logo5.Cursor = logo6.Cursor = logo7.Cursor = logo8.Cursor = logo9.Cursor = file1.Cursor = file2.Cursor = file3.Cursor = file4.Cursor = file5.Cursor = file6.Cursor = file7.Cursor = file8.Cursor = file9.Cursor = file10.Cursor = file11.Cursor = file12.Cursor = file_path1.Cursor = file_path2.Cursor = file_path3.Cursor = file_path4.Cursor = file_path5.Cursor = file_path6.Cursor = file_path8.Cursor = file_path9.Cursor = file_path10.Cursor = file_path11.Cursor = file_path12.Cursor = Cursors.Hand;

            file_path1.Text = "Vocabulary";
            file_path2.Text = "Grammar";
            file_path3.Text = "Writing";
            sound4.Visible = text_ora.Visible = text_2pct.Visible = text_minut.Visible = file1.Visible=file2.Visible=file3.Visible=file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible= file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
            file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1;
            file_path1.Font = file_path2.Font = file_path3.Font = file_path4.Font = file_path5.Font = file_path6.Font = file_path7.Font = file_path8.Font = file_path9.Font = file_path10.Font = file_path11.Font = file_path12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            panel_theory.BackgroundImage = Properties.Resources.backgroundpc;
            message.BackColor = Color.Gray; message.ForeColor = Color.White; message.Visible = trash.Visible = download.Visible = false;
            bootloader.Font = new System.Drawing.Font("Snap ITC", 30); bootloader.BackColor = Color.Transparent; bootloader.Visible = loading_one.Visible = false;
            loading_one.BackColor = bootloader.ForeColor = Color.FromArgb(57, 68, 122);
            // pentru ilustratii 560*600
            //poz = 1;

            paper_sheet.Height = 390; // valoare trebuie sa fie ajustata in functie de ecran

            ilm.Visible = false;
            previous.BackgroundImage = Properties.Resources.prev;
            next.BackgroundImage = Properties.Resources.next;
            loading_one.Width = 20;

            
            MediaPlayer2.settings.setMode("loop", false);

            logo1.BackgroundImage = Properties.Resources.naturelogo1;
            logo2.BackgroundImage = Properties.Resources.animalslogo1;
            logo3.BackgroundImage = Properties.Resources.bodylogo1;
            logo4.BackgroundImage = Properties.Resources.healthlogo1;
            logo5.BackgroundImage = Properties.Resources.householdlogo1;
            logo6.BackgroundImage = Properties.Resources.foodlogo1;
            logo7.BackgroundImage = Properties.Resources.citylogo1;
            logo8.BackgroundImage = Properties.Resources.travellogo1;
            logo9.BackgroundImage = Properties.Resources.otherlogo1;
            shutdown.BackgroundImage = Properties.Resources.power1;
            trash.BackgroundImage = Properties.Resources.bin_one;
            download.BackgroundImage = Properties.Resources.download;


            exit1.MouseEnter += exit1_MouseEnter; exit1.MouseLeave += exit1_MouseLeave;
            exit2.MouseEnter += exit1_MouseEnter; exit2.MouseLeave += exit1_MouseLeave;
            exit3.MouseEnter += exit1_MouseEnter; exit3.MouseLeave += exit1_MouseLeave;
            exit4.MouseEnter += exit1_MouseEnter; exit4.MouseLeave += exit1_MouseLeave;

            home1.MouseEnter += home1_MouseEnter; home1.MouseLeave += home1_MouseLeave;
            home2.MouseEnter += home1_MouseEnter; home2.MouseLeave += home1_MouseLeave;
            home3.MouseEnter += home1_MouseEnter; home3.MouseLeave += home1_MouseLeave;
            home4.MouseEnter += home1_MouseEnter; home4.MouseLeave += home1_MouseLeave;

            logo1.MouseEnter += logo1_MouseEnter; logo1.MouseLeave += logo1_MouseLeave;
            logo2.MouseEnter += logo2_MouseEnter; logo2.MouseLeave += logo2_MouseLeave;
            logo3.MouseEnter += logo3_MouseEnter; logo3.MouseLeave += logo3_MouseLeave;
            logo4.MouseEnter += logo4_MouseEnter; logo4.MouseLeave += logo4_MouseLeave;
            logo5.MouseEnter += logo5_MouseEnter; logo5.MouseLeave += logo5_MouseLeave;
            logo6.MouseEnter += logo6_MouseEnter; logo6.MouseLeave += logo6_MouseLeave;
            logo7.MouseEnter += logo7_MouseEnter; logo7.MouseLeave += logo7_MouseLeave;
            logo8.MouseEnter += logo8_MouseEnter; logo8.MouseLeave += logo8_MouseLeave;
            logo9.MouseEnter += logo9_MouseEnter; logo9.MouseLeave += logo9_MouseLeave;
            trash.MouseEnter += trash_MouseEnter; trash.MouseLeave += trash_MouseLeave;
            shutdown.MouseEnter += shutdown_MouseEnter; shutdown.MouseLeave += shutdown_MouseLeave;
            file1.MouseEnter += file1_MouseEnter; file1.MouseLeave += file1_MouseLeave; file_path1.MouseEnter += file1_MouseEnter; file_path1.MouseLeave += file1_MouseLeave;
            file2.MouseEnter += file2_MouseEnter; file2.MouseLeave += file2_MouseLeave; file_path2.MouseEnter += file2_MouseEnter; file_path2.MouseLeave += file2_MouseLeave;
            file3.MouseEnter += file3_MouseEnter; file3.MouseLeave += file3_MouseLeave; file_path3.MouseEnter += file3_MouseEnter; file_path3.MouseLeave += file3_MouseLeave;
            file4.MouseEnter += file4_MouseEnter; file4.MouseLeave += file4_MouseLeave; file_path4.MouseEnter += file4_MouseEnter; file_path4.MouseLeave += file4_MouseLeave;
            file5.MouseEnter += file5_MouseEnter; file5.MouseLeave += file5_MouseLeave; file_path5.MouseEnter += file5_MouseEnter; file_path5.MouseLeave += file5_MouseLeave;
            file6.MouseEnter += file6_MouseEnter; file6.MouseLeave += file6_MouseLeave; file_path6.MouseEnter += file6_MouseEnter; file_path6.MouseLeave += file6_MouseLeave;
            file7.MouseEnter += file7_MouseEnter; file7.MouseLeave += file7_MouseLeave; file_path7.MouseEnter += file7_MouseEnter; file_path7.MouseLeave += file7_MouseLeave;
            file8.MouseEnter += file8_MouseEnter; file8.MouseLeave += file8_MouseLeave; file_path8.MouseEnter += file8_MouseEnter; file_path8.MouseLeave += file8_MouseLeave;
            file9.MouseEnter += file9_MouseEnter; file9.MouseLeave += file9_MouseLeave; file_path9.MouseEnter += file9_MouseEnter; file_path9.MouseLeave += file9_MouseLeave;
            file10.MouseEnter += file10_MouseEnter; file10.MouseLeave += file10_MouseLeave; file_path10.MouseEnter += file10_MouseEnter; file_path10.MouseLeave += file10_MouseLeave;
            file11.MouseEnter += file11_MouseEnter; file11.MouseLeave += file11_MouseLeave; file_path11.MouseEnter += file11_MouseEnter; file_path11.MouseLeave += file11_MouseLeave;
            file12.MouseEnter += file12_MouseEnter; file12.MouseLeave += file12_MouseLeave; file_path12.MouseEnter += file12_MouseEnter; file_path12.MouseLeave += file12_MouseLeave;


            label1.Visible = label2.Visible = task.Visible = paper_sheet.Visible = pathern.Visible = false;
            home4.Visible = exit4.Visible = false;

            panel_vocabulary.BackgroundImage = Properties.Resources.backimage1;
            panel_grammar.BackgroundImage = Properties.Resources.backimagine2;
            
            
            merge_cronometrul_loading = loading_one.Visible= bootloader.Visible= true;
            percentage.BackColor = Color.Transparent; percentage.Font = new System.Drawing.Font("Stencil", 20); percentage.ForeColor = Color.FromArgb(57, 68, 122);  percentage.Text = "0%"; bootloader.Text = "Loading";
            // animatie slide-uri ca de ppt:
            timer_slide = new System.Windows.Forms.Timer();
            timer_slide.Interval = 1;
            timer_slide.Tick += new EventHandler(timer_slide_Tick);
            timer_slide.Enabled = true;

            //ceas
            timer_ceas = new System.Windows.Forms.Timer();
            timer_ceas.Interval = 1;
            timer_slide.Tick += new EventHandler(timer_ceas_Tick);
            timer_ceas.Enabled = true;
            text_ora.Font = text_2pct.Font = text_minut.Font = new System.Drawing.Font("Stencil", 20);
            text_ora.AutoSize = text_2pct.AutoSize = text_minut.AutoSize = true;
            text_ora.BackColor = text_2pct.BackColor = text_minut.BackColor = Color.FromArgb(0, 0, 0, 0);
            text_ora.ForeColor = text_2pct.ForeColor = text_minut.ForeColor = Color.FromArgb(57, 68, 122);


            Cursor.Hide();


            cb1.Items.Add("Nature");
            cb1.Items.Add("Animals");
            cb1.Items.Add("Body");
            cb1.Items.Add("Health");
            cb1.Items.Add("Household");
            cb1.Items.Add("Food");
            cb1.Items.Add("City");
            cb1.Items.Add("Travel");
            cb1.Items.Add("Other");
            poz = 1; q = "basic words";
            navigare();



        }


        private void next_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            if (q == "basic words")
            {
                if (poz != 28) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "verbs")
            {
                if (poz != 9) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "idioms")
            {
                if (poz != 20) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "nouns")
            {
                if (poz != 5) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "pronouns")
            {
                if (poz != 1) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            } else if (q == "adverbs")
            {
                if (poz != 3) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            } else if (q == "essay")
            {
                if (poz != 3) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "review")
            {
                if (poz != 3) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "report")
            {
                if (poz != 2) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "proposal")
            {
                if (poz != 2) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "formal letter")
            {
                if (poz != 6) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }
            else if (q == "informal letter")
            {
                if (poz != 3) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            } else if (q == "Phrasal verbs")
            {
                if (poz != 27) { poz++; funct = "next"; ilslide.Left = 0; navigare(); }
            }



        }



        private void previous_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            if (poz != 1) { poz--; funct = "previous"; ilslide.Left = 0; navigare(); }

        }


        void eror()
        {
            pathern.Visible = true;
            nr_eror++;
            if (nr_eror == 1) pathern.BackgroundImage = Properties.Resources.eror1;
            else if (nr_eror == 2) pathern.BackgroundImage = Properties.Resources.eror2;
            else if (nr_eror == 3) pathern.BackgroundImage = Properties.Resources.eror3;
            else if (nr_eror == 4) { pathern.BackgroundImage = Properties.Resources.eror4; nr_eror = 0; }


        }

        void back_to_home()
        {
            file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
            home4.Visible = exit4.Visible = paper_sheet.Visible = pathern.Visible = label1.Visible = label2.Visible = task.Visible = trash.Visible = download.Visible = false;
            file1.Visible = file2.Visible = file3.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = true;
            file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1;
            file_path1.Text = "Vocabulary";
            file_path2.Text = "Grammar";
            file_path3.Text = "Writing";
            panel_theory.Visible = true;
        }


        void sounding()
        {
            sound = 1 - sound;
            if (sound == 0)
            {
                // fara sunet
                MediaPlayer1.controls.pause();
                sound1.BackgroundImage = sound2.BackgroundImage = sound3.BackgroundImage = sound4.BackgroundImage = Properties.Resources.soundoff;
            } else
            {
                //cu sunet
                MediaPlayer1.controls.play();
                sound1.BackgroundImage = sound2.BackgroundImage = sound3.BackgroundImage = sound4.BackgroundImage = Properties.Resources.soundon;
            }
        }
        void search()
        {

            trash.Visible = download.Visible = false;

            if (input == "Add essay") Properties.Settings.Default.nr_essays++;
            else if (input == "Add review") Properties.Settings.Default.nr_reviews++;
            else if (input == "Add report") Properties.Settings.Default.nr_reports++;
            else if (input == "Add proposal") Properties.Settings.Default.nr_proposals++;
            else if (input == "Add formal letter") Properties.Settings.Default.nr_formal_letters++;
            else if (input == "Add informal letter") Properties.Settings.Default.nr_informal_letters++;


            if (input == "Vocabulary")
            {
                panel_grammar.Visible = panel_theory.Visible = false;
                panel_vocabulary.Visible = true;
            }
            else if (input == "Grammar")
            {
                panel_theory.Visible = false;
                panel_grammar.Visible = panel_vocabulary.Visible = true;
            }
            else if (input == "Writing")
            {
                home4.Visible = exit4.Visible = true;
                whichenter = 2;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;
                file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = file12.BackgroundImage = Properties.Resources.file_storage1;
                file_path1.Text = "Essay";
                file_path2.Text = "Report";
                file_path3.Text = "Review";
                file_path4.Text = "Proposal";
                file_path5.Text = "Formal letter";
                file_path6.Text = "Informal letter";

                file_path7.Text = "Your essays";
                file_path8.Text = "Your reports";
                file_path9.Text = "Your reviews";
                file_path10.Text = "Your proposals";
                file_path11.Text = "Your formal letters";
                file_path12.Text = "Your informal letters";

            }
            else if (input == "Essay")
            {
                panel_grammar.Visible = panel_theory.Visible = panel_vocabulary.Visible = false;
                q = "essay"; poz = 1; navigare();

            }
            else if (input == "Report")
            {
                panel_grammar.Visible = panel_theory.Visible = panel_vocabulary.Visible = false;
                q = "report"; poz = 1; navigare();
            }
            else if (input == "Review")
            {
                panel_grammar.Visible = panel_theory.Visible = panel_vocabulary.Visible = false;
                q = "review"; poz = 1; navigare();
            }
            else if (input == "Proposal")
            {
                panel_grammar.Visible = panel_theory.Visible = panel_vocabulary.Visible = false;
                q = "proposal"; poz = 1; navigare();
            }
            else if (input == "Formal letter")
            {
                panel_grammar.Visible = panel_theory.Visible = panel_vocabulary.Visible = false;
                q = "formal letter"; poz = 1; navigare();
            }
            else if (input == "Informal letter")
            {
                panel_grammar.Visible = panel_theory.Visible = panel_vocabulary.Visible = false;
                q = "informal letter"; poz = 1; navigare();
            } else if (input == "Your essays")
            {
                whichenter = 1;
                trash.Visible = download.Visible = true; message.Text = "Delete all essays";


                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;
                if (Properties.Settings.Default.nr_essays == 0)
                {
                    trash.Visible = download.Visible = false;
                    file_path1.Text = "Add essay";
                    file1.BackgroundImage = Properties.Resources.plus;
                    file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_essays == 1)
                {
                    file1.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "essay 1";
                    file_path2.Text = "Add essay"; file2.BackgroundImage = Properties.Resources.plus;
                    file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_essays == 2)
                {
                    file1.BackgroundImage = file2.BackgroundImage = Properties.Resources.file_storage1; file3.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "Add essay";
                    file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_essays == 3)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1; file4.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "Add essay";
                    file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_essays == 4)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = Properties.Resources.file_storage1; file5.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "Add essay";
                    file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_essays == 5)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = Properties.Resources.file_storage1; file6.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "Add essay";
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_essays == 6)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = Properties.Resources.file_storage1; file7.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "essay 6"; file_path7.Text = "Add essay";
                    file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_essays == 7)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = Properties.Resources.file_storage1; file8.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "essay 6"; file_path7.Text = "essay 7"; file_path8.Text = "Add essay";

                    file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_essays == 8)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = Properties.Resources.file_storage1; file9.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "essay 6"; file_path7.Text = "essay 7"; file_path8.Text = "essay 8"; file_path9.Text = "Add essay";

                    file10.Visible = file11.Visible = file12.Visible = false;
                    file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_essays == 9)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = Properties.Resources.file_storage1; file10.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "essay 6"; file_path7.Text = "essay 7"; file_path8.Text = "essay 8"; file_path9.Text = "essay 9"; file_path10.Text = "Add essay";
                    file11.Visible = file12.Visible = false;
                    file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_essays == 10)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = Properties.Resources.file_storage1; file11.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "essay6"; file_path7.Text = "essay 7"; file_path8.Text = "essay 8"; file_path9.Text = "essay 9"; file_path10.Text = "essay 10"; file_path11.Text = "Add essay";
                    file12.Visible = false;
                    file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_essays == 11)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = Properties.Resources.file_storage1; file12.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "essay6"; file_path7.Text = "essay 7"; file_path8.Text = "essay 8"; file_path9.Text = "essay 9"; file_path10.Text = "essay 10"; file_path11.Text = "essay 11"; file_path12.Text = "Add essay";


                }
                else if (Properties.Settings.Default.nr_essays == 12)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = file12.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "essay 1"; file_path2.Text = "essay 2"; file_path3.Text = "essay 3"; file_path4.Text = "essay 4"; file_path5.Text = "essay 5"; file_path6.Text = "essay 6"; file_path7.Text = "essay 7"; file_path8.Text = "essay 8"; file_path9.Text = "essay 9"; file_path10.Text = "essay 10"; file_path11.Text = "essay 11"; file_path12.Text = "essay 12";
                    file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = true;

                }




            } else if (input == "Your reports")
            {
                whichenter = 1;
                trash.Visible = download.Visible = true; message.Text = "Delete all reports";

                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;
                if (Properties.Settings.Default.nr_reports == 0)
                {
                    trash.Visible = download.Visible = false;
                    file_path1.Text = "Add report";
                    file1.BackgroundImage = Properties.Resources.plus;
                    file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reports == 1)
                {
                    file1.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "report 1";
                    file_path2.Text = "Add report"; file2.BackgroundImage = Properties.Resources.plus;
                    file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reports == 2)
                {
                    file1.BackgroundImage = file2.BackgroundImage = Properties.Resources.file_storage1; file3.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "Add report";
                    file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reports == 3)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1; file4.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "Add report";
                    file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reports == 4)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = Properties.Resources.file_storage1; file5.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "Add report";
                    file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reports == 5)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = Properties.Resources.file_storage1; file6.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report5"; file_path6.Text = "Add report";
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reports == 6)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = Properties.Resources.file_storage1; file7.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report 5"; file_path6.Text = "report 6"; file_path7.Text = "Add report";
                    file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reports == 7)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = Properties.Resources.file_storage1; file8.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report 5"; file_path6.Text = "report 6"; file_path7.Text = "report 7"; file_path8.Text = "Add report";

                    file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reports == 8)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = Properties.Resources.file_storage1; file9.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report 5"; file_path6.Text = "report 6"; file_path7.Text = "report 7"; file_path8.Text = "report 8"; file_path9.Text = "Add report";

                    file10.Visible = file11.Visible = file12.Visible = false;
                    file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reports == 9)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = Properties.Resources.file_storage1; file10.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report 5"; file_path6.Text = "report 6"; file_path7.Text = "report 7"; file_path8.Text = "report 8"; file_path9.Text = "report 9"; file_path10.Text = "Add report";
                    file11.Visible = file12.Visible = false;
                    file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reports == 10)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = Properties.Resources.file_storage1; file11.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report 5"; file_path6.Text = "report 6"; file_path7.Text = "report 7"; file_path8.Text = "report 8"; file_path9.Text = "report 9"; file_path10.Text = "report 10"; file_path11.Text = "Add report";
                    file12.Visible = false;
                    file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reports == 11)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = Properties.Resources.file_storage1; file12.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report 5"; file_path6.Text = "report 6"; file_path7.Text = "report 7"; file_path8.Text = "report 8"; file_path9.Text = "report 9"; file_path10.Text = "report 10"; file_path11.Text = "report 11"; file_path12.Text = "Add report";


                }
                else if (Properties.Settings.Default.nr_reports == 12)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = file12.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "report 1"; file_path2.Text = "report 2"; file_path3.Text = "report 3"; file_path4.Text = "report 4"; file_path5.Text = "report 5"; file_path6.Text = "report 6"; file_path7.Text = "report 7"; file_path8.Text = "report 8"; file_path9.Text = "report 9"; file_path10.Text = "report 10"; file_path11.Text = "report 11"; file_path12.Text = "report 12";
                    file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = true;

                }



            }
            else if (input == "Your reviews")
            {
                whichenter = 1;
                trash.Visible = download.Visible = true; message.Text = "Delete all reviews";

                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;
                if (Properties.Settings.Default.nr_reviews == 0)
                {
                    trash.Visible = download.Visible = false;
                    file_path1.Text = "Add review";
                    file1.BackgroundImage = Properties.Resources.plus;
                    file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reviews == 1)
                {
                    file1.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "review 1";
                    file_path2.Text = "Add review"; file2.BackgroundImage = Properties.Resources.plus;
                    file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reviews == 2)
                {
                    file1.BackgroundImage = file2.BackgroundImage = Properties.Resources.file_storage1; file3.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "Add review";
                    file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reviews == 3)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1; file4.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "Add review";
                    file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reviews == 4)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = Properties.Resources.file_storage1; file5.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "Add review";
                    file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reviews == 5)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = Properties.Resources.file_storage1; file6.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "review 5"; file_path6.Text = "Add review";
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reviews == 6)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = Properties.Resources.file_storage1; file7.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "review 5"; file_path6.Text = "reviw 6"; file_path7.Text = "Add review";
                    file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reviews == 7)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = Properties.Resources.file_storage1; file8.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "review 5"; file_path6.Text = "review 6"; file_path7.Text = "review 7"; file_path8.Text = "Add review";

                    file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reviews == 8)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = Properties.Resources.file_storage1; file9.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "review 5"; file_path6.Text = "review 6"; file_path7.Text = "review 7"; file_path8.Text = "review 8"; file_path9.Text = "Add review";

                    file10.Visible = file11.Visible = file12.Visible = false;
                    file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reviews == 9)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = Properties.Resources.file_storage1; file10.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "report 5"; file_path6.Text = "review 6"; file_path7.Text = "review 7"; file_path8.Text = "review 8"; file_path9.Text = "review 9"; file_path10.Text = "Add review";
                    file11.Visible = file12.Visible = false;
                    file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_reviews == 10)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = Properties.Resources.file_storage1; file11.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "review 5"; file_path6.Text = "review 6"; file_path7.Text = "review 7"; file_path8.Text = "review 8"; file_path9.Text = "review 9"; file_path10.Text = "review 10"; file_path11.Text = "Add review";
                    file12.Visible = false;
                    file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_reviews == 11)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = Properties.Resources.file_storage1; file12.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "review 5"; file_path6.Text = "review 6"; file_path7.Text = "review 7"; file_path8.Text = "review 8"; file_path9.Text = "review 9"; file_path10.Text = "review 10"; file_path11.Text = "review 11"; file_path12.Text = "Add review";


                }
                else if (Properties.Settings.Default.nr_reviews == 12)
                {
                    
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = file12.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "review 1"; file_path2.Text = "review 2"; file_path3.Text = "review 3"; file_path4.Text = "review 4"; file_path5.Text = "review 5"; file_path6.Text = "review 6"; file_path7.Text = "reviewt 7"; file_path8.Text = "review 8"; file_path9.Text = "review 9"; file_path10.Text = "review 10"; file_path11.Text = "review 11"; file_path12.Text = "review 12";
                    file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = true;

                }



            } else if (input == "Your proposals")
            {
                whichenter = 1;
                trash.Visible = download.Visible = true; message.Text = "Delete all proposal";

                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;
                if (Properties.Settings.Default.nr_proposals == 0)
                {
                    trash.Visible = download.Visible = false;
                    file_path1.Text = "Add proposal";
                    file1.BackgroundImage = Properties.Resources.plus;
                    file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_proposals == 1)
                {
                    file1.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "proposal 1";
                    file_path2.Text = "Add proposal"; file2.BackgroundImage = Properties.Resources.plus;
                    file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_proposals == 2)
                {
                    file1.BackgroundImage = file2.BackgroundImage = Properties.Resources.file_storage1; file3.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "Add proposal";
                    file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_proposals == 3)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1; file4.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "Add proposal";
                    file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_proposals == 4)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = Properties.Resources.file_storage1; file5.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "Add proposal";
                    file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_proposals == 5)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = Properties.Resources.file_storage1; file6.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal 5"; file_path6.Text = "Add proposal";
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_proposals == 6)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = Properties.Resources.file_storage1; file7.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal 5"; file_path6.Text = "proposal 6"; file_path7.Text = "Add proposal";
                    file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_proposals == 7)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = Properties.Resources.file_storage1; file8.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal 5"; file_path6.Text = "proposal 6"; file_path7.Text = "proposal 7"; file_path8.Text = "Add proposal";

                    file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_proposals == 8)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = Properties.Resources.file_storage1; file9.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal 5"; file_path6.Text = "proposal 6"; file_path7.Text = "proposal 7"; file_path8.Text = "proposal 8"; file_path9.Text = "Add proposal";

                    file10.Visible = file11.Visible = file12.Visible = false;
                    file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_proposals == 9)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = Properties.Resources.file_storage1; file10.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal5"; file_path6.Text = "proposal 6"; file_path7.Text = "proposal 7"; file_path8.Text = "proposal 8"; file_path9.Text = "proposal 9"; file_path10.Text = "Add proposal";
                    file11.Visible = file12.Visible = false;
                    file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_proposals == 10)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = Properties.Resources.file_storage1; file11.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal 5"; file_path6.Text = "proposal 6"; file_path7.Text = "proposal 7"; file_path8.Text = "proposal 8"; file_path9.Text = "proposal 9"; file_path10.Text = "proposal 10"; file_path11.Text = "Add proposal";
                    file12.Visible = false;
                    file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_proposals == 11)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = Properties.Resources.file_storage1; file12.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal 5"; file_path6.Text = "proposal 6"; file_path7.Text = "proposal 7"; file_path8.Text = "proposal 8"; file_path9.Text = "proposal 9"; file_path10.Text = "proposal 10"; file_path11.Text = "proposal 11"; file_path12.Text = "Add proposal";


                }
                else if (Properties.Settings.Default.nr_proposals == 12)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = file12.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "proposal 1"; file_path2.Text = "proposal 2"; file_path3.Text = "proposal 3"; file_path4.Text = "proposal 4"; file_path5.Text = "proposal 5"; file_path6.Text = "proposal 6"; file_path7.Text = "proposal 7"; file_path8.Text = "proposal 8"; file_path9.Text = "proposal 9"; file_path10.Text = "proposal 10"; file_path11.Text = "proposal 11"; file_path12.Text = "proposal 12";
                    file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = true;

                }





            } else if (input == "Your formal letters")
            {
                whichenter = 1;
                trash.Visible = download.Visible = true; message.Text = "Delete all formal letters";


                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;
                if (Properties.Settings.Default.nr_formal_letters == 0)
                {
                    trash.Visible = download.Visible = false;
                    file_path1.Text = "Add formal letter";
                    file1.BackgroundImage = Properties.Resources.plus;
                    file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_formal_letters == 1)
                {
                    file1.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "formal letter 1";
                    file_path2.Text = "Add formal letter"; file2.BackgroundImage = Properties.Resources.plus;
                    file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_formal_letters == 2)
                {
                    file1.BackgroundImage = file2.BackgroundImage = Properties.Resources.file_storage1; file3.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "Add formal letter";
                    file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_formal_letters == 3)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1; file4.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "Add formal letter";
                    file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_formal_letters == 4)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = Properties.Resources.file_storage1; file5.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "Add formal letter";
                    file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_formal_letters == 5)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = Properties.Resources.file_storage1; file6.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "Add formal letter";
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_formal_letters == 6)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = Properties.Resources.file_storage1; file7.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "formal letter 6"; file_path7.Text = "Add formal letter";
                    file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_formal_letters == 7)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = Properties.Resources.file_storage1; file8.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "formal letter 6"; file_path7.Text = "formal letter 7"; file_path8.Text = "Add formal letter";

                    file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_formal_letters == 8)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = Properties.Resources.file_storage1; file9.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "formal letter 6"; file_path7.Text = "formal letter 7"; file_path8.Text = "formal letter 8"; file_path9.Text = "Add formal letter";

                    file10.Visible = file11.Visible = file12.Visible = false;
                    file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_formal_letters == 9)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = Properties.Resources.file_storage1; file10.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "formal letter 6"; file_path7.Text = "formal letter 7"; file_path8.Text = "formal letter 8"; file_path9.Text = "formal letter 9"; file_path10.Text = "Add formal letter";
                    file11.Visible = file12.Visible = false;
                    file_path11.Visible = file_path12.Visible = false;


                }
                else if (Properties.Settings.Default.nr_formal_letters == 10)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = Properties.Resources.file_storage1; file11.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "formal letter 6"; file_path7.Text = "formal letter 7"; file_path8.Text = "formal letter 8"; file_path9.Text = "formal letter 9"; file_path10.Text = "formal letter 10"; file_path11.Text = "Add formal letter";
                    file12.Visible = false;
                    file_path12.Visible = false;

                }
                else if (Properties.Settings.Default.nr_formal_letters == 11)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = Properties.Resources.file_storage1; file12.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "formal letter 6"; file_path7.Text = "formal letter 7"; file_path8.Text = "formal letter 8"; file_path9.Text = "formal letter 9"; file_path10.Text = "formal letter 10"; file_path11.Text = "formal letter 11"; file_path12.Text = "Add formal letter";


                }
                else if (Properties.Settings.Default.nr_formal_letters == 12)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = file12.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "formal letter 1"; file_path2.Text = "formal letter 2"; file_path3.Text = "formal letter 3"; file_path4.Text = "formal letter 4"; file_path5.Text = "formal letter 5"; file_path6.Text = "formal letter 6"; file_path7.Text = "formal letter 7"; file_path8.Text = "formal letter 8"; file_path9.Text = "formal letter 9"; file_path10.Text = "formal letter 10"; file_path11.Text = "formal letter 11"; file_path12.Text = "formal letter 12";
                    file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = true;

                }



            } else if (input == "Your informal letters")
            {
                whichenter = 1;
                trash.Visible = download.Visible = true; message.Text = "Delete all informal letters";


                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;
                if (Properties.Settings.Default.nr_informal_letters == 0)
                {
                    trash.Visible = download.Visible = false;
                    file_path1.Text = "Add informal letter";
                    file1.BackgroundImage = Properties.Resources.plus;
                    file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path2.Visible = file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                } else if (Properties.Settings.Default.nr_informal_letters == 1)
                {
                    file1.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "informal letter 1";
                    file_path2.Text = "Add informal letter"; file2.BackgroundImage = Properties.Resources.plus;
                    file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path3.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                } else if (Properties.Settings.Default.nr_informal_letters == 2)
                {
                    file1.BackgroundImage = file2.BackgroundImage = Properties.Resources.file_storage1; file3.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "Add informal letter";
                    file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                } else if (Properties.Settings.Default.nr_informal_letters == 3)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1; file4.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "Add informal letter";
                    file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                } else if (Properties.Settings.Default.nr_informal_letters == 4)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = Properties.Resources.file_storage1; file5.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "Add informal letter";
                    file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


                } else if (Properties.Settings.Default.nr_informal_letters == 5)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = Properties.Resources.file_storage1; file6.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "Add informal letter";
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                } else if (Properties.Settings.Default.nr_informal_letters == 6)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = Properties.Resources.file_storage1; file7.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "informal letter 6"; file_path7.Text = "Add informal letter";
                    file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                } else if (Properties.Settings.Default.nr_informal_letters == 7)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = Properties.Resources.file_storage1; file8.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "informal letter 6"; file_path7.Text = "informal letter 7"; file_path8.Text = "Add informal letter";

                    file9.Visible = file10.Visible = file11.Visible = file12.Visible = false;
                    file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                } else if (Properties.Settings.Default.nr_informal_letters == 8)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = Properties.Resources.file_storage1; file9.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "informal letter 6"; file_path7.Text = "informal letter 7"; file_path8.Text = "informal letter 8"; file_path9.Text = "Add informal letter";

                    file10.Visible = file11.Visible = file12.Visible = false;
                    file_path10.Visible = file_path11.Visible = file_path12.Visible = false;

                } else if (Properties.Settings.Default.nr_informal_letters == 9)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = Properties.Resources.file_storage1; file10.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "informal letter 6"; file_path7.Text = "informal letter 7"; file_path8.Text = "informal letter 8"; file_path9.Text = "informal letter 9"; file_path10.Text = "Add informal letter";
                    file11.Visible = file12.Visible = false;
                    file_path11.Visible = file_path12.Visible = false;


                } else if (Properties.Settings.Default.nr_informal_letters == 10)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = Properties.Resources.file_storage1; file11.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "informal letter 6"; file_path7.Text = "informal letter 7"; file_path8.Text = "informal letter 8"; file_path9.Text = "informal letter 9"; file_path10.Text = "informal letter 10"; file_path11.Text = "Add informal letter";
                    file12.Visible = false;
                    file_path12.Visible = false;

                } else if (Properties.Settings.Default.nr_informal_letters == 11)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = Properties.Resources.file_storage1; file12.BackgroundImage = Properties.Resources.plus;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "informal letter 6"; file_path7.Text = "informal letter 7"; file_path8.Text = "informal letter 8"; file_path9.Text = "informal letter 9"; file_path10.Text = "informal letter 10"; file_path11.Text = "informal letter 11"; file_path12.Text = "Add informal letter";


                } else if (Properties.Settings.Default.nr_informal_letters == 12)
                {
                    file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = file4.BackgroundImage = file5.BackgroundImage = file6.BackgroundImage = file7.BackgroundImage = file8.BackgroundImage = file9.BackgroundImage = file10.BackgroundImage = file11.BackgroundImage = file12.BackgroundImage = Properties.Resources.file_storage1;
                    file_path1.Text = "informal letter 1"; file_path2.Text = "informal letter 2"; file_path3.Text = "informal letter 3"; file_path4.Text = "informal letter 4"; file_path5.Text = "informal letter 5"; file_path6.Text = "informal letter 6"; file_path7.Text = "informal letter 7"; file_path8.Text = "informal letter 8"; file_path9.Text = "informal letter 9"; file_path10.Text = "informal letter 10"; file_path11.Text = "informal letter 11"; file_path12.Text = "informal letter 12";
                    file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = true;

                }

            } else if (input == "essay 1" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 1))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_1";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask1;

                if (Properties.Settings.Default.essay1.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay1;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;
            } else if (input == "essay 2" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 2))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_2";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask2;

                if (Properties.Settings.Default.essay2.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay2;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;
            } else if (input == "essay 3" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 3))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_3";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask3;

                if (Properties.Settings.Default.essay3.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay3;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;
            } else if (input == "essay 4" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 4))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_4";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask4;

                if (Properties.Settings.Default.essay4.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay4;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;
            } else if (input == "essay 5" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 5))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_5";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask5;

                if (Properties.Settings.Default.essay5.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay5;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;

            } else if (input == "essay 6" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 6))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_6";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask6;
                if (Properties.Settings.Default.essay6.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay6;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }


                whichenter = 3;
            } else if (input == "essay 7" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 7))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_7";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask7;

                if (Properties.Settings.Default.essay7.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay7;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;
            } else if (input == "essay 8" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 8))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_8";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask8;
                if (Properties.Settings.Default.essay8.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay8;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;
            } else if (input == "essay 9" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 9))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_9";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask9;
                if (Properties.Settings.Default.essay9.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay9;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }


                whichenter = 3;
            } else if (input == "essay 10" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 10))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_10";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask10;
                if (Properties.Settings.Default.essay10.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay10;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }


                whichenter = 3;
            } else if (input == "essay 11" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 11))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_11";
                pathern.Visible = download.Visible = true;
                if (Properties.Settings.Default.essay11.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay11;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }


                whichenter = 3;
            } else if (input == "essay 12" || (input == "Add essay" && Properties.Settings.Default.nr_essays == 12))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#essay_12";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.essaytask11;

                if (Properties.Settings.Default.essay12.Trim() != "") paper_sheet.Text = Properties.Settings.Default.essay12;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 3;

            } else if (input == "report 1" || (input == "Add report" && Properties.Settings.Default.nr_reports == 1))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_1";

                if (Properties.Settings.Default.report1.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report1;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;


                eror();
            }
            else if (input == "report 2" || (input == "Add report" && Properties.Settings.Default.nr_reports == 2))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_2";

                if (Properties.Settings.Default.report2.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report2;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 3" || (input == "Add report" && Properties.Settings.Default.nr_reports == 3))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_3";

                if (Properties.Settings.Default.report3.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report3;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 4" || (input == "Add report" && Properties.Settings.Default.nr_reports == 4))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_4";

                if (Properties.Settings.Default.report4.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report4;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 5" || (input == "Add report" && Properties.Settings.Default.nr_reports == 5))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_5";

                if (Properties.Settings.Default.report5.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report5;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 6" || (input == "Add report" && Properties.Settings.Default.nr_reports == 6))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_6";

                if (Properties.Settings.Default.report6.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report6;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 7" || (input == "Add report" && Properties.Settings.Default.nr_reports == 7))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_7";

                if (Properties.Settings.Default.report7.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report7;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 8" || (input == "Add report" && Properties.Settings.Default.nr_reports == 8))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_8";

                if (Properties.Settings.Default.report8.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report8;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 9" || (input == "Add report" && Properties.Settings.Default.nr_reports == 9))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_9";

                if (Properties.Settings.Default.report9.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report9;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 10" || (input == "Add report" && Properties.Settings.Default.nr_reports == 10))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_10";

                if (Properties.Settings.Default.report10.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report10;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 11" || (input == "Add report" && Properties.Settings.Default.nr_reports == 11))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_11";

                if (Properties.Settings.Default.report12.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report12;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "report 12" || (input == "Add report" && Properties.Settings.Default.nr_reports == 12))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#report_12";
                if (Properties.Settings.Default.report12.Trim() != "") paper_sheet.Text = Properties.Settings.Default.report12;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 4;

                eror();
            }
            else if (input == "review 1" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 1))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#review_1";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.reviewtask1;
                if (Properties.Settings.Default.review1.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review1;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
            }
            else if (input == "review 2" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 2))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_2";
                pathern.Visible = true; pathern.BackgroundImage = Properties.Resources.reviewtask2;
                if (Properties.Settings.Default.review2.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review2;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                pathern.Visible = true;
            }
            else if (input == "review 3" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 3))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_3";
                if (Properties.Settings.Default.review3.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review3;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;

                eror();
            }
            else if (input == "review 4" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 4))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#review4";
                if (Properties.Settings.Default.review4.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review4;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;

                eror();
            }
            else if (input == "review 5" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 5))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_5";
                if (Properties.Settings.Default.review5.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review5;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;

                eror();
            }
            else if (input == "review 6" || (input == "Add review" && Properties.Settings.Default.nr_reports == 6))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_6";
                if (Properties.Settings.Default.review6.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review6;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                eror();
            }
            else if (input == "review 7" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 7))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_7";
                if (Properties.Settings.Default.review7.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review7;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                eror();
            }
            else if (input == "review 8" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 8))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_8";
                if (Properties.Settings.Default.review8.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review8;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                eror();
            }
            else if (input == "review 9" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 9))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_9";
                if (Properties.Settings.Default.review9.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review9;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                eror();
            }
            else if (input == "review 10" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 10))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_10";
                if (Properties.Settings.Default.review10.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review10;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                eror();
            }
            else if (input == "review 11" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 11))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_11";
                if (Properties.Settings.Default.review11.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review11;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                eror();
            }
            else if (input == "review 12" || (input == "Add review" && Properties.Settings.Default.nr_reviews == 12))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#review_12";
                if (Properties.Settings.Default.review12.Trim() != "") paper_sheet.Text = Properties.Settings.Default.review12;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 5;
                eror();
            }
            else if (input == "proposal 1" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 1))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#proposal_1";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.proposaltask1;
                if (Properties.Settings.Default.proposal1.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal1;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
            }
            else if (input == "proposal 2" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 2))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = true; task.Text = "#proposal_2";
                pathern.Visible = download.Visible = true; pathern.BackgroundImage = Properties.Resources.proposaltask2;
                if (Properties.Settings.Default.proposal2.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal2;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
            }
            else if (input == "proposal 3" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 3))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_3";
                if (Properties.Settings.Default.proposal3.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal3;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 4" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 4))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_4";
                if (Properties.Settings.Default.proposal4.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal4;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 5" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 5))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_5";
                if (Properties.Settings.Default.proposal5.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal5;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 6" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 6))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_6";
                if (Properties.Settings.Default.proposal6.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal6;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 7" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 7))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_7";
                if (Properties.Settings.Default.proposal7.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal7;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 8" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 8))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_8";
                if (Properties.Settings.Default.proposal8.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal8;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 9" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 9))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_9";
                if (Properties.Settings.Default.proposal9.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal9;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 10" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 10))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_10";
                if (Properties.Settings.Default.proposal10.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal10;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 11" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 11))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_11";
                if (Properties.Settings.Default.proposal11.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal11;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "proposal 12" || (input == "Add proposal" && Properties.Settings.Default.nr_proposals == 12))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#proposal_12";
                if (Properties.Settings.Default.proposal12.Trim() != "") paper_sheet.Text = Properties.Settings.Default.proposal12;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 6;
                eror();
            }
            else if (input == "formal letter 1" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 1))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_1";
                if (Properties.Settings.Default.formal_letter1.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter1;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 2" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 2))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_2";
                if (Properties.Settings.Default.formal_letter2.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter2;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }

                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 3" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 3))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_3";
                if (Properties.Settings.Default.formal_letter3.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter3;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 4" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 4))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_4";
                if (Properties.Settings.Default.formal_letter4.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter4;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 5" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 5))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_5";
                if (Properties.Settings.Default.formal_letter5.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter5;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 6" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 6))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_6";
                if (Properties.Settings.Default.formal_letter6.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter6;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 7" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 7))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_7";
                if (Properties.Settings.Default.formal_letter7.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter7;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 8" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 8))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_8";
                if (Properties.Settings.Default.formal_letter8.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter8;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 9" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 9))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_9";
                if (Properties.Settings.Default.formal_letter9.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter9;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 10" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 10))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_10";
                if (Properties.Settings.Default.formal_letter10.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter10;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 11" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 11))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_11";
                if (Properties.Settings.Default.formal_letter11.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter11;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "formal letter 12" || (input == "Add formal letter" && Properties.Settings.Default.nr_formal_letters == 12))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_12";
                if (Properties.Settings.Default.formal_letter12.Trim() != "") paper_sheet.Text = Properties.Settings.Default.formal_letter12;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 7;
                eror();
            }
            else if (input == "informal letter 1" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 1))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_1";
                if (Properties.Settings.Default.informal_letter1.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter1;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 2" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 2))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_2";
                if (Properties.Settings.Default.informal_letter2.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter2;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 3" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 3))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_3";
                if (Properties.Settings.Default.informal_letter3.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter3;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 4" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 4))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_4";
                if (Properties.Settings.Default.informal_letter4.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter4;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 5" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 5))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_5";
                if (Properties.Settings.Default.informal_letter5.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter5;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 6" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 6))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "in#formal_letter_6";
                if (Properties.Settings.Default.informal_letter6.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter6;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 7" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 7))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_7";
                if (Properties.Settings.Default.informal_letter7.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter7;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 8" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 8))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#formal_letter_8";
                if (Properties.Settings.Default.informal_letter8.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter8;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();

            }
            else if (input == "informal letter 9" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 9))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_9";
                if (Properties.Settings.Default.informal_letter9.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter9;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();

            }
            else if (input == "informal letter 10" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 10))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_10";
                if (Properties.Settings.Default.informal_letter10.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter10;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();

            }
            else if (input == "informal letter 11" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 11))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_11";
                if (Properties.Settings.Default.informal_letter11.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter11;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();
            }
            else if (input == "informal letter 12" || (input == "Add informal letter" && Properties.Settings.Default.nr_informal_letters == 12))
            {
                paper_sheet.Visible = label1.Visible = label2.Visible = true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;
                task.Visible = download.Visible = true; task.Text = "#informal_letter_12";
                if (Properties.Settings.Default.informal_letter12.Trim() != "") paper_sheet.Text = Properties.Settings.Default.informal_letter12;
                else { paper_sheet.Text = "...type your answear here"; paper_sheet.ForeColor = Color.Gray; paper_sheet.ReadOnly = true; }
                whichenter = 8;
                eror();

            }
            Properties.Settings.Default.Save();
        }

        void navigare()
        {
            cb1.Visible = false;
            previous.Visible = next.Visible = true;
            ilm.Visible = true;
            ilslide.BackgroundImage = ilm.BackgroundImage;

            if (q == "basic words")
            {
                cb1.Visible = true;
                if (poz == 1) { cb1.Text = "Nature"; ilm.BackgroundImage = Properties.Resources.nature1; previous.Visible = false; }
                else if (poz == 2) { cb1.Text = "Nature"; ilm.BackgroundImage = Properties.Resources.nature2; }
                else if (poz == 3) { cb1.Text = "Animals"; ilm.BackgroundImage = Properties.Resources.animals1; }
                else if (poz == 4) { cb1.Text = "Animals"; ilm.BackgroundImage = Properties.Resources.animals2; }
                else if (poz == 5) { cb1.Text = "Animals"; ilm.BackgroundImage = Properties.Resources.animals3; }
                else if (poz == 6) { cb1.Text = "Body"; ilm.BackgroundImage = Properties.Resources.body1; }
                else if (poz == 7) { cb1.Text = "Body"; ilm.BackgroundImage = Properties.Resources.body2; }
                else if (poz == 8) { cb1.Text = "Health"; ilm.BackgroundImage = Properties.Resources.health1; }
                else if (poz == 9) { cb1.Text = "Household"; ilm.BackgroundImage = Properties.Resources.household1; }
                else if (poz == 10) { cb1.Text = "Household"; ilm.BackgroundImage = Properties.Resources.household2; }
                else if (poz == 11) { cb1.Text = "Household"; ilm.BackgroundImage = Properties.Resources.household3; }
                else if (poz == 12) { cb1.Text = "Household"; ilm.BackgroundImage = Properties.Resources.household4; }
                else if (poz == 13) { cb1.Text = "Household"; ilm.BackgroundImage = Properties.Resources.household5; }
                else if (poz == 14) { cb1.Text = "Household"; ilm.BackgroundImage = Properties.Resources.household6; }
                else if (poz == 15) { cb1.Text = "Food"; ilm.BackgroundImage = Properties.Resources.food1; }
                else if (poz == 16) { cb1.Text = "Food"; ilm.BackgroundImage = Properties.Resources.food2; }
                else if (poz == 17) { cb1.Text = "Food"; ilm.BackgroundImage = Properties.Resources.food3; }
                else if (poz == 18) { cb1.Text = "Food"; ilm.BackgroundImage = Properties.Resources.food4; }
                else if (poz == 19) { cb1.Text = "Food"; ilm.BackgroundImage = Properties.Resources.food5; }
                else if (poz == 20) { cb1.Text = "City"; ilm.BackgroundImage = Properties.Resources.city1; }
                else if (poz == 21) { cb1.Text = "City"; ilm.BackgroundImage = Properties.Resources.city2; }
                else if (poz == 22) { cb1.Text = "City"; ilm.BackgroundImage = Properties.Resources.city3; }
                else if (poz == 23) { cb1.Text = "Travel"; ilm.BackgroundImage = Properties.Resources.travel1; }
                else if (poz == 24) { cb1.Text = "Travel"; ilm.BackgroundImage = Properties.Resources.travel2; }
                else if (poz == 25) { cb1.Text = "Travel"; ilm.BackgroundImage = Properties.Resources.travel3; }
                else if (poz == 26) { cb1.Text = "Other"; ilm.BackgroundImage = Properties.Resources.other1; }
                else if (poz == 27) { cb1.Text = "Other"; ilm.BackgroundImage = Properties.Resources.other2; }
                else if (poz == 28) { cb1.Text = "Other"; ilm.BackgroundImage = Properties.Resources.other3; ; next.Visible = false; }
            }
            else if (q == "verbs")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.verb1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.verb2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.verb3; }
                else if (poz == 4) {; ilm.BackgroundImage = Properties.Resources.verb4; }
                else if (poz == 5) { ilm.BackgroundImage = Properties.Resources.verb5; }
                else if (poz == 6) { ilm.BackgroundImage = Properties.Resources.verb6; }
                else if (poz == 7) { ilm.BackgroundImage = Properties.Resources.verb7; next.Visible = false; }



            }
            else if (q == "idioms")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.idiom1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.idiom2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.idiom3; }
                else if (poz == 4) { ilm.BackgroundImage = Properties.Resources.idiom4; }
                else if (poz == 5) { ilm.BackgroundImage = Properties.Resources.idiom5; }
                else if (poz == 6) { ilm.BackgroundImage = Properties.Resources.idiom5; }
                else if (poz == 7) { ilm.BackgroundImage = Properties.Resources.idiom5; }
                else if (poz == 8) { ilm.BackgroundImage = Properties.Resources.idiom5; }
                else if (poz == 9) { ilm.BackgroundImage = Properties.Resources.idiom5; }
                else if (poz == 10) { ilm.BackgroundImage = Properties.Resources.idiom5; }
                else if (poz == 11) { ilm.BackgroundImage = Properties.Resources.idiom11; }
                else if (poz == 12) { ilm.BackgroundImage = Properties.Resources.idiom12; }
                else if (poz == 13) { ilm.BackgroundImage = Properties.Resources.idiom13; }
                else if (poz == 14) { ilm.BackgroundImage = Properties.Resources.idiom14; }
                else if (poz == 15) { ilm.BackgroundImage = Properties.Resources.idiom15; }
                else if (poz == 16) { ilm.BackgroundImage = Properties.Resources.idiom16; }
                else if (poz == 17) { ilm.BackgroundImage = Properties.Resources.idiom17; }
                else if (poz == 18) { ilm.BackgroundImage = Properties.Resources.idiom18; }
                else if (poz == 19) { ilm.BackgroundImage = Properties.Resources.idiom19; }
                else if (poz == 20) { ilm.BackgroundImage = Properties.Resources.idiom20; next.Visible = false; }

            }
            else if (q == "nouns")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.noun1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.noun2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.noun3; }
                else if (poz == 4) { ilm.BackgroundImage = Properties.Resources.noun4; }
                else if (poz == 5) { ilm.BackgroundImage = Properties.Resources.noun5; next.Visible = false; }

            }
            else if (q == "pronouns")
            {
                next.Visible = previous.Visible = false;

                ilm.BackgroundImage = Properties.Resources.pronoun1;
            } else if (q == "adverbs")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.adverb1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.adverb2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.adverb3; next.Visible = false; }
            } else if (q == "essay")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.essay1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.essay2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.essay3; next.Visible = false; }
            } else if (q == "proposal")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.proposal1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.proposal2; next.Visible = false; }

            } else if (q == "report")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.report1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.report2; next.Visible = false; }
            } else if (q == "review")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.review1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.review2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.review3; next.Visible = false; }
            } else if (q == "informal letter")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.informalletter1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.informalletter2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.letter; next.Visible = false; }

            } else if (q == "formal letter")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.formalletter1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.formalletter2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.formalletter3; }
                else if (poz == 4) { ilm.BackgroundImage = Properties.Resources.formalletter4; }
                else if (poz == 5) { ilm.BackgroundImage = Properties.Resources.formalletter5; }
                else if (poz == 6) { ilm.BackgroundImage = Properties.Resources.letter; next.Visible = false; }
            } else if (q == "Phrasal verbs")
            {
                if (poz == 1) { ilm.BackgroundImage = Properties.Resources.pv1; previous.Visible = false; }
                else if (poz == 2) { ilm.BackgroundImage = Properties.Resources.pv2; }
                else if (poz == 3) { ilm.BackgroundImage = Properties.Resources.pv3; }
                else if (poz == 4) { ilm.BackgroundImage = Properties.Resources.pv4; }
                else if (poz == 5) { ilm.BackgroundImage = Properties.Resources.pv5; }
                else if (poz == 6) { ilm.BackgroundImage = Properties.Resources.pv6; }
                else if (poz == 7) { ilm.BackgroundImage = Properties.Resources.pv7; }
                else if (poz == 8) { ilm.BackgroundImage = Properties.Resources.pv8; }
                else if (poz == 9) { ilm.BackgroundImage = Properties.Resources.pv9; }
                else if (poz == 10) { ilm.BackgroundImage = Properties.Resources.pv10; }
                else if (poz == 11) { ilm.BackgroundImage = Properties.Resources.pv11; }
                else if (poz == 12) { ilm.BackgroundImage = Properties.Resources.pv12; }
                else if (poz == 13) { ilm.BackgroundImage = Properties.Resources.pv13; }
                else if (poz == 14) { ilm.BackgroundImage = Properties.Resources.pv14; }
                else if (poz == 15) { ilm.BackgroundImage = Properties.Resources.pv15; }
                else if (poz == 16) { ilm.BackgroundImage = Properties.Resources.pv16; }
                else if (poz == 17) { ilm.BackgroundImage = Properties.Resources.pv17; }
                else if (poz == 18) { ilm.BackgroundImage = Properties.Resources.pv18; }
                else if (poz == 19) { ilm.BackgroundImage = Properties.Resources.pv19; }
                else if (poz == 20) { ilm.BackgroundImage = Properties.Resources.pv20; }
                else if (poz == 21) { ilm.BackgroundImage = Properties.Resources.pv21; }
                else if (poz == 22) { ilm.BackgroundImage = Properties.Resources.pv22; }
                else if (poz == 23) { ilm.BackgroundImage = Properties.Resources.pv23; }
                else if (poz == 24) { ilm.BackgroundImage = Properties.Resources.pv24; }
                else if (poz == 25) { ilm.BackgroundImage = Properties.Resources.pv25; }
                else if (poz == 26) { ilm.BackgroundImage = Properties.Resources.pv26; }
                else if (poz == 27) { ilm.BackgroundImage = Properties.Resources.pv27; next.Visible = false; }

            }

        }

        private void cb1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        // red : 233, 74, 95

        private void paper_sheet_TextChanged(object sender, EventArgs e)
        {
            if (paper_sheet.Text != "...type your answear here" && paper_sheet.ReadOnly == false)
            {
                switch (task.Text)
                {
                    case "#essay_1":
                        Properties.Settings.Default.essay1 = paper_sheet.Text;
                        break;
                    case "#essay_2":
                        Properties.Settings.Default.essay2 = paper_sheet.Text;
                        break;
                    case "#essay_3":
                        Properties.Settings.Default.essay3 = paper_sheet.Text;
                        break;
                    case "#essay_4":
                        Properties.Settings.Default.essay4 = paper_sheet.Text;
                        break;
                    case "#essay_5":
                        Properties.Settings.Default.essay5 = paper_sheet.Text;
                        break;
                    case "#essay_6":
                        Properties.Settings.Default.essay6 = paper_sheet.Text;
                        break;
                    case "#essay_7":
                        Properties.Settings.Default.essay7 = paper_sheet.Text;
                        break;
                    case "#essay_8":
                        Properties.Settings.Default.essay8 = paper_sheet.Text;
                        break;
                    case "#essay_9":
                        Properties.Settings.Default.essay9 = paper_sheet.Text;
                        break;
                    case "#essay_10":
                        Properties.Settings.Default.essay10 = paper_sheet.Text;
                        break;
                    case "#essay_11":
                        Properties.Settings.Default.essay11 = paper_sheet.Text;
                        break;
                    case "#essay_12":
                        Properties.Settings.Default.essay12 = paper_sheet.Text;
                        break;
                    case "#report_1":
                        Properties.Settings.Default.report1 = paper_sheet.Text;
                        break;
                    case "#report_2":
                        Properties.Settings.Default.report2 = paper_sheet.Text;
                        break;
                    case "#report_3":
                        Properties.Settings.Default.report3 = paper_sheet.Text;
                        break;
                    case "#report_4":
                        Properties.Settings.Default.report4 = paper_sheet.Text;
                        break;
                    case "#report_5":
                        Properties.Settings.Default.report5 = paper_sheet.Text;
                        break;
                    case "#report_6":
                        Properties.Settings.Default.report6 = paper_sheet.Text;
                        break;
                    case "#report_7":
                        Properties.Settings.Default.report7 = paper_sheet.Text;
                        break;
                    case "#report_8":
                        Properties.Settings.Default.report8 = paper_sheet.Text;
                        break;
                    case "#report_9":
                        Properties.Settings.Default.report9 = paper_sheet.Text;
                        break;
                    case "#report_10":
                        Properties.Settings.Default.report10 = paper_sheet.Text;
                        break;
                    case "#report_11":
                        Properties.Settings.Default.report11 = paper_sheet.Text;
                        break;
                    case "#report_12":
                        Properties.Settings.Default.report12 = paper_sheet.Text;
                        break;
                    case "#review_1":
                        Properties.Settings.Default.review1 = paper_sheet.Text;
                        break;
                    case "#review_2":
                        Properties.Settings.Default.review2 = paper_sheet.Text;
                        break;
                    case "#review_3":
                        Properties.Settings.Default.review3 = paper_sheet.Text;
                        break;
                    case "#review_4":
                        Properties.Settings.Default.review4 = paper_sheet.Text;
                        break;
                    case "#review_5":
                        Properties.Settings.Default.review5 = paper_sheet.Text;
                        break;
                    case "#review_6":
                        Properties.Settings.Default.review6 = paper_sheet.Text;
                        break;
                    case "#review_7":
                        Properties.Settings.Default.review7 = paper_sheet.Text;
                        break;
                    case "#review_8":
                        Properties.Settings.Default.review8 = paper_sheet.Text;
                        break;
                    case "#review_9":
                        Properties.Settings.Default.review9 = paper_sheet.Text;
                        break;
                    case "#review_10":
                        Properties.Settings.Default.review10 = paper_sheet.Text;
                        break;
                    case "#review_11":
                        Properties.Settings.Default.review11 = paper_sheet.Text;
                        break;
                    case "#review_12":
                        Properties.Settings.Default.review12 = paper_sheet.Text;
                        break;
                    case "#proposal_1":
                        Properties.Settings.Default.proposal1 = paper_sheet.Text;
                        break;
                    case "#proposal_2":
                        Properties.Settings.Default.proposal2 = paper_sheet.Text;
                        break;
                    case "#proposal_3":
                        Properties.Settings.Default.proposal3 = paper_sheet.Text;
                        break;
                    case "#proposal_4":
                        Properties.Settings.Default.proposal4 = paper_sheet.Text;
                        break;
                    case "#proposal_5":
                        Properties.Settings.Default.proposal5 = paper_sheet.Text;
                        break;
                    case "#proposal_6":
                        Properties.Settings.Default.proposal6 = paper_sheet.Text;
                        break;
                    case "#proposal_7":
                        Properties.Settings.Default.proposal7 = paper_sheet.Text;
                        break;
                    case "#proposal_8":
                        Properties.Settings.Default.proposal8 = paper_sheet.Text;
                        break;
                    case "#proposal_9":
                        Properties.Settings.Default.proposal9 = paper_sheet.Text;
                        break;
                    case "#proposal_10":
                        Properties.Settings.Default.proposal10 = paper_sheet.Text;
                        break;
                    case "#proposal_11":
                        Properties.Settings.Default.proposal11 = paper_sheet.Text;
                        break;
                    case "#proposal_12":
                        Properties.Settings.Default.proposal12 = paper_sheet.Text;
                        break;
                    case "#formal_letter_1":
                        Properties.Settings.Default.formal_letter1 = paper_sheet.Text;
                        break;
                    case "#formal_letter_2":
                        Properties.Settings.Default.formal_letter2 = paper_sheet.Text;
                        break;
                    case "#formal_letter_3":
                        Properties.Settings.Default.formal_letter3 = paper_sheet.Text;
                        break;
                    case "#formal_letter_4":
                        Properties.Settings.Default.formal_letter4 = paper_sheet.Text;
                        break;
                    case "#formal_letter_5":
                        Properties.Settings.Default.formal_letter5 = paper_sheet.Text;
                        break;
                    case "#formal_letter_6":
                        Properties.Settings.Default.formal_letter6 = paper_sheet.Text;
                        break;
                    case "#formal_letter_7":
                        Properties.Settings.Default.formal_letter7 = paper_sheet.Text;
                        break;
                    case "#formal_letter_8":
                        Properties.Settings.Default.formal_letter8 = paper_sheet.Text;
                        break;
                    case "#formal_letter_9":
                        Properties.Settings.Default.formal_letter9 = paper_sheet.Text;
                        break;
                    case "#formal_letter_10":
                        Properties.Settings.Default.formal_letter10 = paper_sheet.Text;
                        break;
                    case "#formal_letter_11":
                        Properties.Settings.Default.formal_letter11 = paper_sheet.Text;
                        break;
                    case "#formal_letter_12":
                        Properties.Settings.Default.formal_letter12 = paper_sheet.Text;
                        break;
                    case "#informal_letter_1":
                        Properties.Settings.Default.informal_letter1 = paper_sheet.Text;
                        break;
                    case "#informal_letter_2":
                        Properties.Settings.Default.informal_letter2 = paper_sheet.Text;
                        break;
                    case "#informal_letter_3":
                        Properties.Settings.Default.informal_letter3 = paper_sheet.Text;
                        break;
                    case "#informal_letter_4":
                        Properties.Settings.Default.informal_letter4 = paper_sheet.Text;
                        break;
                    case "#informal_letter_5":
                        Properties.Settings.Default.informal_letter5 = paper_sheet.Text;
                        break;
                    case "#informal_letter_6":
                        Properties.Settings.Default.informal_letter6 = paper_sheet.Text;
                        break;
                    case "#informal_letter_7":
                        Properties.Settings.Default.informal_letter7 = paper_sheet.Text;
                        break;
                    case "#informal_letter_8":
                        Properties.Settings.Default.informal_letter8 = paper_sheet.Text;
                        break;
                    case "#informal_letter_9":
                        Properties.Settings.Default.informal_letter9 = paper_sheet.Text;
                        break;
                    case "#informal_letter_10":
                        Properties.Settings.Default.informal_letter10 = paper_sheet.Text;
                        break;
                    case "#informal_letter_11":
                        Properties.Settings.Default.informal_letter11 = paper_sheet.Text;
                        break;
                    case "#informal_letter_12":
                        Properties.Settings.Default.informal_letter12 = paper_sheet.Text;
                        break;

                    default:
                        break;
                }
                Properties.Settings.Default.Save();
            }

        }

        private void exit4_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            if (whichenter == 1)
            {
                input = "Writing";
                search();
            } else if (whichenter == 2)
            {
                home4.Visible = exit4.Visible = false;
                file1.Visible = file2.Visible = file3.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = true;
                file1.BackgroundImage = file2.BackgroundImage = file3.BackgroundImage = Properties.Resources.file_storage1;
                file_path1.Text = "Vocabulary";
                file_path2.Text = "Grammar";
                file_path3.Text = "Writing";
                file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = false;


            } else if (whichenter == 3)
            {
                label1.Visible = label2.Visible = task.Visible = paper_sheet.Visible = pathern.Visible = false;
                input = "Your essays";
                search();
            } else if (whichenter == 4)
            {
                label1.Visible = label2.Visible = task.Visible = paper_sheet.Visible = pathern.Visible = false;
                input = "Your reports";
                search();
            }
            else if (whichenter == 5)
            {
                label1.Visible = label2.Visible = task.Visible = paper_sheet.Visible = pathern.Visible = false;
                input = "Your reviews";
                search();
            }
            else if (whichenter == 6)
            {
                label1.Visible = label2.Visible = task.Visible = paper_sheet.Visible = pathern.Visible = false;
                input = "Your proposals";
                search();
            }
            else if (whichenter == 7)
            {
                label1.Visible = label2.Visible = task.Visible = paper_sheet.Visible = pathern.Visible = false;
                input = "Your formal letters";
                search();
            }
            else if (whichenter == 8)
            {
                label1.Visible = label2.Visible = task.Visible = paper_sheet.Visible = pathern.Visible = false;
                input = "Your informal letters";
                search();
            }
        }

        private void cb1_TextChanged(object sender, EventArgs e)
        {
            if (cb1.Text == "Nature") { poz = 1; navigare(); }
            else if (cb1.Text == "Animals") { poz = 3; navigare(); }
            else if (cb1.Text == "Body") { poz = 6; navigare(); }
            else if (cb1.Text == "Health") { poz = 8; navigare(); }
            else if (cb1.Text == "Household") { poz = 9; navigare(); }
            else if (cb1.Text == "Food") { poz = 15; navigare(); }
            else if (cb1.Text == "City") { poz = 20; navigare(); }
            else if (cb1.Text == "Travel") { poz = 23; navigare(); }
            else if (cb1.Text == "Other") { poz = 26; navigare(); }
        }

        private void shutdown_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            bootloader.Left -= 110;
            task.Visible = label1.Visible = label2.Visible = pathern.Visible = paper_sheet.Visible = download.Visible = sound4.Visible = home4.Visible = exit4.Visible = false;
            file1.Visible = file_path1.Visible = file2.Visible = file_path2.Visible = file3.Visible = file_path3.Visible = file4.Visible = file_path4.Visible = file5.Visible = file_path5.Visible = file6.Visible = file_path6.Visible = file7.Visible = file_path7.Visible = file8.Visible = file_path8.Visible = file9.Visible = file_path9.Visible = file10.Visible = file_path10.Visible = file11.Visible = file_path11.Visible = file12.Visible = file_path12.Visible = false;
            shutdown.BackgroundImage = Properties.Resources.power2;
            MediaPlayer1.controls.pause();
            Cursor.Hide();
            this.text_ora.Left = 495; this.text_ora.Top = 350;  // coordonatele s-ar trebuia sa necesite modificare de pe un dispozitiv pe altul
            this.text_2pct.Left = 534; this.text_2pct.Top = 350; // coordonatele s-ar trebuia sa necesite modificare de pe un dispozitiv pe altul
            this.text_minut.Left = 550; this.text_minut.Top = 350; // coordonatele s-ar trebuia sa necesite modificare de pe un dispozitiv pe altul
            loading_one.Width = 20; bootloader.Visible = loading_one.Visible = true;
            merge_cronometrul_shutting_down = true; counting_down_shutting_down = 250; nr_loop_shutting_down = 3;
        }

        private void phrasalverb_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            panel_grammar.Visible = panel_vocabulary.Visible = false;
            q = "Phrasal verbs"; poz = 1; navigare();
        }

        private void pathern_Click(object sender, EventArgs e)
        {

        }

        private void home4_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            back_to_home();
        }

        private void home3_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            back_to_home();
        }

        private void home2_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            back_to_home();
        }

        private void home1_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            back_to_home();
        }

        private void sound4_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            sounding();
        }

        private void sound3_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            sounding();
        }

        private void sound2_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            sounding();
        }

        private void timer_ceas_Tick(object sender, EventArgs e)
        {

            if (DateTime.Now.Hour < 10) text_ora.Text = '0' + Convert.ToString(DateTime.Now.Hour);
            else text_ora.Text = Convert.ToString(DateTime.Now.Hour);

            if (DateTime.Now.Minute < 10) text_minut.Text = '0' + Convert.ToString(DateTime.Now.Minute);
            else text_minut.Text = Convert.ToString(DateTime.Now.Minute);

            if (DateTime.Now.Second % 2 == 0) text_2pct.Text = " ";
            else text_2pct.Text = ":";

            if (merge_cronometrul_shutting_down == true)
            {


                switch (counting_down_shutting_down)
                {
                    case 250:
                        bootloader.Text = "Shutting down";
                        break;
                    case 248:                     // cazul asta il punem ca sa ajunga si bara la final ;))
                        nr_loop_shutting_down--; // cazul asta il punem ca sa ajunga si bara la final ;))
                        break;
                    case 210:
                        bootloader.Text = "Shutting down .";
                        break;
                    case 170:
                        bootloader.Text = "Shutting down ..";
                        break;
                    case 130:
                        bootloader.Text = "Shutting down ...";
                        break;
                    case 80:
                        bootloader.Text = "Shutting down ..";
                        break;
                    case 60:
                        if (nr_loop_shutting_down == 1)
                        {
                            MediaPlayer1.URL = URL_shut_down; MediaPlayer1.settings.setMode("loop", false); MediaPlayer1.controls.play();
                        }
                        break;
                    case 40:
                        bootloader.Text = "Shutting down .";
                        break;
                    case 0:
                        counting_down_shutting_down = 251;
                        
                        break;
                    default:
                        break;

                }
                switch (nr_loop_shutting_down)
                {
                    case 4:
                        loading_one.Width += 1;
                        break;
                    case 3:
                        loading_one.Width += 2;
                        break;
                    case 2:
                        loading_one.Width += 2;
                        
                        break;
                    case 1:
                        loading_one.Width += 2;
                        break;
                    case 0:
                        this.Close();
                        break;
                    default:
                        break;

                }
                counting_down_shutting_down--;
            }else if (merge_cronometrul_loading == true)
            {
                loading+=2;
                percentage.Text = Convert.ToString(loading / 10) + "%";
                switch (counting_down_shutting_down)
                {

                    case 250:
                        bootloader.Text = "Loading";
                        break;
                    case 248:                     // cazul asta il punem ca sa ajunga si bara la final ;))
                        nr_loop_shutting_down--; // cazul asta il punem ca sa ajunga si bara la final ;))
                        break;
                    case 210:
                        bootloader.Text = "Loading .";
                        break;
                    case 170:
                        bootloader.Text = "Loading ..";
                        break;
                    case 130:
                        bootloader.Text = "Loading ...";
                        break;
                    case 80:
                        bootloader.Text = "Loading ..";
                        break;
                    case 40:
                        bootloader.Text = "Loading .";
                        break;
                    case 0:
                        counting_down_shutting_down = 251;
                        break;
                    default:
                        break;

                }
                switch (nr_loop_shutting_down)
                {
                    case 4:
                        loading_one.Width += 1;
                        break;
                    case 3:
                        loading_one.Width += 2;
                        break;
                    case 2:
                        loading_one.Width += 2;
                        break;
                    case 1:
                        loading_one.Width += 2;
                        break;
                    case 0:
                        if(merge_cronometrul_loading==true)
                        {
                            MediaPlayer1.URL = URL_background_song; MediaPlayer1.settings.setMode("loop", true); MediaPlayer1.controls.play();
                            percentage.Visible = loading_one.Visible = bootloader.Visible = false;
                            file1.Visible = file_path1.Visible = file2.Visible = file_path2.Visible = file3.Visible = file_path3.Visible = text_ora.Visible = text_2pct.Visible = text_minut.Visible = sound4.Visible = true;
                            merge_cronometrul_loading = false;
                            Cursor.Show();
                        }
                        if (merge_cronometrul_shutting_down == true) this.Close();
                        break;
                    default:
                        break;

                }
                counting_down_shutting_down--;
            } 




        }

        private void sound1_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            sounding();
        }



        private void text_minut_Click(object sender, EventArgs e)
        {

        }

        private void text_2pct_Click(object sender, EventArgs e)
        {

        }

        private void logo1_MouseEnter(object sender, EventArgs e)
        {
            logo1.BackgroundImage = Properties.Resources.naturelogo2;

        }


        private void shutdown_MouseEnter(object sender, EventArgs e)
        {
            if (merge_cronometrul_shutting_down == false) shutdown.BackgroundImage = Properties.Resources.power2;
        }

        private void shutdown_MouseLeave(object sender, EventArgs e)
        {
            if (merge_cronometrul_shutting_down == false) shutdown.BackgroundImage = Properties.Resources.power1;
        }




        private void logo1_MouseLeave(object sender, EventArgs e)
        {
            logo1.BackgroundImage = Properties.Resources.naturelogo1;
        }

        private void logo2_MouseEnter(object sender, EventArgs e)
        {
            logo2.BackgroundImage = Properties.Resources.animalslogo2;
        }


        private void logo2_MouseLeave(object sender, EventArgs e)
        {
            logo2.BackgroundImage = Properties.Resources.animalslogo1;
        }

        private void logo3_MouseEnter(object sender, EventArgs e)
        {
            logo3.BackgroundImage = Properties.Resources.bodylogo2;
        }


        private void logo3_MouseLeave(object sender, EventArgs e)
        {
            logo3.BackgroundImage = Properties.Resources.bodylogo1;
        }


        private void logo4_MouseEnter(object sender, EventArgs e)
        {
            logo4.BackgroundImage = Properties.Resources.healthlogo2;
        }


        private void logo4_MouseLeave(object sender, EventArgs e)
        {
            logo4.BackgroundImage = Properties.Resources.healthlogo1;
        }


        private void logo5_MouseEnter(object sender, EventArgs e)
        {
            logo5.BackgroundImage = Properties.Resources.householdlogo2;
        }


        private void logo5_MouseLeave(object sender, EventArgs e)
        {
            logo5.BackgroundImage = Properties.Resources.householdlogo1;
        }

        private void logo6_MouseEnter(object sender, EventArgs e)
        {
            logo6.BackgroundImage = Properties.Resources.foodlogo2;
        }


        private void logo6_MouseLeave(object sender, EventArgs e)
        {
            logo6.BackgroundImage = Properties.Resources.foodlogo1;
        }

        private void logo7_MouseEnter(object sender, EventArgs e)
        {
            logo7.BackgroundImage = Properties.Resources.citylogo2;
        }


        private void logo7_MouseLeave(object sender, EventArgs e)
        {
            logo7.BackgroundImage = Properties.Resources.citylogo1;
        }

        private void logo8_MouseEnter(object sender, EventArgs e)
        {
            logo8.BackgroundImage = Properties.Resources.travellogo2;
        }


        private void logo8_MouseLeave(object sender, EventArgs e)
        {
            logo8.BackgroundImage = Properties.Resources.travellogo1;
        }




        private void logo9_MouseEnter(object sender, EventArgs e)
        {
            logo9.BackgroundImage = Properties.Resources.otherlogo2;
        }


        private void logo9_MouseLeave(object sender, EventArgs e)
        {
            logo9.BackgroundImage = Properties.Resources.otherlogo1;
        }








        private void exit1_MouseEnter(object sender, EventArgs e)
        {
            exit1.BackgroundImage = exit2.BackgroundImage = exit3.BackgroundImage = exit4.BackgroundImage = Properties.Resources.exit2;
        }

        private void exit1_MouseLeave(object sender, EventArgs e)
        {
            exit1.BackgroundImage = exit2.BackgroundImage = exit3.BackgroundImage = exit4.BackgroundImage = Properties.Resources.exit1;
        }

        private void home1_MouseEnter(object sender, EventArgs e)
        {
            home1.BackgroundImage = home2.BackgroundImage = home3.BackgroundImage = home4.BackgroundImage = Properties.Resources.homebutton2;
        }

        private void home1_MouseLeave(object sender, EventArgs e)
        {
            home1.BackgroundImage = home2.BackgroundImage = home3.BackgroundImage = home4.BackgroundImage = Properties.Resources.homebutton1;
        }

        private void file1_MouseEnter(object sender, EventArgs e)
        {
            if (file_path1.Text != "Add essay" && file_path1.Text != "Add report" && file_path1.Text != "Add review" && file_path1.Text != "Add proposal" && file_path1.Text != "Add formal letter" && file_path1.Text != "Add informal letter") file1.BackgroundImage = Properties.Resources.file_storage2;
            file_path1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path1.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file1_MouseLeave(object sender, EventArgs e)
        {
            if (file_path1.Text != "Add essay" && file_path1.Text != "Add report" && file_path1.Text != "Add review" && file_path1.Text != "Add proposal" && file_path1.Text != "Add formal letter" && file_path1.Text != "Add informal letter") file1.BackgroundImage = Properties.Resources.file_storage1;
            file_path1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path1.ForeColor = Color.Black;
        }


        private void file2_MouseEnter(object sender, EventArgs e)
        {
            if (file_path2.Text != "Add essay" && file_path2.Text != "Add report" && file_path2.Text != "Add review" && file_path2.Text != "Add proposal" && file_path2.Text != "Add formal letter" && file_path2.Text != "Add informal letter") file2.BackgroundImage = Properties.Resources.file_storage2;
            file_path2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path2.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file2_MouseLeave(object sender, EventArgs e)
        {
            if (file_path2.Text != "Add essay" && file_path2.Text != "Add report" && file_path2.Text != "Add review" && file_path2.Text != "Add proposal" && file_path2.Text != "Add formal letter" && file_path2.Text != "Add informal letter") file2.BackgroundImage = Properties.Resources.file_storage1;
            file_path2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path2.ForeColor = Color.Black;
        }

        private void file3_MouseEnter(object sender, EventArgs e)
        {
            if (file_path3.Text != "Add essay" && file_path3.Text != "Add report" && file_path3.Text != "Add review" && file_path3.Text != "Add proposal" && file_path3.Text != "Add formal letter" && file_path3.Text != "Add informal letter") file3.BackgroundImage = Properties.Resources.file_storage2;
            file_path3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path3.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file3_MouseLeave(object sender, EventArgs e)
        {
            if (file_path3.Text != "Add essay" && file_path3.Text != "Add report" && file_path3.Text != "Add review" && file_path3.Text != "Add proposal" && file_path3.Text != "Add formal letter" && file_path3.Text != "Add informal letter") file3.BackgroundImage = Properties.Resources.file_storage1;
            file_path3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path3.ForeColor = Color.Black;
        }

        private void file4_MouseEnter(object sender, EventArgs e)
        {
            if (file_path4.Text != "Add essay" && file_path4.Text != "Add report" && file_path4.Text != "Add review" && file_path4.Text != "Add proposal" && file_path4.Text != "Add formal letter" && file_path4.Text != "Add informal letter") file4.BackgroundImage = Properties.Resources.file_storage2;
            file_path4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path4.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file4_MouseLeave(object sender, EventArgs e)
        {
            if (file_path4.Text != "Add essay" && file_path4.Text != "Add report" && file_path4.Text != "Add review" && file_path4.Text != "Add proposal" && file_path4.Text != "Add formal letter" && file_path4.Text != "Add informal letter") file4.BackgroundImage = Properties.Resources.file_storage1;
            file_path4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path4.ForeColor = Color.Black;
        }

        private void file5_MouseEnter(object sender, EventArgs e)
        {
            if (file_path5.Text != "Add essay" && file_path5.Text != "Add report" && file_path5.Text != "Add review" && file_path5.Text != "Add proposal" && file_path5.Text != "Add formal letter" && file_path5.Text != "Add informal letter") file5.BackgroundImage = Properties.Resources.file_storage2;
            file_path5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path5.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file5_MouseLeave(object sender, EventArgs e)
        {
            if (file_path5.Text != "Add essay" && file_path5.Text != "Add report" && file_path5.Text != "Add review" && file_path5.Text != "Add proposal" && file_path5.Text != "Add formal letter" && file_path5.Text != "Add informal letter") file5.BackgroundImage = Properties.Resources.file_storage1;
            file_path5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path5.ForeColor = Color.Black;
        }

        private void file6_MouseEnter(object sender, EventArgs e)
        {
            if (file_path6.Text != "Add essay" && file_path6.Text != "Add report" && file_path6.Text != "Add review" && file_path6.Text != "Add proposal" && file_path6.Text != "Add formal letter" && file_path6.Text != "Add informal letter") file6.BackgroundImage = Properties.Resources.file_storage2;
            file_path6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path6.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file6_MouseLeave(object sender, EventArgs e)
        {
            if (file_path6.Text != "Add essay" && file_path6.Text != "Add report" && file_path6.Text != "Add review" && file_path6.Text != "Add proposal" && file_path6.Text != "Add formal letter" && file_path6.Text != "Add informal letter") file6.BackgroundImage = Properties.Resources.file_storage1;
            file_path6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path6.ForeColor = Color.Black;
        }

        private void file7_MouseEnter(object sender, EventArgs e)
        {
            if (file_path7.Text != "Add essay" && file_path7.Text != "Add report" && file_path7.Text != "Add review" && file_path7.Text != "Add proposal" && file_path7.Text != "Add formal letter" && file_path7.Text != "Add informal letter") file7.BackgroundImage = Properties.Resources.file_storage2;
            file_path7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path7.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file7_MouseLeave(object sender, EventArgs e)
        {
            if (file_path7.Text != "Add essay" && file_path7.Text != "Add report" && file_path7.Text != "Add review" && file_path7.Text != "Add proposal" && file_path7.Text != "Add formal letter" && file_path7.Text != "Add informal letter") file7.BackgroundImage = Properties.Resources.file_storage1;
            file_path7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path7.ForeColor = Color.Black;
        }

        private void file8_MouseEnter(object sender, EventArgs e)
        {
            if (file_path8.Text != "Add essay" && file_path8.Text != "Add report" && file_path8.Text != "Add review" && file_path8.Text != "Add proposal" && file_path8.Text != "Add formal letter" && file_path8.Text != "Add informal letter") file8.BackgroundImage = Properties.Resources.file_storage2;
            file_path8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path8.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file8_MouseLeave(object sender, EventArgs e)
        {
            if (file_path8.Text != "Add essay" && file_path8.Text != "Add report" && file_path8.Text != "Add review" && file_path8.Text != "Add proposal" && file_path8.Text != "Add formal letter" && file_path8.Text != "Add informal letter") file8.BackgroundImage = Properties.Resources.file_storage1;
            file_path8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path8.ForeColor = Color.Black;
        }

        private void file9_MouseEnter(object sender, EventArgs e)
        {
            if (file_path9.Text != "Add essay" && file_path9.Text != "Add report" && file_path9.Text != "Add review" && file_path9.Text != "Add proposal" && file_path9.Text != "Add formal letter" && file_path9.Text != "Add informal letter") file9.BackgroundImage = Properties.Resources.file_storage2;
            file_path9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path9.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file9_MouseLeave(object sender, EventArgs e)
        {
            if (file_path9.Text != "Add essay" && file_path9.Text != "Add report" && file_path9.Text != "Add review" && file_path9.Text != "Add proposal" && file_path9.Text != "Add formal letter" && file_path9.Text != "Add informal letter") file9.BackgroundImage = Properties.Resources.file_storage1;
            file_path9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path9.ForeColor = Color.Black;
        }

        private void file10_MouseEnter(object sender, EventArgs e)
        {
            if (file_path10.Text != "Add essay" && file_path10.Text != "Add report" && file_path10.Text != "Add review" && file_path10.Text != "Add proposal" && file_path10.Text != "Add formal letter" && file_path10.Text != "Add informal letter") file10.BackgroundImage = Properties.Resources.file_storage2;
            file_path10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path10.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file10_MouseLeave(object sender, EventArgs e)
        {
            if (file_path10.Text != "Add essay" && file_path10.Text != "Add report" && file_path10.Text != "Add review" && file_path10.Text != "Add proposal" && file_path10.Text != "Add formal letter" && file_path10.Text != "Add informal letter") file10.BackgroundImage = Properties.Resources.file_storage1;
            file_path10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path10.ForeColor = Color.Black;
        }

        private void file11_MouseEnter(object sender, EventArgs e)
        {
            if (file_path11.Text != "Add essay" && file_path11.Text != "Add report" && file_path11.Text != "Add review" && file_path11.Text != "Add proposal" && file_path11.Text != "Add formal letter" && file_path11.Text != "Add informal letter") file11.BackgroundImage = Properties.Resources.file_storage2;
            file_path11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path11.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file11_MouseLeave(object sender, EventArgs e)
        {
            if (file_path11.Text != "Add essay" && file_path11.Text != "Add report" && file_path11.Text != "Add review" && file_path11.Text != "Add proposal" && file_path11.Text != "Add formal letter" && file_path11.Text != "Add informal letter") file11.BackgroundImage = Properties.Resources.file_storage1;
            file_path11.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path11.ForeColor = Color.Black;
        }

        private void file12_MouseEnter(object sender, EventArgs e)
        {
            if (file_path12.Text != "Add essay" && file_path12.Text != "Add report" && file_path12.Text != "Add review" && file_path12.Text != "Add proposal" && file_path12.Text != "Add formal letter" && file_path12.Text != "Add informal letter") file12.BackgroundImage = Properties.Resources.file_storage2;
            file_path12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14, System.Drawing.FontStyle.Underline);
            file_path12.ForeColor = Color.FromArgb(57, 68, 122);
        }

        private void file12_MouseLeave(object sender, EventArgs e)
        {
            if (file_path12.Text != "Add essay" && file_path12.Text != "Add report" && file_path12.Text != "Add review" && file_path12.Text != "Add proposal" && file_path12.Text != "Add formal letter" && file_path12.Text != "Add informal letter") file12.BackgroundImage = Properties.Resources.file_storage1;
            file_path12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14);
            file_path12.ForeColor = Color.Black;
        }



        private void trash_MouseEnter(object sender, EventArgs e)
        {
            trash.BackgroundImage = Properties.Resources.bin_two; message.Visible = true;
        }

        private void trash_MouseLeave(object sender, EventArgs e)
        {
            trash.BackgroundImage = Properties.Resources.bin_one; message.Visible = false;
        }









        private void logo1_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Nature";
        }



        private void logo2_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Animals";
        }



        private void logo3_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Body";
        }



        private void logo4_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Health";
        }

        private void panel_vocabulary_Paint(object sender, PaintEventArgs e)
        {

        }



        private void logo5_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Household";
        }


        private void logo6_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Food";
        }



        private void logo7_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "City";

        }


        private void logo8_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Travel";
        }

        private void logo9_Click(object sender, EventArgs e)
        {
            panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "basic words"; cb1.Text = "Other";
        }

        private void nouns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_grammar.Visible = panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "nouns"; poz = 1; navigare();
        }

        private void pronouns_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_grammar.Visible = panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "pronouns"; poz = 1; navigare();
        }

        private void verbs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_grammar.Visible = panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "verbs"; poz = 1; navigare();
        }

        private void adverbs_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_grammar.Visible = panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "adverbs"; poz = 1; navigare();
        }

        private void Idioms_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            panel_grammar.Visible = panel_vocabulary.Visible = false;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            q = "idioms"; poz = 1; navigare();
        }

        private void file1_Click(object sender, EventArgs e)
        {
            input = file_path1.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file2_Click(object sender, EventArgs e)
        {
            input = file_path2.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file3_Click(object sender, EventArgs e)
        {
            input = file_path3.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }



        private void file4_Click(object sender, EventArgs e)
        {
            input = file_path4.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file5_Click(object sender, EventArgs e)
        {
            input = file_path5.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file6_Click(object sender, EventArgs e)
        {
            input = file_path6.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file7_Click(object sender, EventArgs e)
        {
            input = file_path7.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file8_Click(object sender, EventArgs e)
        {
            input = file_path8.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file9_Click(object sender, EventArgs e)
        {
            input = file_path9.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file10_Click(object sender, EventArgs e)
        {
            input = file_path10.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file11_Click(object sender, EventArgs e)
        {
            input = file_path11.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }

        private void file12_Click(object sender, EventArgs e)
        {
            input = file_path12.Text;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            search();
        }
        private void exit3_Click(object sender, EventArgs e)
        {

            panel_theory.Visible = true;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
        }

        private void exit2_Click(object sender, EventArgs e)
        {
            panel_theory.Visible = true;
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
        }

        private void paper_sheet_Click(object sender, EventArgs e)
        {

            if (paper_sheet.ReadOnly == true)
            {
                paper_sheet.Text = ""; paper_sheet.ReadOnly = false; paper_sheet.ForeColor = Color.FromArgb(57, 68, 122);
                switch(input)
                {
                    case "essay 1":
                        Properties.Settings.Default.essay1 = "";
                        break;
                    case "essay 2":
                        Properties.Settings.Default.essay2 = "";
                        break;
                    case "essay 3":
                        Properties.Settings.Default.essay3 = "";
                        break;
                    case "essay 4":
                        Properties.Settings.Default.essay4 = "";
                        break;
                    case "essay 5":
                        Properties.Settings.Default.essay5 = "";
                        break;
                    case "essay 6":
                        Properties.Settings.Default.essay6 = "";
                        break;
                    case "essay 7":
                        Properties.Settings.Default.essay7 = "";
                        break;
                    case "essay 8":
                        Properties.Settings.Default.essay8 = "";
                        break;
                    case "essay 9":
                        Properties.Settings.Default.essay9 = "";
                        break;
                    case "essay 10":
                        Properties.Settings.Default.essay10 = "";
                        break;
                    case "essay 11":
                        Properties.Settings.Default.essay11 = "";
                        break;
                    case "essay 12":
                        Properties.Settings.Default.essay12 = "";
                        break;
                    case "report 1":
                        Properties.Settings.Default.report1 = "";
                        break;
                    case "report 2":
                        Properties.Settings.Default.report2 = "";
                        break;
                    case "report 3":
                        Properties.Settings.Default.report3 = "";
                        break;
                    case "report 4":
                        Properties.Settings.Default.report4 = "";
                        break;
                    case "report 5":
                        Properties.Settings.Default.report5 = "";
                        break;
                    case "report 6":
                        Properties.Settings.Default.report6 = "";
                        break;
                    case "report 7":
                        Properties.Settings.Default.report7 = "";
                        break;
                    case "report 8":
                        Properties.Settings.Default.report8 = "";
                        break;
                    case "report 9":
                        Properties.Settings.Default.report9 = "";
                        break;
                    case "report 10":
                        Properties.Settings.Default.report10 = "";
                        break;
                    case "report 11":
                        Properties.Settings.Default.report11 = "";
                        break;
                    case "report 12":
                        Properties.Settings.Default.report12 = "";
                        break;
                    case "review 1":
                        Properties.Settings.Default.review1 = "";
                        break;
                    case "review 2":
                        Properties.Settings.Default.review2 = "";
                        break;
                    case "review 3":
                        Properties.Settings.Default.review3 = "";
                        break;
                    case "review 4":
                        Properties.Settings.Default.review4 = "";
                        break;
                    case "review 5":
                        Properties.Settings.Default.review5 = "";
                        break;
                    case "review 6":
                        Properties.Settings.Default.review6 = "";
                        break;
                    case "review 7":
                        Properties.Settings.Default.review7 = "";
                        break;
                    case "review 8":
                        Properties.Settings.Default.review8 = "";
                        break;
                    case "review 9":
                        Properties.Settings.Default.review9 = "";
                        break;
                    case "review 10":
                        Properties.Settings.Default.review10 = "";
                        break;
                    case "review 11":
                        Properties.Settings.Default.review11 = "";
                        break;
                    case "review 12":
                        Properties.Settings.Default.review12 = "";
                        break;
                    case "proposal 1":
                        Properties.Settings.Default.proposal1 = "";
                        break;
                    case "proposal 2":
                        Properties.Settings.Default.proposal2 = "";
                        break;
                    case "proposal 3":
                        Properties.Settings.Default.proposal3 = "";
                        break;
                    case "proposal 4":
                        Properties.Settings.Default.proposal4 = "";
                        break;
                    case "proposal 5":
                        Properties.Settings.Default.proposal5 = "";
                        break;
                    case "proposal 6":
                        Properties.Settings.Default.proposal6 = "";
                        break;
                    case "proposal 7":
                        Properties.Settings.Default.proposal7 = "";
                        break;
                    case "proposal 8":
                        Properties.Settings.Default.proposal8 = "";
                        break;
                    case "proposal 9":
                        Properties.Settings.Default.proposal9 = "";
                        break;
                    case "proposal 10":
                        Properties.Settings.Default.proposal10 = "";
                        break;
                    case "proposal 11":
                        Properties.Settings.Default.proposal11 = "";
                        break;
                    case "proposal 12":
                        Properties.Settings.Default.proposal12 = "";
                        break;
                    case "formal letter 1":
                        Properties.Settings.Default.formal_letter1 = "";
                        break;
                    case "formal letter 2":
                        Properties.Settings.Default.formal_letter2 = "";
                        break;
                    case "formal letter 3":
                        Properties.Settings.Default.formal_letter3 = "";
                        break;
                    case "formal letter 4":
                        Properties.Settings.Default.formal_letter4 = "";
                        break;
                    case "formal letter 5":
                        Properties.Settings.Default.formal_letter5 = "";
                        break;
                    case "formal letter 6":
                        Properties.Settings.Default.formal_letter6 = "";
                        break;
                    case "formal letter 7":
                        Properties.Settings.Default.formal_letter7 = "";
                        break;
                    case "formal letter 8":
                        Properties.Settings.Default.formal_letter8 = "";
                        break;
                    case "formal letter 9":
                        Properties.Settings.Default.formal_letter9 = "";
                        break;
                    case "formal letter 10":
                        Properties.Settings.Default.formal_letter10 = "";
                        break;
                    case "formal letter 11":
                        Properties.Settings.Default.formal_letter11 = "";
                        break;
                    case "formal letter 12":
                        Properties.Settings.Default.formal_letter12 = "";
                        break;
                    case "informal letter 1":
                        Properties.Settings.Default.informal_letter1 = "";
                        break;
                    case "informal letter 2":
                        Properties.Settings.Default.informal_letter2 = "";
                        break;
                    case "informal letter 3":
                        Properties.Settings.Default.informal_letter3 = "";
                        break;
                    case "informal letter 4":
                        Properties.Settings.Default.informal_letter4 = "";
                        break;
                    case "informal letter 5":
                        Properties.Settings.Default.informal_letter5 = "";
                        break;
                    case "informal letter 6":
                        Properties.Settings.Default.informal_letter6 = "";
                        break;
                    case "informal letter 7":
                        Properties.Settings.Default.informal_letter7 = "";
                        break;
                    case "informal letter 8":
                        Properties.Settings.Default.informal_letter8 = "";
                        break;
                    case "informal letter 9":
                        Properties.Settings.Default.informal_letter9 = "";
                        break;
                    case "informal letter 10":
                        Properties.Settings.Default.informal_letter10 = "";
                        break;
                    case "informal letter 11":
                        Properties.Settings.Default.informal_letter11 = "";
                        break;
                    case "informal letter 12":
                        Properties.Settings.Default.informal_letter12 = "";
                        break;

                    default:
                        break;
                }
                Properties.Settings.Default.Save();

            }
        }

        private void trash_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            message.Visible = trash.Visible = download.Visible = false;
            switch (input)
            {
                case "Your essays":
                    Properties.Settings.Default.essay1 = Properties.Settings.Default.essay2 = Properties.Settings.Default.essay3 = Properties.Settings.Default.essay4 = Properties.Settings.Default.essay5 = Properties.Settings.Default.essay6 = Properties.Settings.Default.essay7 = Properties.Settings.Default.essay8 = Properties.Settings.Default.essay9 = Properties.Settings.Default.essay10 = Properties.Settings.Default.essay11 = Properties.Settings.Default.essay12 = "";
                    Properties.Settings.Default.nr_essays = 0;
                    break;
                case "Your reports":
                    Properties.Settings.Default.report1 = Properties.Settings.Default.report2 = Properties.Settings.Default.report3 = Properties.Settings.Default.report4 = Properties.Settings.Default.report5 = Properties.Settings.Default.report6 = Properties.Settings.Default.report7 = Properties.Settings.Default.report8 = Properties.Settings.Default.report9 = Properties.Settings.Default.report10 = Properties.Settings.Default.report11 = Properties.Settings.Default.report12 = "";
                    Properties.Settings.Default.nr_reports = 0;
                    break;
                case "Your reviews":
                    Properties.Settings.Default.review1 = Properties.Settings.Default.review2 = Properties.Settings.Default.review3 = Properties.Settings.Default.review4 = Properties.Settings.Default.review5 = Properties.Settings.Default.review6 = Properties.Settings.Default.review7 = Properties.Settings.Default.review8 = Properties.Settings.Default.review9 = Properties.Settings.Default.review10 = Properties.Settings.Default.review11 = Properties.Settings.Default.review12 = "";
                    Properties.Settings.Default.nr_reviews = 0;
                    break;
                case "Your proposals":
                    Properties.Settings.Default.proposal1 = Properties.Settings.Default.proposal2 = Properties.Settings.Default.proposal3 = Properties.Settings.Default.proposal4 = Properties.Settings.Default.proposal5 = Properties.Settings.Default.proposal6 = Properties.Settings.Default.proposal7 = Properties.Settings.Default.proposal8 = Properties.Settings.Default.proposal9 = Properties.Settings.Default.proposal10 = Properties.Settings.Default.proposal11 = Properties.Settings.Default.proposal12 = "";
                    Properties.Settings.Default.nr_proposals = 0;
                    break;
                case "Your formal letters":
                    Properties.Settings.Default.formal_letter1 = Properties.Settings.Default.formal_letter2 = Properties.Settings.Default.formal_letter3 = Properties.Settings.Default.formal_letter4 = Properties.Settings.Default.formal_letter5 = Properties.Settings.Default.formal_letter6 = Properties.Settings.Default.formal_letter7 = Properties.Settings.Default.formal_letter8 = Properties.Settings.Default.formal_letter9 = Properties.Settings.Default.formal_letter10 = Properties.Settings.Default.formal_letter11 = Properties.Settings.Default.formal_letter12 = "";
                    Properties.Settings.Default.nr_formal_letters = 0;
                    break;
                case "Your informal letters":
                    Properties.Settings.Default.informal_letter1 = Properties.Settings.Default.informal_letter2 = Properties.Settings.Default.informal_letter3 = Properties.Settings.Default.informal_letter4 = Properties.Settings.Default.informal_letter5 = Properties.Settings.Default.informal_letter6 = Properties.Settings.Default.informal_letter7 = Properties.Settings.Default.informal_letter8 = Properties.Settings.Default.informal_letter9 = Properties.Settings.Default.informal_letter10 = Properties.Settings.Default.informal_letter11 = Properties.Settings.Default.informal_letter12 = "";
                    Properties.Settings.Default.nr_informal_letters = 0;
                    break;
                default:
                    break;
            }
            Properties.Settings.Default.Save();
            search();
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void create_word_doc(string numele ,string titlul, string textul)
        {
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Microsoft.Office.Interop.Word.Document doc = wordApp.Documents.Add();

            // Add a title with Times New Roman font, size 20
            Microsoft.Office.Interop.Word.Paragraph title = doc.Content.Paragraphs.Add();
            title.Range.Text = titlul; // titlul documentului
            title.Range.Font.Name = "Times New Roman";
            title.Range.Font.Size = 20;
            title.Range.Underline = WdUnderline.wdUnderlineSingle;
            title.Range.Bold = 1;
            title.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter;
            title.Range.InsertParagraphAfter();

            // Add a text paragraph with Arial font, size 11
            Paragraph text = doc.Content.Paragraphs.Add();
            text.Range.Text = "\n" + textul; // textul documentului
            text.Range.Font.Name = "Arial";
            text.Range.Font.Size = 11;
            text.Range.Underline = WdUnderline.wdUnderlineNone;
            text.Range.Bold = 0;
            text.Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft;
            text.Range.InsertParagraphAfter();

            // Save the document to the Downloads folder of the user
            string downloadsPath = Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + @"\Downloads\";
            string fileName = numele;  // numele fisierului worrd
            doc.SaveAs2(downloadsPath + fileName);

            doc.Close();
            wordApp.Quit();
        }

        public void Alert(string msg)
        {
            Form_Alert frm = new Form_Alert();
            frm.showAlert(msg);
        }

        private void download_Click(object sender, EventArgs e)
        {
            MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
            string numele, titlul, textul;

            Properties.Settings.Default.nr_docs_descarcate = 0;

            if (input == "Your essays" || input == "essay 1" || input == "essay 2" || input == "essay 3" || input == "essay 4" || input == "essay 5" || input == "essay 6" || input == "essay 7" || input == "essay 8" || input == "essay 9" || input == "essay 10" || input == "essay 11" || input == "essay 12")
            {
                if ((Properties.Settings.Default.nr_essays >= 1 && input == "Your essays") || input == "essay 1") // primul eseu
                {

                    numele = "essay_1.docx"; titlul = "Essay 1"; textul = Properties.Settings.Default.essay1;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc1 = numele;

                }

                if ((Properties.Settings.Default.nr_essays >= 2 && input == "Your essays") || input == "essay 2") // al doilea eseu
                {

                    numele = "essay_2.docx"; titlul = "Essay 2"; textul = Properties.Settings.Default.essay2;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc2 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 3 && input == "Your essays") || input == "essay 3") // al treilea eseu
                {

                    numele = "essay_3.docx"; titlul = "Essay 3"; textul = Properties.Settings.Default.essay3;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc3 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 4 && input == "Your essays") || input == "essay 4") // al patrulea eseu
                {

                    numele = "essay_4.docx"; titlul = "Essay 4"; textul = Properties.Settings.Default.essay4;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc4 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 5 && input == "Your essays") || input == "essay 5") // al cincilea eseu
                {

                    numele = "essay_5.docx"; titlul = "Essay 5"; textul = Properties.Settings.Default.essay5;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc5 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 6 && input == "Your essays") || input == "essay 6") // al saselea eseu
                {

                    numele = "essay_6.docx"; titlul = "Essay 6"; textul = Properties.Settings.Default.essay6;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc6 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 7 && input == "Your essays") || input == "essay 7") // al saptelea eseu
                {

                    numele = "essay_7.docx"; titlul = "Essay 7"; textul = Properties.Settings.Default.essay7;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc7 = numele;

                }

                if ((Properties.Settings.Default.nr_essays >= 8 && input == "Your essays") || input == "essay 8") // al optulea eseu
                {

                    numele = "essay_8.docx"; titlul = "Essay 8"; textul = Properties.Settings.Default.essay8;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc8 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 9 && input == "Your essays") || input == "essay 9") // al noualea eseu
                {

                    numele = "essay_9.docx"; titlul = "Essay 9"; textul = Properties.Settings.Default.essay9;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc9 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 10 && input == "Your essays") || input == "essay 10") // al zecelea eseu
                {

                    numele = "essay_10.docx"; titlul = "Essay 10"; textul = Properties.Settings.Default.essay10;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc10 = numele;
                }

                if ((Properties.Settings.Default.nr_essays >= 11 && input == "Your essays") || input == "essay 11") // al unsprezecelea eseu
                {

                    numele = "essay_11.docx"; titlul = "Essay 11"; textul = Properties.Settings.Default.essay11;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc11 = numele;
                }

                if ((Properties.Settings.Default.nr_essays == 12 && input == "Your essays") || input == "essay 12") // al doisprezecelea eseu
                {

                    numele = "essay_12.docx"; titlul = "Essay 12"; textul = Properties.Settings.Default.essay12;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc12 = numele;
                }


            }
            if (input == "Your reports" || input == "report 1" || input == "report 2" || input == "report 3" || input == "report 4" || input == "report 5" || input == "report 6" || input == "report 7" || input == "report 8" || input == "report 9" || input == "report 10" || input == "report 11" || input == "report 12")
            {
                if ((Properties.Settings.Default.nr_reports >= 1 && input == "Your reports") || input == "report 1") // primul report
                {

                    numele = "report_1.docx"; titlul = "Report 1"; textul = Properties.Settings.Default.report1;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc1 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 2 && input == "Your reports") || input == "report 2") // al doilea report
                {

                    numele = "report_2.docx"; titlul = "Report 2"; textul = Properties.Settings.Default.report2;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc2 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 3 && input == "Your reports") || input == "report 3") // al treilea report
                {

                    numele = "report_3.docx"; titlul = "Report 3"; textul = Properties.Settings.Default.report3;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc3 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 4 && input == "Your reports") || input == "report 4") // al patrulea report
                {

                    numele = "report_4.docx"; titlul = "Report 4"; textul = Properties.Settings.Default.report4;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc4 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 5 && input == "Your reports") || input == "report 5") // al cincilea report
                {

                    numele = "report_5.docx"; titlul = "Report 5"; textul = Properties.Settings.Default.report5;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc5 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 6 && input == "Your reports") || input == "report 6") // al saselea report
                {

                    numele = "report_6.docx"; titlul = "Report 6"; textul = Properties.Settings.Default.report6;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc6 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 7 && input == "Your reports") || input == "report 7") // al saptelea report
                {

                    numele = "report_7.docx"; titlul = "Report 7"; textul = Properties.Settings.Default.report7;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc7 = numele;

                }

                if ((Properties.Settings.Default.nr_reports >= 8 && input == "Your reports") || input == "report 8") // al optulea report
                {

                    numele = "report_8.docx"; titlul = "Report 8"; textul = Properties.Settings.Default.report8;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc8 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 9 && input == "Your reports") || input == "report 9") // al noualea report
                {

                    numele = "report_9.docx"; titlul = "Report 9"; textul = Properties.Settings.Default.report9;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc9 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 10 && input == "Your reports") || input == "report 10") // al zecelea report
                {

                    numele = "report_10.docx"; titlul = "Report 10"; textul = Properties.Settings.Default.report10;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc10 = numele;
                }

                if ((Properties.Settings.Default.nr_reports >= 11 && input == "Your reports") || input == "report 11") // al unsprezecelea report
                {

                    numele = "report_11.docx"; titlul = "Report 11"; textul = Properties.Settings.Default.report11;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc11 = numele;
                }

                if ((Properties.Settings.Default.nr_reports == 12 && input == "Your reports") || input == "report 12") // al doisprezecelea report
                {

                    numele = "report_12.docx"; titlul = "Report 12"; textul = Properties.Settings.Default.report12;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc12 = numele;
                }


            }
            else if (input == "Your reviews" || input == "review 1" || input == "review 2" || input == "review 3" || input == "review 4" || input == "review 5" || input == "review 6" || input == "review 7" || input == "review 8" || input == "review 9" || input == "review 10" || input == "review 11" || input == "review 12")
            {
                if ((Properties.Settings.Default.nr_reviews >= 1 && input == "Your reviews") || input == "review 1") // primul review
                {

                    numele = "review_1.docx"; titlul = "Review 1"; textul = Properties.Settings.Default.review1;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc1 = numele;

                }

                if ((Properties.Settings.Default.nr_reviews >= 2 && input == "Your reviews") || input == "review 2") // al doilea review
                {

                    numele = "review_2.docx"; titlul = "Review 2"; textul = Properties.Settings.Default.review2;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc2 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 3 && input == "Your reviews") || input == "review 3") // al treilea review
                {

                    numele = "review_3.docx"; titlul = "Review 3"; textul = Properties.Settings.Default.review3;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc3 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 4 && input == "Your reviews") || input == "review 4") // al patrulea review
                {

                    numele = "review_4.docx"; titlul = "Review 4"; textul = Properties.Settings.Default.review4;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc4 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 5 && input == "Your reviews") || input == "review 5") // al cincilea review
                {

                    numele = "review_5.docx"; titlul = "Review 5"; textul = Properties.Settings.Default.review5;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc5 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 6 && input == "Your reviews") || input == "review 6") // al saselea review
                {

                    numele = "review_6.docx"; titlul = "Review 6"; textul = Properties.Settings.Default.review6;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc6 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 7 && input == "Your reviews") || input == "review 7") // al saptelea review
                {

                    numele = "review_7.docx"; titlul = "Review 7"; textul = Properties.Settings.Default.review7;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc7 = numele;

                }

                if ((Properties.Settings.Default.nr_reviews >= 8 && input == "Your reviews") || input == "review 8") // al optulea review
                {

                    numele = "review_8.docx"; titlul = "Review 8"; textul = Properties.Settings.Default.review8;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc8 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 9 && input == "Your reviews") || input == "review 9") // al noualea review
                {

                    numele = "review_9.docx"; titlul = "Review 9"; textul = Properties.Settings.Default.review9;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc9 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 10 && input == "Your reviews") || input == "review 10") // al zecelea review
                {

                    numele = "review_10.docx"; titlul = "Review 10"; textul = Properties.Settings.Default.review10;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc10 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews >= 11 && input == "Your reviews") || input == "review 11") // al unsprezecelea review
                {

                    numele = "review_11.docx"; titlul = "Review 11"; textul = Properties.Settings.Default.review11;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc11 = numele;
                }

                if ((Properties.Settings.Default.nr_reviews == 12 && input == "Your reviews") || input == "review 12") // al doisprezecelea review
                {

                    numele = "review_12.docx"; titlul = "Review 12"; textul = Properties.Settings.Default.review12;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc12 = numele;
                }


            }
            else if (input == "Your proposals" || input == "proposal 1" || input == "proposal 2" || input == "proposal 3" || input == "proposal 4" || input == "proposal 5" || input == "proposal 6" || input == "proposal 7" || input == "proposal 8" || input == "proposal 9" || input == "proposal 10" || input == "proposal 11" || input == "proposal 12")
            {
                if ((Properties.Settings.Default.nr_proposals >= 1 && input == "Your proposals") || input == "proposal 1") // primul proposal
                {

                    numele = "proposal_1.docx"; titlul = "Proposal 1"; textul = Properties.Settings.Default.proposal1;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc1 = numele;

                }

                if ((Properties.Settings.Default.nr_proposals >= 2 && input == "Your proposals") || input == "proposal 2") // al doilea proposal
                {

                    numele = "proposal_2.docx"; titlul = "Proposal 2"; textul = Properties.Settings.Default.proposal2;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc2 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 3 && input == "Your proposals") || input == "proposal 3") // al treilea proposal
                {

                    numele = "proposal_3.docx"; titlul = "Proposal 3"; textul = Properties.Settings.Default.proposal3;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc3 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 4 && input == "Your proposals") || input == "proposal 4") // al patrulea proposal
                {

                    numele = "proposal_4.docx"; titlul = "Proposal 4"; textul = Properties.Settings.Default.proposal4;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc4 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 5 && input == "Your proposals") || input == "proposal 5") // al cincilea proposal
                {

                    numele = "proposal_5.docx"; titlul = "Proposal 5"; textul = Properties.Settings.Default.proposal5;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc5 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 6 && input == "Your proposals") || input == "proposal 6") // al saselea proposal
                {

                    numele = "proposal_6.docx"; titlul = "Proposal 6"; textul = Properties.Settings.Default.proposal6;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc6 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 7 && input == "Your proposals") || input == "proposal 7") // al saptelea proposal
                {

                    numele = "proposal_7.docx"; titlul = "Proposal 7"; textul = Properties.Settings.Default.proposal7;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc7 = numele;

                }

                if ((Properties.Settings.Default.nr_proposals >= 8 && input == "Your proposals") || input == "proposal 8") // al optulea proposal
                {

                    numele = "proposal_8.docx"; titlul = "Proposal 8"; textul = Properties.Settings.Default.proposal8;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc8 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 9 && input == "Your proposals") || input == "proposal 9") // al noualea proposal
                {

                    numele = "proposal_9.docx"; titlul = "Proposal 9"; textul = Properties.Settings.Default.proposal9;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc9 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 10 && input == "Your proposals") || input == "proposal 10") // al zecelea proposal
                {

                    numele = "proposal_10.docx"; titlul = "Proposal 10"; textul = Properties.Settings.Default.proposal10;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc10 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals >= 11 && input == "Your proposals") || input == "proposal 11") // al unsprezecelea proposal
                {

                    numele = "proposal_11.docx"; titlul = "Proposal 11"; textul = Properties.Settings.Default.proposal11;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc11 = numele;
                }

                if ((Properties.Settings.Default.nr_proposals == 12 && input == "Your proposals") || input == "proposal 12") // al doisprezecelea proposal
                {

                    numele = "proposal_12.docx"; titlul = "Proposal 12"; textul = Properties.Settings.Default.proposal12;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc12 = numele;
                }


            }
            else if (input == "Your formal letters" || input == "formal letter 1" || input == "formal letter 2" || input == "formal letter 3" || input == "formal letter 4" || input == "formal letter 5" || input == "formal letter 6" || input == "formal letter 7" || input == "formal letter 8" || input == "formal letter 9" || input == "formal letter 10" || input == "formal letter 11" || input == "formal letter 12")
            {
                if ((Properties.Settings.Default.nr_formal_letters >= 1 && input == "Your formal letters") || input == "formal letter 1") // primul scrisoare formala
                {

                    numele = "formal_letter_1.docx"; titlul = "Formal letter 1"; textul = Properties.Settings.Default.essay1;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc1 = numele;

                }

                if ((Properties.Settings.Default.nr_formal_letters >= 2 && input == "Your formal letters") || input == "formal letter 2") // al doilea scrisoare formala
                {

                    numele = "formal_letter_2.docx"; titlul = "Formal letter 2"; textul = Properties.Settings.Default.essay2;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc2 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 3 && input == "Your formal letters") || input == "formal letter 3") // al treilea scrisoare formala
                {

                    numele = "formal_letter_3.docx"; titlul = "Formal letter 3"; textul = Properties.Settings.Default.essay3;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc3 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 4 && input == "Your formal letters") || input == "formal letter 4") // al patrulea scrisoare formala
                {

                    numele = "formal_letter_4.docx"; titlul = "Formal letter 4"; textul = Properties.Settings.Default.essay4;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc4 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 5 && input == "Your formal letters") || input == "formal letter 5") // al cincilea scrisoare formala
                {

                    numele = "formal_letter_5.docx"; titlul = "Formal letter 5"; textul = Properties.Settings.Default.essay5;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc5 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 6 && input == "Your formal letters") || input == "formal letter 6") // al saselea scrisoare formala
                {

                    numele = "formal_letter_6.docx"; titlul = "Formal letter 6"; textul = Properties.Settings.Default.essay6;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc6 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 7 && input == "Your formal letters") || input == "formal letter 7") // al saptelea scrisoare formala
                {

                    numele = "formal_letter_7.docx"; titlul = "Formal letter 7"; textul = Properties.Settings.Default.essay7;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc7 = numele;

                }

                if ((Properties.Settings.Default.nr_formal_letters >= 8 && input == "Your formal letters") || input == "formal letter 8") // al optulea scrisoare formala
                {

                    numele = "formal_letter_8.docx"; titlul = "Formal letter 8"; textul = Properties.Settings.Default.essay8;
                    create_word_doc(numele, titlul, textul);
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 9 && input == "Your formal letters") || input == "formal letter 9") // al noualea scrisoare formala
                {

                    numele = "formal_letter_9.docx"; titlul = "Formal letter 9"; textul = Properties.Settings.Default.essay9;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc9 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 10 && input == "Your formal letters") || input == "formal letter 10") // al zecelea scrisoare formala
                {

                    numele = "formal_letter_10.docx"; titlul = "Formal letter 10"; textul = Properties.Settings.Default.essay10;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc10 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters >= 11 && input == "Your formal letters") || input == "formal letter 11") // al unsprezecelea scrisoare formala
                {

                    numele = "formal_letter_11.docx"; titlul = "Formal letter 11"; textul = Properties.Settings.Default.essay11;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc11 = numele;
                }

                if ((Properties.Settings.Default.nr_formal_letters == 12 && input == "Your formal letters") || input == "formal letter 12") // al doisprezecelea scrisoare formala
                {

                    numele = "formal_letter_12.docx"; titlul = "Formal letter 12"; textul = Properties.Settings.Default.essay12;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc12 = numele;
                }

            } else if (input == "Your informal letters" || input == "informal letter 1" || input == "informal letter 2" || input == "informal letter 3" || input == "informal letter 4" || input == "informal letter 5" || input == "informal letter 6" || input == "informal letter 7" || input == "informal letter 8" || input == "informal letter 9" || input == "informal letter 10" || input == "informal letter 11" || input == "informal letter 12")
            {
                if ((Properties.Settings.Default.nr_informal_letters >= 1 && input == "Your informal letters") || input == "informal letter 1") // primul scrisoare informala
                {

                    numele = "informal_letter_1.docx"; titlul = "Informal letter 1"; textul = Properties.Settings.Default.essay1;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc1 = numele;

                }

                if ((Properties.Settings.Default.nr_informal_letters >= 2 && input == "Your informal letters") || input == "informal letter 2") // al doilea scrisoare informala
                {

                    numele = "informal_letter_2.docx"; titlul = "Informal letter 2"; textul = Properties.Settings.Default.essay2;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc2 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 3 && input == "Your informal letters") || input == "informal letter 3") // al treilea scrisoare informala
                {

                    numele = "informal_letter_3.docx"; titlul = "Informal letter 3"; textul = Properties.Settings.Default.essay3;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc3 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 4 && input == "Your informal letters") || input == "informal letter 4") // al patrulea scrisoare informala
                {

                    numele = "informal_letter_4.docx"; titlul = "Informal letter 4"; textul = Properties.Settings.Default.essay4;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc4 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 5 && input == "Your informal letters") || input == "informal letter 5") // al cincilea scrisoare informala
                {

                    numele = "informal_letter_5.docx"; titlul = "Informal letter 5"; textul = Properties.Settings.Default.essay5;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc5 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 6 && input == "Your informal letters") || input == "informal letter 6") // al saselea scrisoare informala
                {

                    numele = "informal_letter_6.docx"; titlul = "Informal letter 6"; textul = Properties.Settings.Default.essay6;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc6 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 7 && input == "Your informal letters") || input == "informal letter 7") // al saptelea scrisoare informala
                {

                    numele = "informal_letter_7.docx"; titlul = "Informal letter 7"; textul = Properties.Settings.Default.essay7;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc7 = numele;

                }

                if ((Properties.Settings.Default.nr_informal_letters >= 8 && input == "Your informal letters") || input == "informal letter 8") // al optulea scrisoare informala
                {

                    numele = "informal_letter_8.docx"; titlul = "Informal letter 8"; textul = Properties.Settings.Default.essay8;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc8 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 9 && input == "Your informal letters") || input == "informal letter 9") // al noualea scrisoare informala
                {

                    numele = "informal_letter_9.docx"; titlul = "Informal letter 9"; textul = Properties.Settings.Default.essay9;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc9 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 10 && input == "Your informal letters") || input == "informal letter 10") // al zecelea scrisoare informala
                {

                    numele = "informal_letter_10.docx"; titlul = "Informal letter 10"; textul = Properties.Settings.Default.essay10;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc10 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters >= 11 && input == "Your informal letters") || input == "informal letter 11") // al unsprezecelea scrisoare informala
                {

                    numele = "informal_letter_11.docx"; titlul = "Informal letter 11"; textul = Properties.Settings.Default.essay11;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc11 = numele;
                }

                if ((Properties.Settings.Default.nr_informal_letters == 12 && input == "Your informal letters") || input == "informal letter 12") // al doisprezecelea scrisoare informala
                {

                    numele = "informal_letter_12.docx"; titlul = "Informal letter 12"; textul = Properties.Settings.Default.essay12;
                    create_word_doc(numele, titlul, textul);
                    Properties.Settings.Default.nr_docs_descarcate++;
                    Properties.Settings.Default.doc12 = numele;
                }
            }
            Properties.Settings.Default.Save();

            this.Alert("notificare");

        }

        private void panel_theory_Paint(object sender, PaintEventArgs e)
        {

        }

        private void timer_slide_Tick(object sender, EventArgs e)
        {   
            if (funct == "next") this.ilslide.Left += 20;
            else this.ilslide.Left -= 20;
       
        }

        private void exit1_Click(object sender, EventArgs e)
        {
           MediaPlayer2.URL = URL_click; MediaPlayer2.controls.play();
           if (q == "basic words") panel_vocabulary.Visible = true;
           else if (q == "verbs" || q == "adverbs" || q == "nouns" || q == "pronouns" || q == "idioms" || q=="Phrasal verbs") panel_grammar.Visible =panel_vocabulary.Visible= true;
           else if(q=="essay"||q=="report"||q=="review"||q=="proposal"||q=="formal letter"||q=="informal letter")
           {
                panel_theory.Visible =panel_ilustratie.Visible=panel_grammar.Visible=panel_vocabulary.Visible= true;
                file1.Visible = file2.Visible = file3.Visible = file4.Visible = file5.Visible = file6.Visible = file7.Visible = file8.Visible = file9.Visible = file10.Visible = file11.Visible = file12.Visible = file_path1.Visible = file_path2.Visible = file_path3.Visible = file_path4.Visible = file_path5.Visible = file_path6.Visible = file_path7.Visible = file_path8.Visible = file_path9.Visible = file_path10.Visible = file_path11.Visible = file_path12.Visible = true;

                file_path1.Text = "Essay";
                file_path2.Text = "Report";
                file_path3.Text = "Review";
                file_path4.Text = "Proposal";
                file_path5.Text = "Formal letter";
                file_path6.Text = "Informal letter";

                file_path7.Text = "Your essays";
                file_path8.Text = "Your reports";
                file_path9.Text = "Your review";
                file_path10.Text = "Your proposals";
                file_path11.Text = "Your formal letters";
                file_path12.Text = "Your informal letters";
            }
        }

    }
}
