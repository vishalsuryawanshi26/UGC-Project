using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace HardwareShopManagement
{
    class ValidationUtil
    {
        public static ErrorProvider errorProvider1;
       //rules==> Empty Integer CharsSpaces
        public static void ApplyRules(TextBox txt, String field,String[] rules)
        {
            txt.Validating += (sender, e) =>    //Lambda Expression/Linq Expression
            {
                foreach(string rule in rules)
                {
                    switch(rule)
                    {
                        case "Empty":
                     if (string.IsNullOrEmpty(txt.Text))
                    {
                        errorProvider1.SetError(txt, field +" cannot be empty");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                    errorProvider1.SetError(txt, "");
                    e.Cancel = false;    //validation ok
                    }
                break;
                case "Integer":
                     if (!Regex.IsMatch(txt.Text,"^\\d+$"))       //bool Ismatch(input,pattern)
                    {
                        errorProvider1.SetError(txt,field+"must be integer");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        e.Cancel = false;   //validation ok
                    }
                    break;
                    case "CharsSpaces":
                    if (!Regex.IsMatch(txt.Text, "^[A-Za-z ]+$"))       
                    {
                        errorProvider1.SetError(txt,field+"Allows only chars and spaces");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        e.Cancel = false;   //validation ok
                    }
                    break;
                    case "Email":
                    if (!Regex.IsMatch(txt.Text, "^\\w+@\\w+\\.\\w{2,3}(\\.\\w{2,3})?$"))
                    {
                        errorProvider1.SetError(txt,"Invalid Email Id");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        e.Cancel = false;   //validation ok
                    }
                     break;
                    case "Mobile No":
                    if (!Regex.IsMatch(txt.Text, "^(\\+\\d{1,3})?\\d{10}$"))
                    {
                        errorProvider1.SetError(txt,"Invalid Format of Mobile Numbers");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        e.Cancel = false;   //validation ok
                    }
                    break;

                    case "Web":
                    if (!Regex.IsMatch(txt.Text, "(http://}?www\\.\\w+\\.\\w{2,3}(\\.\\w{2,3})?$"))
                    {
                        errorProvider1.SetError(txt, "Invalid format of WebSite");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        e.Cancel = false;   //validation ok
                    }
                    break;

                    case "Decimal":
                    if (!Regex.IsMatch(txt.Text, "^\\d+(\\.\\d{2})?$"))       //bool Ismatch(input,pattern)
                    {
                        errorProvider1.SetError(txt, field + "must be decimal");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        e.Cancel = false;   //validation ok
                    }
                    break;
                 }
                }
            };
        }

        public static void CheckCombo(ComboBox txt, String field)
        {
            txt.Validating += (sender, e) =>    //Lambda Expression/Linq Expression
            {
                if (string.IsNullOrEmpty(txt.Text))
                {
                    errorProvider1.SetError(txt, field+" cannot be empty");
                    e.Cancel = true;    //validation failed
                }
                else
                {
                    errorProvider1.SetError(txt, "");
                    e.Cancel = false;   //validation ok
                }
            };
        }
        public static void CheckDateBeforeCombo(DateTimePicker txt, String field,int years)
        {
            txt.Validating += (sender, e) =>    //Lambda Expression/Linq Expression
            {         
                     if (txt.Value>DateTime.Now.AddYears(-years))
                    {
                        errorProvider1.SetError(txt,field+"should be less than "+years+" year(s) current date");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(txt, "");
                        e.Cancel = false;   //validation ok
                    } 
            };
        }
        public static void CheckRadioButton(RadioButton[] rbs, String field)
        {
            System.ComponentModel.CancelEventHandler x =(sender,e) =>
            {
                int c=0;

            foreach(RadioButton rb in rbs)
            {
                if(!rb.Checked)
                {
                    c++;
                }
            }
            if (c==rbs.Length)
            {
                errorProvider1.SetError((RadioButton)sender,field+"cannot be empty");
                e.Cancel = true;    //validation failed
            }
            else
            {
                errorProvider1.SetError((RadioButton)sender, "");
                e.Cancel = false;   //validation ok
            }
         };
          foreach(RadioButton rb in rbs)
          {               
                rb.Validating += x ;
          }
   }   
             public static void CheckList(CheckedListBox lt, String field)
        {
            lt.Validating += (sender, e) =>    //Lambda Expression/Linq Expression
            {         
                     if (lt.CheckedItems.Count==0)
                    {
                        errorProvider1.SetError(lt,field+"cannot be empty");
                        e.Cancel = true;    //validation failed
                    }
                    else
                    {
                        errorProvider1.SetError(lt, "");
                        e.Cancel = false;   //validation ok
                    } 
            };
        }
             public static void disableValidationOnClose(Form f)
             {
                 f.FormClosing += new FormClosingEventHandler(f_FormClosing);
             }

             static void f_FormClosing(object sender, FormClosingEventArgs e)
             {
                 Form f = (Form)sender;
                 f.CausesValidation = false;
                 e.Cancel = false; 
             }
    }
}