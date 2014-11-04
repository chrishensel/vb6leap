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

using ICSharpCode.SharpDevelop.Gui;

namespace VB6leap.SDAddin.Options
{
    /// <summary>
    /// Interaction logic for VB6leapOptionPanel.xaml
    /// </summary>
    public partial class VB6leapOptionPanel : OptionPanel
    {
        #region Fields

        private ViewModel _viewModel;

        #endregion

        #region Constructors

        public VB6leapOptionPanel()
        {
            InitializeComponent();

            _viewModel = new ViewModel();
            this.DataContext = _viewModel;
        }

        #endregion

        #region Methods

        public override void LoadOptions()
        {
            base.LoadOptions();

            _viewModel.VB6IdePath = AddInOptions.Vb6IdePath;
        }

        public override bool SaveOptions()
        {
            AddInOptions.Vb6IdePath = _viewModel.VB6IdePath;

            return base.SaveOptions();
        }

        #endregion

        #region Nested types

        class ViewModel
        {
            public string VB6IdePath { get; set; }
        }

        #endregion
    }
}
