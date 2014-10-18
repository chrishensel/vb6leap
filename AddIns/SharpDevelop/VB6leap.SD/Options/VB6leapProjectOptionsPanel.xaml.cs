// This file is part of vb6leap.
// 
// vb6leap is free software: you can redistribute it and/or modify
// it under the terms of the GNU General Public License as published by
// the Free Software Foundation, either version 3 of the License, or
// (at your option) any later version.
// 
// vb6leap is distributed in the hope that it will be useful,
// but WITHOUT ANY WARRANTY; without even the implied warranty of
// MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
// GNU General Public License for more details.
// 
// You should have received a copy of the GNU General Public License
// along with vb6leap.  If not, see <http://www.gnu.org/licenses/>.

using System.ComponentModel;
using ICSharpCode.SharpDevelop.Gui;
using VB6leap.Vbp.Project;

namespace VB6leap.SD.Options
{
    /// <summary>
    /// Interaction logic for VB6leapProjectOptionsPanel.xaml
    /// </summary>
    public partial class VB6leapProjectOptionsPanel : OptionPanel
    {
        #region Fields

        private IVbpProject _project;
        private ViewModel _viewModel;
        
        #endregion

        #region Constructors

        public VB6leapProjectOptionsPanel()
        {
            InitializeComponent();
        }

        #endregion

        #region Methods

        public override void LoadOptions()
        {
            _project = (IVbpProject)this.Owner;

            _viewModel = new ViewModel(_project.GetOwnedProject());
            this.DataContext = _viewModel;

            base.LoadOptions();
        }

        public override bool SaveOptions()
        {
            return base.SaveOptions();
        }

        #endregion

        #region Nested types

        class ViewModel
        {
            #region Fields

            private IVbProject _project;

            #endregion

            #region Properties

            public string Type
            {
                get { return _project.Type.ToString(); }
            }

            public string Version
            {
                get
                {
                    string version = "";
                    version += _project.Properties.Get("MajorVer", "1") + ".";
                    version += _project.Properties.Get("MinorVer", "0") + ".";
                    version += _project.Properties.Get("RevisionVer", "0");

                    return version;
                }
                set
                {
                    string major = "1";
                    string minor = "0";
                    string rev = "0";

                    if (!string.IsNullOrWhiteSpace(value))
                    {
                        string[] parts = value.Split('.');
                        if (parts.Length >= 3)
                        {
                            major = parts[0];
                            minor = parts[1];
                            rev = parts[2];
                        }
                    }

                    _project.Properties.Set("MajorVer", major);
                    _project.Properties.Set("MinorVer", minor);
                    _project.Properties.Set("RevisionVer", rev);
                }
            }

            public bool AutoIncrementVer
            {
                get { return _project.Properties.Get("AutoIncrementVer", "0") == "1"; }
            }

            #endregion

            #region Constructors

            public ViewModel(IVbProject project)
            {
                _project = project;
            }

            #endregion

        }

        #endregion
    }
}
