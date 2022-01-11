using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Dynamo.Extensions;
using Dynamo.Linting;
using Dynamo.ViewModels;
using Dynamo.Wpf.Extensions;

namespace DynaCopViewExtension
{
    public class DynaCopViewExtension : IViewExtension
    {
        private const string ExtensionName = "DynaCop View Extension";
        private const string _ExtensionUniqueId = "EF61CF18-ABB1-4FF9-8F42-9870FC08DF83";
        public override string UniqueId => _ExtensionUniqueId;
        public override string Name => ExtensionName;

        private MenuItem dynaCopMenuItem;
        private ViewLoadedParams viewLoadedParamsReference;

        public override void Ready(ReadyParams sp)
        {
            base.Ready(sp);

            this.AddLinterRule(new NodesCantBeNamedFooRule());
            this.AddLinterRule(new InputNodesNotAllowedRule());
            this.AddLinterRule(new GraphNeedsOutputNodesRule());
            this.AddLinterRule(new WarningSeverityRule());
            this.AddLinterRule(new DuplicatedNamesRule());
        }

        public override void Startup(ViewStartupParams viewStartupParams)
        {
            // Do nothing for now
        }

        public void Loaded(ViewLoadedParams viewLoadedParams)
        {
            this.viewLoadedParamsReference = viewLoadedParams;
            this.dynaCopMenuItem = new MenuItem { Header = "TestLinter", IsCheckable = true };
            this.dynaCopMenuItem.Checked += MenuItemCheckHandler;
            this.viewLoadedParamsReference.AddExtensionMenuItem(this.dynaCopMenuItem);
        }
        private void MenuItemCheckHandler(object sender, RoutedEventArgs e)
        {
            var viewModel = this.viewLoadedParamsReference.DynamoWindow.DataContext as DynamoViewModel;
            var linterManager = viewModel.Model.LinterManager;

            foreach (var linter in linterManager.AvailableLinters)
            {
                if (linter.Id == this.UniqueId)
                    linterManager.SetActiveLinter(linter);

            }
        }

        public override void Dispose() { }
        public override void Shutdown() { }


    }
}
