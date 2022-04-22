using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Linq;

namespace Curierat.Model.Persistenta
{
    public class ColetPersistent
    {
        public bool AdaugareColet(Colet med)
        {
            try
            {
                XElement xElement = XElement.Load(@"colete.xml");
                xElement.Add(new XElement("colet",
                    new XElement("cod_colet", med.AccesCodColet().ToString()),
                    new XElement("locatie", med.AccesLocatie()),
                    new XElement("curier", med.AccesCurier()),
                    new XElement("traseuoptim", med.AccesTraseuoptim())
                    ));
                xElement.Save(@"colete.xml");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la adaugare colet! " + ex.ToString());
                return false;
            }
        }

        public bool ActualizareColet(uint cod_colet, Colet med)
        {
            try
            {
                XDocument xDoc = XDocument.Load(@"colete.xml");
                var element = xDoc.Root.Elements("colet").Where(e => e.Element("cod_colet").Value == cod_colet.ToString()).Single();
                if (med.AccesCodColet().ToString() != "0") element.Element("cod_colet").Value = med.AccesCodColet().ToString();
                if (med.AccesLocatie() != "") element.Element("locatie").Value = med.AccesLocatie();
                if (med.AccesCurier() != "") element.Element("curier").Value = med.AccesCurier();
                if (med.AccesTraseuoptim() != "") element.Element("traseuoptim").Value = med.AccesTraseuoptim();
                xDoc.Save(@"colete.xml");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la actualizare colet! " + ex.ToString());
                return false;
            }
        }

        public bool StergereColet(uint cod_colet)
        {
            try
            {
                XDocument xDoc = XDocument.Load(@"colete.xml");
                xDoc.Root.Elements("colet").Where(e => e.Element("cod_colet").Value == cod_colet.ToString()).Remove();
                xDoc.Save(@"colete.xml");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la stergere colet! " + ex.ToString());
                return false;
            }
        }

        public Colet CautareColet(uint cod_colet)
        {
            try
            {
                XDocument xDoc = XDocument.Load(@"colete.xml");
                List<XElement> lista = xDoc.Root.Elements("colet").ToList();
                foreach (XElement xElem in lista)
                {
                    int cm = (int)Convert.ToUInt32(xElem.Element("cod_colet").Value);
                    if (cm == cod_colet)
                    {
                        string locatie = xElem.Element("locatie").Value;
                        string curier = xElem.Element("curier").Value;
                        string traseuoptim = xElem.Element("traseuoptim").Value;
                        Colet p = new Colet(cod_colet, locatie, curier, traseuoptim);
                        return p;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la cautare colet! " + ex.ToString());
                return null;
            }
        }




        public List<Colet> CautareColeteNumar(string txtCautare)
        {
            try
            {
                List<Colet> listaColete = new List<Colet>();
                XDocument xDoc = XDocument.Load(@"colete.xml");
                List<XElement> listaXML = xDoc.Root.Elements("colet").ToList();
                foreach (XElement xElem in listaXML)
                {

                    string denum = xElem.Element("cod_colet").Value;
                    if (denum == txtCautare)
                    {

                        uint cod_colet = Convert.ToUInt32(xElem.Element("cod_colet").Value);
                        string locatie = xElem.Element("locatie").Value;
                        string curier = xElem.Element("curier").Value;
                        string traseuoptim = xElem.Element("traseuoptim").Value;
                        Colet m = new Colet(cod_colet, locatie, curier, traseuoptim);
                        listaColete.Add(m);
                    }
                }
                return listaColete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la filtrare patinatori! " + ex.ToString());
                return null;
            }

        }












    public List<Colet> ListaColete()
        {
            try
            {
                List<Colet> listaColete = new List<Colet>();
                XDocument xDoc = XDocument.Load(@"colete.xml");
                List<XElement> listaXML = xDoc.Root.Elements("colet").ToList();
                foreach (XElement xElem in listaXML)
                {
                    
                    uint cod_colet = Convert.ToUInt32(xElem.Element("cod_colet").Value);
                    string locatie = xElem.Element("locatie").Value;
                    string curier = xElem.Element("curier").Value;
                    string traseuoptim = xElem.Element("traseuoptim").Value;
                    Colet m = new Colet(cod_colet, locatie, curier, traseuoptim);
                    listaColete.Add(m);
                }
                return listaColete;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Eroare la citire colete! " + ex.ToString());
                return null;
            }
        }


        
             
        

       
        }
    }

