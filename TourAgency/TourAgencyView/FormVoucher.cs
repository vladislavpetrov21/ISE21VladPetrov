using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TourAgencyBusinessLogic.BindingModels;
using TourAgencyBusinessLogic.Interfaces;
using TourAgencyBusinessLogic.ViewModels;
using Unity;

namespace TourAgencyView
{
    public partial class FormVoucher : Form
    {
        [Dependency]
        public new IUnityContainer Container { get; set; }
        public int Id { set { id = value; } }
        private readonly IVoucherLogic logic;
        private int? id;
        private Dictionary<int, (string, int)> voucherTours;
        public FormVoucher(IVoucherLogic service)
        {
            InitializeComponent();
            this.logic = service;
        }
        private void FormVoucher_Load(object sender, EventArgs e)
        {
            if (id.HasValue)
            {
                try
                {
                    VoucherViewModel view = logic.Read(new VoucherBindingModel
                    {
                        Id =
                   id.Value
                    })?[0];
                    if (view != null)
                    {
                        textBoxName.Text = view.VoucherName;
                        textBoxPrice.Text = view.Price.ToString();
                        voucherTours = view.VoucherTours;
                        LoadData();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                   MessageBoxIcon.Error);
                }
            }
            else
            {
                voucherTours = new Dictionary<int, (string, int)>();
            }
        }
        private void LoadData()
        {
            try
            {
                if (voucherTours != null)
                {
                    dataGridViewVoucher.Rows.Clear();
                    foreach (var pc in voucherTours)
                    {
                        dataGridViewVoucher.Rows.Add(new object[] { pc.Key, pc.Value.Item1,
                        pc.Value.Item2 });
                    }
                }
            }
            catch (Exception ex)
            {                
            MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
            MessageBoxIcon.Error);
            }
        }
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var form = Container.Resolve<FormVoucherTour>();
            if (form.ShowDialog() == DialogResult.OK)
            {
                if (voucherTours.ContainsKey(form.Id))
                {
                    voucherTours[form.Id] = (form.TourName, form.Count);
                }
                else
                {
                    voucherTours.Add(form.Id, (form.TourName, form.Count));
                }
                LoadData();
            }
        }
        private void ButtonUpd_Click(object sender, EventArgs e)
        {
            if (dataGridViewVoucher.SelectedRows.Count == 1)
            {
                var form = Container.Resolve<FormVoucherTour>();
                int id = Convert.ToInt32(dataGridViewVoucher.SelectedRows[0].Cells[0].Value);
                form.Id = id;
                form.Count = voucherTours[id].Item2;
                if (form.ShowDialog() == DialogResult.OK)
                {
                    voucherTours[form.Id] = (form.TourName, form.Count);
                    LoadData();
                }
            }
        }
        private void ButtonDel_Click(object sender, EventArgs e)
        {
            if (dataGridViewVoucher.SelectedRows.Count == 1)
            {
                if (MessageBox.Show("Удалить запись", "Вопрос", MessageBoxButtons.YesNo,
               MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {

                        voucherTours.Remove(Convert.ToInt32(dataGridViewVoucher.SelectedRows[0].Cells[0].Value));
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
                       MessageBoxIcon.Error);
                    }
                    LoadData();
                }
            }
        }
        private void ButtonRef_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBoxName.Text))
            {
                MessageBox.Show("Заполните название", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (string.IsNullOrEmpty(textBoxPrice.Text))
            {
                MessageBox.Show("Заполните цену", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            if (voucherTours == null || voucherTours.Count == 0)
            {
                MessageBox.Show("Заполните туры", "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
                return;
            }
            try
            {
                logic.CreateOrUpdate(new VoucherBindingModel
                {
                    Id = id,
                    VoucherName = textBoxName.Text,
                    Price = Convert.ToDecimal(textBoxPrice.Text),
                    VoucherTours = voucherTours
                });
                MessageBox.Show("Сохранение прошло успешно", "Сообщение",
               MessageBoxButtons.OK, MessageBoxIcon.Information);
                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK,
               MessageBoxIcon.Error);
            }
        }
        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
