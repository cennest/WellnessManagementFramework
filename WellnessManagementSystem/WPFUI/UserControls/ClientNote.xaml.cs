using BusinessLayer;
using BusinessLayer.Entities;
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

namespace PhysioApplication.UserControls
{
    /// <summary>
    /// Interaction logic for ClientNote.xaml
    /// </summary>
    public partial class ClientNote : UserControl
    {
        public ClientNote()
        {
            InitializeComponent();
            SetNote();
        }

        public void SetNote()
        {
            AppManager appmanager = AppManager.getInstance();
            BOUser user = appmanager.GetUserDetails();
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            String note = businessLayer.GetNoteForClient(appmanager.currentClientID);
            if (note != "" && note != null)
            {
                var document = noteEditor.Document;
                var range = new TextRange(document.ContentStart, document.ContentEnd);
                var ms = new MemoryStream();
                var writer = new StreamWriter(ms);
                writer.Write(note);
                writer.Flush();
                ms.Seek(0, SeekOrigin.Begin);
                range.Load(ms, DataFormats.Rtf);
            }
        }

        private void noteEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            object temp = noteEditor.Selection.GetPropertyValue(Inline.FontWeightProperty);
            btnBold.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontWeights.Bold));
            temp = noteEditor.Selection.GetPropertyValue(Inline.FontStyleProperty);
            btnItalic.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(FontStyles.Italic));
            temp = noteEditor.Selection.GetPropertyValue(Inline.TextDecorationsProperty);
            btnUnderline.IsChecked = (temp != DependencyProperty.UnsetValue) && (temp.Equals(TextDecorations.Underline));
        }

        private void btnSave_Click(object sender, RoutedEventArgs e)
        {

            var doc = noteEditor.Document;
            var range = new TextRange(doc.ContentStart, doc.ContentEnd);
            var ms = new MemoryStream();
            range.Save(ms, DataFormats.Rtf);
            ms.Seek(0, SeekOrigin.Begin);
            var xamlText = new StreamReader(ms).ReadToEnd();
            AppManager appmanager = AppManager.getInstance();
            BOUser user = appmanager.GetUserDetails();
            BusinessLayerManager businessLayer = new BusinessLayerManager();
            bool isSaved = businessLayer.SaveNote(appmanager.currentClientID, xamlText);
            if (isSaved)
            {
                MessageBox.Show("Save Successful");
            }
        }
    }
}
