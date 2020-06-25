using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MAChanger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        BinaryFile _bf;
        int selectedItem;

        string pathMaster = @"C:\BIOS\MASTER\";
        string pathOutput = @"C:\BIOS\OUTPUT\";

        string E1 = @"E1-MX25L6406E";
        string E2 = @"E2-MX25L6406E";
        string M30 = @"M30Rewe";
        
        public MainWindow()
        {
            InitializeComponent();
            _bf = new BinaryFile();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {           
            switch(selectedItem)
            {
                case 1: 
                    {
                        File.Copy(pathMaster + E1, pathOutput + E1 + "-" + lbl_new_MAC.Text);
                        File.Copy(pathMaster + E2, pathOutput + E2 + "-" + lbl_new_MAC.Text);
                        _bf.ChangeBinary(pathOutput + E1 + "-" + lbl_new_MAC.Text, lbl_new_MAC.Text);
                        _bf.ChangeBinary(pathOutput + E2 + "-" + lbl_new_MAC.Text, lbl_new_MAC.Text);
                        lbl_MAC_E1.Text = _bf.ReadBinary(pathOutput + E1 + "-" + lbl_new_MAC.Text);
                        lbl_MAC_E2.Text = _bf.ReadBinary(pathOutput + E2 + "-" + lbl_new_MAC.Text);
                        break; 
                    };
                case 0: 
                    {
                        File.Copy(pathMaster + M30, pathOutput + M30 + "-" + lbl_new_MAC.Text);
                        _bf.ChangeBinary(pathOutput + M30 + "-" + lbl_new_MAC.Text, lbl_new_MAC.Text);
                        lbl_MAC_E1.Text = _bf.ReadBinary(pathOutput + M30 + "-" + lbl_new_MAC.Text);
                        break; 
                    };
            }

            lbl_ok.Visibility = Visibility.Visible;
        }

        private void exit_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void cbox_BIOS_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            switch(cbox_BIOS.SelectedIndex)
            {
                case 1: 
                    {
                        selectedItem = 1;
                        lbl_MAC_E1.Text = _bf.ReadBinary(pathMaster + E1);
                        lbl_MAC_E2.Text = _bf.ReadBinary(pathMaster + E2);
                        lbl_MAC_E2.Visibility = Visibility.Visible;
                        lbl_name1.Visibility = Visibility.Visible;
                        lbl_name2.Visibility = Visibility.Visible;
                        lbl_name2.Content = "E2:";
                        lbl_name1.Content = "E1:";
                        break; 
                    };
                case 0: 
                    {
                        selectedItem = 0;
                        lbl_MAC_E1.Text = _bf.ReadBinary(pathMaster + M30);
                        lbl_MAC_E2.Visibility = Visibility.Hidden;
                        lbl_name2.Visibility = Visibility.Hidden;
                        lbl_name1.Visibility = Visibility.Hidden;
                        break; 
                    };
            }

        }
    }
}
