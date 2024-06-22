﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace exchange_application
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            string today = "https://www.tcmb.gov.tr/kurlar/today.xml";
            var XmlDosya = new XmlDocument();
            XmlDosya.Load(today);

            string dolarAlis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteBuying").InnerXml;
            lblDolarAlis.Text = dolarAlis;

            string dolarSatis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
            lblDolarSatis.Text = dolarSatis;

            string euroAlis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteBuying").InnerXml;
            lblEuroAlis.Text = euroAlis;

            string euroSatis = XmlDosya.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
            lblEuroSatis.Text = euroSatis;
        }

        private void btndolarAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarAlis.Text;
        }

        private void btndolarSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblDolarSatis.Text;
        }

        private void btneuroAl_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroAlis.Text;
        }

        private void btneuroSat_Click(object sender, EventArgs e)
        {
            txtKur.Text = lblEuroSatis.Text;
        }

        private void btnDovizAl_Click(object sender, EventArgs e)
        {
            double kur, miktar, tutar;

            kur = Convert.ToDouble(txtKur.Text);
            miktar = Convert.ToDouble(txtMiktar.Text);
            tutar = kur * miktar;

            txtTutar.Text = tutar.ToString();

        }

        private void btnHepsiAl_Click(object sender, EventArgs e)
        {
            double kur = Convert.ToDouble(txtKur.Text);
            int miktar = Convert.ToInt32(txtMiktar.Text);
            int tutar = Convert.ToInt32(miktar / kur);
            txtTutar.Text = tutar.ToString();

            double kalan;
            kalan = miktar % kur;
            txtKalan.Text = kalan.ToString();
        }
    }
}
