#pragma checksum "..\..\FinalScoreWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "0F05F13510290798CCF79CB8E805FB288C7EEFAE93FA3079FE7420FED14074F9"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using ApertureEnrichmentKids;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace ApertureEnrichmentKids {
    
    
    /// <summary>
    /// FinalScoreWindow
    /// </summary>
    public partial class FinalScoreWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal ApertureEnrichmentKids.FinalScoreWindow wndFinalScore;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblResultMessage;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUserName;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblUserAge;
        
        #line default
        #line hidden
        
        
        #line 31 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectScore;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblScore;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Shapes.Rectangle rectTime;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblTime;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Image imgResult;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\FinalScoreWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView lstLeaderBoard;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ApertureEnrichmentKids;component/finalscorewindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\FinalScoreWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.wndFinalScore = ((ApertureEnrichmentKids.FinalScoreWindow)(target));
            
            #line 8 "..\..\FinalScoreWindow.xaml"
            this.wndFinalScore.Closing += new System.ComponentModel.CancelEventHandler(this.wndFinalScore_Closing);
            
            #line default
            #line hidden
            
            #line 8 "..\..\FinalScoreWindow.xaml"
            this.wndFinalScore.Activated += new System.EventHandler(this.wndFinalScore_Activated);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblResultMessage = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblUserName = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.lblUserAge = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.rectScore = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 6:
            this.lblScore = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.rectTime = ((System.Windows.Shapes.Rectangle)(target));
            return;
            case 8:
            this.lblTime = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.imgResult = ((System.Windows.Controls.Image)(target));
            return;
            case 10:
            this.lstLeaderBoard = ((System.Windows.Controls.ListView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

