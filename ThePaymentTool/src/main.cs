using System;
using System.Windows.Forms;
using System.IO;

namespace ACH_Decomp
{
    public partial class main : Form
    {
        public main()
        {
            InitializeComponent();
        }
        public void SaveFile() //ACH
        {
            var fileContent = string.Empty;
            var filePath = string.Empty;
            using (OpenFileDialog ofd = new OpenFileDialog())
            {
                ofd.InitialDirectory = "C:\\";
                ofd.Filter = "dat files (*.dat)|*.dat|All files (*.*)|*.*";
                ofd.FilterIndex = 1;
                ofd.RestoreDirectory = true;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    filePath = ofd.FileName;
                    SaveFileDialog sfd = new SaveFileDialog(); //put in own method to reuse with XML save
                    if (g == 1)
                    {
                        sfd.Filter = "JSON Files | *.json";
                        sfd.DefaultExt = "json";
                    } else if(g == 2)
                    {
                        sfd.Filter = "XML Files | *.xml";
                        sfd.DefaultExt = "xml";
                    } else if(g == 3)
                    {
                        sfd.Filter = "JSON Files | *.json";
                        sfd.DefaultExt = "json";
                    }
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        Path.GetFileName(sfd.FileName);
                        var fileStream = ofd.OpenFile();
                        using (StreamReader reader = new StreamReader(fileStream))
                        {
                            string line;
                            int counter = 0;
                            int PECount = 0;
                            int ADCount = 0;
                            Conversion c = new Conversion();
                            c.filepath = Path.GetFullPath(sfd.FileName);
                            c.g = g;
                            if (g == 1 || g == 2)
                            {
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line.Substring(0, 1).Contains("1"))
                                    {
                                        //File Header Record
                                        c.FHRConv(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 1).Contains("5"))
                                    {
                                        //Batch Header Record
                                        c.BHRConv(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 1).Contains("6"))
                                    {
                                        //Payment Entry
                                        PECount++;
                                        c.PECount = PECount;
                                        c.SECCheck(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 1).Contains("7"))
                                    {
                                        //Addenda Record
                                        ADCount++;
                                        c.ADCount = ADCount;
                                        c.ARConv(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 1).Contains("8"))
                                    {
                                        //Batch Control Record
                                        c.BCRConv(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 1).Contains("9"))
                                    {
                                        //File Control Record
                                        c.FCRConv(line);
                                        counter++;
                                    }
                                    else
                                    {
                                        throw new System.InvalidOperationException("Unknown line number. Raw line: \n" + line);
                                    }
                                }
                            } else if(g == 3)
                            {
                                while ((line = reader.ReadLine()) != null)
                                {
                                    if (line.Substring(0, 2).Contains("01"))
                                    {
                                        //File Header Record
                                        c.WIRE_FileHeader(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 2).Contains("02"))
                                    {
                                        //Group Header
                                        c.WIRE_GroupHeader(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 2).Contains("03"))
                                    {
                                        //Account Identifier and Summary Status
                                        PECount++;
                                        c.WIRE_AcctID(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 2).Contains("16"))
                                    {
                                        //Transaction Detail
                                        ADCount++;
                                        c.ADCount = ADCount;
                                        c.WIRE_TransDetail(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 2).Contains("88"))
                                    {
                                        //Continuation Record
                                        c.WIRE_Continuation(line);
                                        counter++;
                                    }
                                    else if (line.Substring(0, 2).Contains("49"))
                                    {
                                        //Account Trailer
                                        c.WIRE_AccountTrailer(line);
                                        counter++;
                                    } else if (line.Substring(0, 2).Contains("98"))
                                    {
                                        //Group Trailer
                                        c.WIRE_GroupTrailer(line);
                                        counter++;
                                    } else if (line.Substring(0, 2).Contains("99"))
                                    {
                                        //File Trailer
                                        c.WIRE_FileTrailer(line);
                                        counter++;
                                    }
                                    else
                                    {
                                        throw new System.InvalidOperationException("Unknown line number. Raw line: \n" + line);
                                    }
                                }

                            }
                            MessageBox.Show("Conversion Complete!", "Done!");
                        }
                    }
                }
            }

        }
        public int g { get; set; }
        private void btnJSON_Click(object sender, EventArgs e)
        {
            g = 1; //JSON
            SaveFile();
        }

        private void btnXML_Click(object sender, EventArgs e)
        {
            g = 2; //XML
            SaveFile();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnWIRE2JSON_Click(object sender, EventArgs e)
        {
            g = 3; //WIRE to JSON
            SaveFile();
        }

        private void checkBox1_CheckStateChanged(object sender, EventArgs e)
        {
            if (cbDebug.CheckState == CheckState.Checked)
            {
                btnWIRE2XML.Enabled = true;
                btnRebuild.Enabled = true;
                btnWIREREBUILD.Enabled = true;
                btnXML.Enabled = true;
            } else
            {
                btnWIRE2XML.Enabled = false;
                btnRebuild.Enabled = false;
                btnWIREREBUILD.Enabled = false;
                btnXML.Enabled = false;
            }
        }
    }
}
