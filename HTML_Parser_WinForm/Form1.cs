using System;
using HtmlAgilityPack;
using System.Net;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Linq;

namespace HTML_Parser_WinForm
{
    public partial class Form1 : Form
    {
        ScraperCategories scraper;
        ScraperSubCategories subscraper;
        ScraperProducts products_scraper;

        int rowIndex;

        List<EntryModel> categories = new List<EntryModel>();
        List<ProductModel> subcategories = new List<ProductModel>();
        List<ProductModel> sublist = new List<ProductModel>();
        List<EntryModel> products = new List<EntryModel>();

        List<DataAllo> data = new List<DataAllo>();

        public Form1()
        {
            InitializeComponent();
            scraper = new ScraperCategories();
            subscraper = new ScraperSubCategories();
            products_scraper = new ScraperProducts();
            categories.Clear();

            ShowProducts.Enabled = false;
            ShowProducts.Visible = false;

            ShowProducts.Enabled = false;
            ShowProducts.Visible = false;

            Back.Enabled = false;
            Back.Visible = false;

            categories = scraper.ScrapeData("https://allo.ua/ru/");

            ShowData(categories);
            foreach (var item in categories)
            {
                data.Add(new DataAllo { Title = item.Title, Url = item.Url });
            }
            return;
        }

        private void ToMain_Click(object sender, EventArgs e)
        {
            ShowData(categories);
            ShowProducts.Enabled = false;
            ShowProducts.Visible = false;
            Next.Enabled = true;
            Next.Visible = true;
            subcategories.Clear();
            products.Clear();
            rowIndex = 0;
            Back.Enabled = false;
            Back.Visible = false;
        }

        private void GetProducts_Click(object sender, EventArgs e)
        {
            if (subscraper.CheckSubCategories(data[rowIndex].subcategories[DataView.CurrentCell.RowIndex].Url))
            {
                // subcategories = data[rowIndex].subcategories;
                data[rowIndex].subcategories.AddRange(subscraper.ScrapeData(data[rowIndex].subcategories[DataView.CurrentCell.RowIndex].Url));

                //  data[rowIndex].subcategories.RemoveAt(DataView.CurrentCell.RowIndex);

                // data[rowIndex].subcategories = subcategories;

                // ShowDataProd(data[rowIndex].subcategories);
                sublist = subcategories;
                ShowDataProd(sublist);

            }
            else
            {
                products = products_scraper.ScrapeData(data[rowIndex].subcategories[DataView.CurrentCell.RowIndex].Url);
                //data[rowIndex].subcategories[DataView.CurrentCell.RowIndex].products = products;

                ShowData(products);

                ShowProducts.Enabled = false;
                ShowProducts.Visible = false;
            }
        }

        public void ShowDataProd(List<ProductModel> list)
        {
            DataView.Columns.Clear();
            DataView.DataSource = list;
            DataView.Refresh();
            DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        public void ShowData(List<EntryModel> list)
        {
            DataView.Columns.Clear();
            DataView.DataSource = list;
            DataView.Refresh();
            DataView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void Next_Click(object sender, EventArgs e)
        {
            Back.Enabled = true;
            Back.Visible = true;
            rowIndex = DataView.CurrentCell.RowIndex;

            DataView.Columns.Clear();
            subcategories = subscraper.ScrapeData(categories[rowIndex].Url);

            if (subcategories.Count != 0)
            {
                data[rowIndex].subcategories = subcategories;
                ShowDataProd(data[rowIndex].subcategories);
                //DataView.DataSource = data[rowIndex].subcategories;

                ShowProducts.Visible = true;
                ShowProducts.Enabled = true;
            }

            if (subcategories.Count == 0)
                ShowData(categories);

            Next.Enabled = false;
            Next.Visible = false;
        }
    }
}
