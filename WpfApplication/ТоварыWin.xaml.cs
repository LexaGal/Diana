using System.Linq;
using System.Windows;
using Database;using Logics.Services;
using WpfApplication.Helpers;
namespace WpfApplication
{
    public partial class ТоварыWin : Window
    {
        private Товар prod;
        public ТоварыWin()
        {
            InitializeComponent();
            var autoServ = ServiceLocator.GetService<Товар>();
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var услуги = autoServ.ReadAll();
                услуги.ToList().ForEach(c => list_of_products.Items.Add(c));            
            }
        }
        private void back_Click(object sender, RoutedEventArgs e)
        {
            АвтозаправкаWin winTool = new АвтозаправкаWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            ТоварWin winTool = new ТоварWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
        private void button_Click(object sender, RoutedEventArgs e)
        {
            ЧекWin winTool = new ЧекWin();
            winTool.Owner = this;
            winTool.Show();
            this.Hide();
        }
        private void search_Click(object sender, RoutedEventArgs e)
        {
            var autoServ = ServiceLocator.GetService<Товар>() as ТоварService;
            var n = name_of_product.Text;
            using (autoServ.Uow.Db = new АвтозаправкиEntities())
            {
                var постоянныеклиенты = autoServ.ReadSome(n);
                list_of_products.Items.Clear();
                постоянныеклиенты.ToList().ForEach(c => list_of_products.Items.Add(c));            
            }
        }
        private void list_of_productsSelect(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                prod = e.AddedItems[0] as Товар;
                value.Text = prod.стоимость.Value.ToString();
                amount_of_goods.Text = prod.количесвто.Value.ToString();
            }
        }
        private void delete_Click(object sender, RoutedEventArgs e)
        {
            var prodServ = ServiceLocator.GetService<Товар>();
            using (prodServ.Uow.Db = new АвтозаправкиEntities())
            {
                var id = (list_of_products.SelectedItem as Товар).код_товара;
                prodServ.Delete(id);
            }
            list_of_products.Items.Remove(list_of_products.SelectedItem);
        }
        private void insert_prod_check(object sender, RoutedEventArgs e)
        {
            Settings.Check.ЧекТовар.Add(new ЧекТовар() { Товар = prod, Чек = Settings.Check });
        }
    }
}
