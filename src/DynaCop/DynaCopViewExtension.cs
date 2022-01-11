using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using Dynamo.Linting;
using Dynamo.Wpf.Extensions;

namespace DynaCopViewExtension
{
    public class DynaCopViewExtension : ViewExtensionBase
    {
        private const string ExtensionName = "DynaCop View Extension";
        private const string _ExtensionUniqueId = "EF61CF18-ABB1-4FF9-8F42-9870FC08DF83";
        public override string UniqueId => _ExtensionUniqueId;
        public override string Name => ExtensionName;

        private LinterManager linterManager;
        private ViewLoadedParams viewLoadedParamsReference;
        private MenuItem linterMenuItem;
        private LinterViewModel linterViewModel;
        private LinterView linterView;


        public override void Startup(ViewStartupParams viewStartupParams)
        {
            // Do nothing for now
        }



        public override void Dispose()
        {
            throw new NotImplementedException();
        }

        
    }
}
