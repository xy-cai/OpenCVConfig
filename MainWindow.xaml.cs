using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Linq;


namespace OpenCVConfig
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnClickMe_Click(object sender, RoutedEventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBuildPath.Text = dlg.SelectedPath;
            }
        }
        private void btnClickMe1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "vcxproj files (*.vcxproj)|*.vcxproj|All files (*.*)|*.*";
            dlg.RestoreDirectory = true;
            if (dlg.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                txtBuildPath1.Text = dlg.FileName;
            }
        }

        private void btnSubmit_Click(object sender, RoutedEventArgs e)
        {
            bool debug = false, win32 = false, release = false, x64 = false;
            if ((bool)checkboxDebug.IsChecked)
            {
                debug = true;
            }
            if ((bool)checkboxRelease.IsChecked)
            {
                release = true;
            }
            if ((bool)checkboxWin32.IsChecked)
            {
                win32 = true;
            }
            if ((bool)checkboxX64.IsChecked)
            {
                x64 = true;
            }

            XDocument doc = XDocument.Load(txtBuildPath1.Text);
            XElement xe = doc.Root;
            XNamespace ns = xe.Name.NamespaceName;

            string includepath = txtBuildPath.Text+"\\include\\;"+txtBuildPath.Text+"\\include\\opencv\\;"+txtBuildPath.Text+"\\include\\opencv2\\;"+"$(IncludePath)";
            string libpath = txtBuildPath.Text+"\\x86\\vc10\\lib;$(LibraryPath)";
            string libDepe231d = "opencv_calib3d231d.lib;opencv_contrib231d.lib;opencv_core231d.lib;opencv_features2d231d.lib;opencv_flann231d.lib;opencv_gpu231d.lib;opencv_haartraining_engined.lib;opencv_highgui231d.lib;opencv_imgproc231d.lib;opencv_legacy231d.lib;opencv_ml231d.lib;opencv_objdetect231d.lib;opencv_ts231d.lib;opencv_video231d.lib;%(AdditionalDependencies)";
            string libDepe231 = "opencv_calib3d231.lib;opencv_contrib231.lib;opencv_core231.lib;opencv_features2d231.lib;opencv_flann231.lib;opencv_gpu231.lib;opencv_highgui231.lib;opencv_imgproc231.lib;opencv_legacy231.lib;opencv_ml231.lib;opencv_objdetect231.lib;opencv_ts231.lib;opencv_video231.lib;%(AdditionalDependencies)";
            string libDepe243d = "opencv_calib3d243d.lib;opencv_contrib243d.lib;opencv_core243d.lib;opencv_features2d243d.lib;opencv_flann243d.lib;opencv_gpu243d.lib;opencv_highgui243d.lib;opencv_imgproc243d.lib;opencv_legacy243d.lib;opencv_ml243d.lib;opencv_nonfree243d.lib;opencv_objdetect243d.lib;opencv_photo243d.lib;opencv_stitching243d.lib;opencv_ts243d.lib;opencv_video243d.lib;opencv_videostab243d.lib;%(AdditionalDependencies)";
            string libDepe243 = "opencv_calib3d243.lib;opencv_contrib243.lib;opencv_core243.lib;opencv_features2d243.lib;opencv_flann243.lib;opencv_gpu243.lib;opencv_highgui243.lib;opencv_imgproc243.lib;opencv_legacy243.lib;opencv_ml243.lib;opencv_nonfree243.lib;opencv_objdetect243.lib;opencv_photo243.lib;opencv_stitching243.lib;opencv_ts243.lib;opencv_video243.lib;opencv_videostab243.lib;%(AdditionalDependencies)";
            string libDepe244d = "opencv_calib3d244d.lib;opencv_contrib244d.lib;opencv_core244d.lib;opencv_features2d244d.lib;opencv_flann244d.lib;opencv_gpu244d.lib;opencv_haartraining_engined.lib;opencv_highgui244d.lib;opencv_imgproc244d.lib;opencv_legacy244d.lib;opencv_ml244d.lib;opencv_nonfree244d.lib;opencv_objdetect244d.lib;opencv_photo244d.lib;opencv_stitching244d.lib;opencv_ts244d.lib;opencv_video244d.lib;opencv_videostab244d.lib;%(AdditionalDependencies)";
            string libDepe244 = "opencv_calib3d244.lib;opencv_contrib244.lib;opencv_core244.lib;opencv_features2d244.lib;opencv_flann244.lib;opencv_gpu244.lib;opencv_highgui244.lib;opencv_imgproc244.lib;opencv_legacy244.lib;opencv_ml244.lib;opencv_nonfree244.lib;opencv_objdetect244.lib;opencv_photo244.lib;opencv_stitching244.lib;opencv_ts244.lib;opencv_video244.lib;opencv_videostab244.lib;%(AdditionalDependencies)";

            if (win32)
            {
                if (debug)
                {
                    XElement dire1 = new XElement(ns+"PropertyGroup");
                    XAttribute cond = new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Debug|Win32'");
                    XElement linkInc = new XElement(ns+"LinkIncremental", "true");
                    XElement exePath = new XElement(ns+"ExecutablePath", "$(ExecutablePath)");
                    XElement incPath = new XElement(ns+"IncludePath", includepath);
                    XElement libPath = new XElement(ns+"LibraryPath", libpath);
                    cond.Value = "'$(Configuration)|$(Platform)'=='Debug|Win32'";
                    if (cmboxVSVer.SelectedIndex == 0)
                        libPath.Value = txtBuildPath.Text + "\\x86\\vc10\\lib;$(LibraryPath)";
                    else
                        libPath.Value = txtBuildPath.Text + "\\x86\\vc11\\lib;$(LibraryPath)";
                    dire1.Add(cond);;
                    dire1.Add(linkInc);
                    dire1.Add(exePath);
                    dire1.Add(incPath);
                    dire1.Add(libPath);
                    xe.Add(dire1);

                    foreach (var xe2 in xe.Elements())
                    {
                        XElement tmp = xe2;
                        if (tmp.Name.LocalName == "ItemDefinitionGroup")
                        {
                            if (tmp.HasAttributes)
                            {
                                if (tmp.FirstAttribute.Name == "Condition" && tmp.FirstAttribute.Value == "'$(Configuration)|$(Platform)'=='Debug|Win32'")
                                {
                                    foreach (var xe3 in tmp.Elements())
                                    {
                                        XElement eachEle = xe3;
                                        if (xe3.Name.LocalName == "Link")
                                        {
                                            XElement addDep = new XElement(ns+"AdditionalDependencies", libDepe231d);
                                            if (cmboxOpenCVVer.SelectedIndex == 0)
                                            {
                                                addDep.Value = libDepe231d;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 1)
                                            {
                                                addDep.Value = libDepe243d;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 2)
                                            {
                                                addDep.Value = libDepe244d;
                                            }
                                            eachEle.Add(addDep);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                if (release)
                {
                    XElement dire2 = new XElement(ns + "PropertyGroup");
                    XAttribute cond = new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Debug|Win32'");
                    XElement linkInc = new XElement(ns + "LinkIncremental", "true");
                    XElement exePath = new XElement(ns + "ExecutablePath", "$(ExecutablePath)");
                    XElement incPath = new XElement(ns + "IncludePath", includepath);
                    XElement libPath = new XElement(ns + "LibraryPath", libpath);
                    cond.Value = "'$(Configuration)|$(Platform)'=='Release|Win32'";
                    if (cmboxVSVer.SelectedIndex == 0)
                        libPath.Value = txtBuildPath.Text + "\\x86\\vc10\\lib;$(LibraryPath)";
                    else
                        libPath.Value = txtBuildPath.Text + "\\x86\\vc11\\lib;$(LibraryPath)";
                    dire2.Add(cond);
                    dire2.Add(linkInc);
                    dire2.Add(exePath);
                    dire2.Add(incPath);
                    dire2.Add(libPath);
                    xe.Add(dire2,xe.BaseUri);

                    foreach (var xe2 in xe.Elements())
                    {
                        XElement tmp = xe2;
                        if (tmp.Name.LocalName == "ItemDefinitionGroup")
                        {
                            if (tmp.HasAttributes)
                            {
                                if (tmp.FirstAttribute.Name == "Condition" && tmp.FirstAttribute.Value == "'$(Configuration)|$(Platform)'=='Release|Win32'")
                                {
                                    foreach (var xe3 in tmp.Elements())
                                    {
                                        XElement eachEle = xe3;
                                        if (xe3.Name.LocalName == "Link")
                                        {
                                            XElement addDep = new XElement(ns+"AdditionalDependencies", libDepe231);
                                            if (cmboxOpenCVVer.SelectedIndex == 0)
                                            {
                                                addDep.Value = libDepe231;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 1)
                                            {
                                                addDep.Value = libDepe243;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 2)
                                            {
                                                addDep.Value = libDepe244;
                                            }
                                            eachEle.Add(addDep,eachEle.BaseUri);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            if (x64)
            {
                if (debug)
                {
                    XElement dire3 = new XElement(ns + "PropertyGroup");
                    XAttribute cond = new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Debug|Win32'");
                    XElement linkInc = new XElement(ns + "LinkIncremental", "true");
                    XElement exePath = new XElement(ns + "ExecutablePath", "$(ExecutablePath)");
                    XElement incPath = new XElement(ns + "IncludePath", includepath);
                    XElement libPath = new XElement(ns + "LibraryPath", libpath);
                    cond.Value = "'$(Configuration)|$(Platform)'=='Debug|x64'";
                    if (cmboxVSVer.SelectedIndex == 0)
                        libPath.Value = txtBuildPath.Text + "\\x64\\vc10\\lib;$(LibraryPath)";
                    else
                        libPath.Value = txtBuildPath.Text + "\\x64\\vc11\\lib;$(LibraryPath)";
                    dire3.Add(cond);
                    dire3.Add(linkInc);
                    dire3.Add(exePath);
                    dire3.Add(incPath);
                    dire3.Add(libPath);
                    xe.Add(dire3);

                    foreach (var xe2 in xe.Elements())
                    {
                        XElement tmp = xe2;
                        if (tmp.Name.LocalName == "ItemDefinitionGroup")
                        {
                            if (tmp.HasAttributes)
                            {
                                if (tmp.FirstAttribute.Name == "Condition" && tmp.FirstAttribute.Value == "'$(Configuration)|$(Platform)'=='Debug|x64'")
                                {
                                    foreach (var xe3 in tmp.Elements())
                                    {
                                        XElement eachEle = xe3;
                                        if (xe3.Name.LocalName == "Link")
                                        {
                                            XElement addDep = new XElement(ns+"AdditionalDependencies", libDepe231d);
                                            if (cmboxOpenCVVer.SelectedIndex == 0)
                                            {
                                                addDep.Value = libDepe231d;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 1)
                                            {
                                                addDep.Value = libDepe243d;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 2)
                                            {
                                                addDep.Value = libDepe244d;
                                            }
                                            eachEle.Add(addDep);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }

                }
                if (release)
                {
                    XElement dire4 = new XElement(ns + "PropertyGroup");
                    XAttribute cond = new XAttribute("Condition", "'$(Configuration)|$(Platform)'=='Debug|Win32'");
                    XElement linkInc = new XElement(ns + "LinkIncremental", "true");
                    XElement exePath = new XElement(ns + "ExecutablePath", "$(ExecutablePath)");
                    XElement incPath = new XElement(ns + "IncludePath", includepath);
                    XElement libPath = new XElement(ns + "LibraryPath", libpath);
                    cond.Value = "'$(Configuration)|$(Platform)'=='Release|x64'";
                    if (cmboxVSVer.SelectedIndex == 0)
                        libPath.Value = txtBuildPath.Text + "\\x64\\vc10\\lib;$(LibraryPath)";
                    else
                        libPath.Value = txtBuildPath.Text + "\\x64\\vc11\\lib;$(LibraryPath)";
                    dire4.Add(cond);
                    dire4.Add(linkInc);
                    dire4.Add(exePath);
                    dire4.Add(incPath);
                    dire4.Add(libPath);
                    xe.Add(dire4);

                    foreach (var xe2 in xe.Elements())
                    {
                        XElement tmp = xe2;
                        if (tmp.Name.LocalName == "ItemDefinitionGroup")
                        {
                            if (tmp.HasAttributes)
                            {
                                if (tmp.FirstAttribute.Name == "Condition" && tmp.FirstAttribute.Value == "'$(Configuration)|$(Platform)'=='Release|x64'")
                                {
                                    foreach (var xe3 in tmp.Elements())
                                    {
                                        XElement eachEle = xe3;
                                        if (xe3.Name.LocalName == "Link")
                                        {
                                            XElement addDep = new XElement(ns+"AdditionalDependencies", libDepe231);
                                            if (cmboxOpenCVVer.SelectedIndex == 0)
                                            {
                                                addDep.Value = libDepe231;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 1)
                                            {
                                                addDep.Value = libDepe243;
                                            }
                                            else if (cmboxOpenCVVer.SelectedIndex == 2)
                                            {
                                                addDep.Value = libDepe244;
                                            }
                                            eachEle.Add(addDep);
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            doc.Save(txtBuildPath1.Text);
        }


    }

        

}
