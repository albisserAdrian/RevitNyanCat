using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;
using Autodesk.Revit.DB;
using Autodesk.Revit.DB.Events;
using Autodesk.Revit.UI;
using Autodesk.Revit.UI.Events;

using System.Windows.Media;
using System.Windows.Media.Imaging;

using adWin = Autodesk.Windows;

namespace RevitNyanCat
{
    public class Program : IExternalApplication
    {

        private Stopwatch stopwatch;
        int modifier = 0;

        ImageSource imgbg = new BitmapImage(
                    new Uri(Path.Combine(
                    Path.GetDirectoryName(
                    Assembly.GetExecutingAssembly().Location),
                    "catgif.gif"),
                    UriKind.Relative));

        

        public Result OnStartup(UIControlledApplication application)
        {
            try
            {
                

                stopwatch = new Stopwatch();
                stopwatch.Start();

                // Register events
                application.Idling += OnIdling;
            }
            catch (Exception)
            {
                return Result.Failed;
            }
            return Result.Succeeded;
        }


        public Result OnShutdown(UIControlledApplication application)
        {
            // Unregister Events
            application.Idling -= OnIdling;
            return Result.Succeeded;
        }

        public void OnIdling(object sender, IdlingEventArgs e)
        {
            int count1 = 0;

            ImageBrush picBrush = new ImageBrush();
            picBrush.ImageSource = imgbg;
            picBrush.AlignmentX = AlignmentX.Center;
            picBrush.AlignmentY = AlignmentY.Center;
            picBrush.Stretch = Stretch.None;
            picBrush.TileMode = TileMode.None;

            adWin.RibbonControl ribbon = adWin.ComponentManager.Ribbon;

            if (stopwatch.ElapsedMilliseconds > 100)
            {
                if (modifier == 7)
                {
                    count1 = 0;
                }
                else
                {
                    count1 += modifier;
                }

                foreach (adWin.RibbonTab tab in ribbon.Tabs)
                {
                    tab.Title = "Nyan Cat";
                    foreach (adWin.RibbonPanel panel in tab.Panels)
                    {                   
                        
                        switch (count1)
                        {
                            case 0:
                                panel.CustomPanelBackground = new SolidColorBrush(Colors.Red);
                                panel.CustomPanelTitleBarBackground = new SolidColorBrush(Colors.Red);
                                break;
                            case 1:                                                       
                                panel.CustomPanelBackground = new SolidColorBrush(Colors.Orange);
                                panel.CustomPanelTitleBarBackground = new SolidColorBrush(Colors.Orange);
                                break;
                            case 2:
                                panel.CustomPanelBackground = new SolidColorBrush(Colors.Yellow);
                                panel.CustomPanelTitleBarBackground = new SolidColorBrush(Colors.Yellow);
                                panel.CustomPanelBackground = picBrush;
                                break;
                            case 3:
                                panel.CustomPanelBackground = new SolidColorBrush(Colors.Green);
                                panel.CustomPanelTitleBarBackground = new SolidColorBrush(Colors.Green);
                                break;
                            case 4:
                                panel.CustomPanelBackground = new SolidColorBrush(Colors.Blue);
                                panel.CustomPanelTitleBarBackground = new SolidColorBrush(Colors.Blue);
                                break;
                            case 5:
                                panel.CustomPanelBackground = new SolidColorBrush(Colors.Indigo);
                                panel.CustomPanelTitleBarBackground = new SolidColorBrush(Colors.Indigo);
                                break;
                            case 6:
                                panel.CustomPanelBackground = new SolidColorBrush(Colors.Violet);
                                panel.CustomPanelTitleBarBackground = new SolidColorBrush(Colors.Violet);
                                
                                break;

                        }
                        count1 += 1;
                        if (count1 > 6)
                        {
                            count1 = 0;
                        }
                        
                    }
                    
                }

                if (modifier > 6)
                {
                    modifier = 0;
                }
                else
                {
                    modifier += 1;
                }
                
            }

            stopwatch.Reset();
            stopwatch.Start();
        }
    }
}
