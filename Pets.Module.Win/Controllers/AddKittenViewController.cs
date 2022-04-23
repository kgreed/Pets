using DevExpress.Data.Filtering;
using DevExpress.ExpressApp;
using DevExpress.ExpressApp.Actions;
using DevExpress.ExpressApp.Editors;
using DevExpress.ExpressApp.Layout;
using DevExpress.ExpressApp.Model.NodeGenerators;
using DevExpress.ExpressApp.SystemModule;
using DevExpress.ExpressApp.Templates;
using DevExpress.ExpressApp.Utils;
using DevExpress.Persistent.Base;
using DevExpress.Persistent.Validation;
using Pets.Module.BusinessObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Pets.Module.Win.Controllers
{
    // For more typical usage scenarios, be sure to check out https://documentation.devexpress.com/eXpressAppFramework/clsDevExpressExpressAppViewControllertopic.aspx.
    public partial class AddKittenViewController : ViewController
    {
        SimpleAction actionAddKitten;
        // Use CodeRush to create Controllers and Actions with a few keystrokes.
        // https://docs.devexpress.com/CodeRushForRoslyn/403133/
        public AddKittenViewController()
        {
            actionAddKitten = new SimpleAction(this, "AddKitten", "View");
            actionAddKitten.Execute += actionAddKitten_Execute;
            TargetObjectType = typeof(Kitten);
            // Target required Views (via the TargetXXX properties) and create their Actions.
        }
        private void actionAddKitten_Execute(object sender, SimpleActionExecuteEventArgs e)
        {
            var parent = View.ObjectSpace.GetObject(((NestedFrame)Frame).ViewItem.CurrentObject) as Cat;
            var kitten = View.ObjectSpace.CreateObject<Kitten>();
            var babyCount = parent.Kittens.Count;
            kitten.Name = $"Baby {babyCount + 1}";
            kitten.Parent = parent;
            View.ObjectSpace.CommitChanges();
            View.ObjectSpace.Refresh();
            View.Refresh(true);
        }
       
    }
}
