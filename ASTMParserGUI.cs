/*
 * Valentin Heinitz, 2014-10-30 01:54
 * http://heinitz-it.de
 * Test gui for  ASTM-1394 parser. 
 */
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ASTMParser;


namespace ASTMViewer
{
    public partial class ASTMParserGUI : Form
    {
        public ASTMParserGUI()
        {
            InitializeComponent();
        }

        List<ASTM_Message> messages = new List<ASTM_Message>();
        


        void populateData(ASTM_Record r, TreeNode n, int fromIdx=1)
        {
            for (int fi = fromIdx; fi <= r.fieldsCount(); fi++)
            {
                if (r.fieldValue(fi) != null && r.fieldValue(fi).Length > 0)
                    n.Nodes.Add(r.fieldName(fi) + ":\t" + r.fieldValue(fi));
            }
            if (r.comments()!=null)
            {
                foreach (ASTM_Comment c in r.comments())
                {
                    TreeNode curCommentNode = n.Nodes.Add("Comment");
                    for (int fi = fromIdx; fi <= c.fieldsCount(); fi++)
                    {
                        if (c.fieldValue(fi) != null && c.fieldValue(fi).Length > 0)
                            curCommentNode.Nodes.Add(c.fieldName(fi) + ":\t" + c.fieldValue(fi));
                    }
                }
            }
            if (r.manufacturerInfo() != null)
            {
                foreach (ASTM_Manufacturer m in r.manufacturerInfo())
                {
                    TreeNode curManNode = n.Nodes.Add("Manufacturer Info");
                    for (int fi = fromIdx; fi <= m.fieldsCount(); fi++)
                    {
                        if (m.fieldValue(fi) != null && m.fieldValue(fi).Length > 0)
                            curManNode.Nodes.Add(m.fieldName(fi) + ":\t" + m.fieldValue(fi));
                    }
                }
            }
        }

        void populateData()
        {
            messagesData.Nodes.Clear();
            foreach (ASTM_Message m in messages)
            {
                TreeNode curMessageNode = messagesData.Nodes.Add("Message");
                populateData(m, curMessageNode, 3);

                foreach (ASTM_Patient p in m.patientRecords)
                {
                    TreeNode curPatientNode = curMessageNode.Nodes.Add("Patient");
                    populateData(p, curPatientNode, 3);

                    foreach (ASTM_Order o in p.orderRecords)
                    {
                        TreeNode curOrderNode = curPatientNode.Nodes.Add("Order");
                        populateData(o, curOrderNode, 3);

                        foreach (ASTM_Result r in o.resultRecords)
                        {
                            TreeNode curResultNode = curOrderNode.Nodes.Add("Result");
                            populateData(r, curResultNode, 3);
                        }
                    }
                }

                foreach (ASTM_Request q in m.requestRecords)
                {
                    TreeNode curRequestNode = curMessageNode.Nodes.Add("Request Order");
                    populateData(q, curRequestNode, 3);
                }

                foreach (ASTM_Scientific s in m.scientificRecords)
                {
                    TreeNode curScientificNode = curMessageNode.Nodes.Add("Scientific");
                    populateData(s, curScientificNode, 3);
                }
            }

            messagesData.ExpandAll();
        }

        public void clear()
        {
            messages.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            clear();
            Parser parser = new Parser();
            parser.parse(this.astmData.Text, ref messages);
            populateData();
        }
                   
    }
}
