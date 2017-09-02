using PropertyChecker.Data;
using PropertyChecker.Models;
using Reactive.Bindings;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Reactive.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PropertyChecker.ViewModels
{
    public class MainWindowViewModel
    {
        #region properties
        private ReactiveProperty<string> _openFolderDialogContent = new ReactiveProperty<string>(Properties.Resources.OpenFolder.ToString());
        private ReactiveProperty<string> _labelFolderName = new ReactiveProperty<string>(Properties.Resources.FolderName.ToString());
        private ReactiveProperty<string> _targetFolderContent = new ReactiveProperty<string>(string.Empty);
        private ReactiveProperty<string> _checkPropertyContent = new ReactiveProperty<string>(Properties.Resources.CheckPorperty.ToString());
        private ReactiveProperty<string> _clearContent = new ReactiveProperty<string>(Properties.Resources.ClearDisplayValues.ToString());
        private ReactiveProperty<string> _deletePropertyContent = new ReactiveProperty<string>(Properties.Resources.DeleteProperties.ToString());
        private ReactiveProperty<string> _nowDateTimeValue = new ReactiveProperty<string>(DateTime.Now.ToString());
        private ReactiveProperty<string> _labelDateTimeContent = new ReactiveProperty<string>(Properties.Resources.DateTimeLabelContent.ToString());
        private ReactiveProperty<bool> _targetFolderContentReadOnly = new ReactiveProperty<bool>(false);
        public ReactiveProperty<string> OpenFolderDialogContent{get { return _openFolderDialogContent; }}
        public ReactiveProperty<string> LabelFolderName{get { return _labelFolderName; }}
        [Required(ErrorMessage = "Error!")]
        public ReactiveProperty<string> TargetFolderContent{get { return _targetFolderContent; }}
        public ReactiveProperty<string> CheckPropertyContent{get{ return _checkPropertyContent; }}
        public ReactiveProperty<string> ClearContent {get { return _clearContent; }}
        public ReactiveProperty<string> DeletePropertyContent{ get { return _deletePropertyContent; }}
        public ReactiveProperty<ObservableCollection<PropertyItem>> Results { get; private set; } 
            = new ReactiveProperty<ObservableCollection<PropertyItem>>();

        public ReactiveProperty<string> NowDateTimeValue
        {
            get { return _nowDateTimeValue; }
            set { _nowDateTimeValue = value; }
        }
        public ReactiveProperty<string> LabelDateTimeContent{get { return _labelDateTimeContent; }}
        public ReactiveCommand OpenFolderDialogCommand{get; private set;}
        public ReactiveCommand CheckPropertyCommand { get; private set;}
        public ReactiveCommand ClearCommand { get; private set;}
        public ReactiveCommand DeletePropertyCommand { get; private set;}
        public PropertyItem SelectedItemValue { get; set; }
        public ReactiveProperty<bool> TargetFolderContentReadOnly
        {
            get { return _targetFolderContentReadOnly; }
            set { _targetFolderContentReadOnly = value; }
        }
        #endregion

        private MainWindowModel _model;
        public MainWindowViewModel()
        {
            try
            {
                _model = null;
                TargetFolderContentReadOnly.Value = false;

                #region  Get the Folder Path
                OpenFolderDialogCommand = new ReactiveCommand();
                OpenFolderDialogCommand.Subscribe(_ =>
                {
                    _targetFolderContent.Value = string.Empty;
                    using (var dialog = new FolderBrowserDialog())
                    {
                        dialog.Description = Properties.Resources.SelectFolder.ToString();
                        dialog.ShowNewFolderButton = false;
                        dialog.RootFolder = Environment.SpecialFolder.Desktop;
                        if (dialog.ShowDialog() != DialogResult.OK)
                        {
                            MessageBox.Show(Properties.Resources.Cancel.ToString());
                        }
                        _targetFolderContent.Value = dialog.SelectedPath;
                    };
                });
                #endregion

                #region Clear field values
                ClearCommand = new ReactiveCommand();
                ClearCommand.Subscribe(_ =>
                {
                    TargetFolderContentReadOnly.Value = false;
                    _targetFolderContent.Value = string.Empty;
                    NowDateTimeValue.Value = DateTime.Now.ToString();
                    Results.Value = null;
                    _model = null;
                });
                #endregion

                #region Get Properties
                CheckPropertyCommand = new ReactiveCommand();
                CheckPropertyCommand.Subscribe(_ =>
                {
                    if(string.IsNullOrEmpty(_targetFolderContent.Value) || string.IsNullOrWhiteSpace(_targetFolderContent.Value))
                    {
                        throw new ArgumentNullException(Properties.Resources.EnterTargetFolderName);
                    }
                    TargetFolderContentReadOnly.Value = true;
                    var task = Task.Run(() => {
                        _model = new MainWindowModel(_targetFolderContent.Value);
                        Results.Value = _model.GetProperties();
                        Results.ToReactiveProperty();
                        _model = null;
                    });
                    TargetFolderContentReadOnly.Value = false;
                });
                #endregion

                #region Delete Properties
                DeletePropertyCommand = new ReactiveCommand();
                DeletePropertyCommand.Subscribe(_ =>
                {
                    if (string.IsNullOrEmpty(_targetFolderContent.Value) || string.IsNullOrWhiteSpace(_targetFolderContent.Value))
                    {
                        throw new ArgumentNullException(Properties.Resources.EnterTargetFolderName);
                    }
                    TargetFolderContentReadOnly.Value = true;
                    var task = Task.Run(() =>
                    {
                        _model = new MainWindowModel(_targetFolderContent.Value);
                        var items = _model.GetProperties();
                        _model.SetProperty(items);
                        _model = null;
                        items = null;
                        Results.Value = null;
                        _model = new MainWindowModel(_targetFolderContent.Value);
                        Results.Value = _model.GetProperties();
                        Results.ToReactiveProperty();
                        _model = null;
                    });
                    TargetFolderContentReadOnly.Value = false;
                });
                #endregion

            }
            catch (Exception ex)
            {
                TargetFolderContentReadOnly.Value = false;
                MessageBox.Show(ex.StackTrace.ToString());
            }
        }
    }
}
