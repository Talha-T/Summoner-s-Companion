   M S B A M L   `   `   `  ����  SummonersCompanion&     Summoner_s_Companion.ImageDialog   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      
������   � DataContext  5   7   ��  �� Path$ Source� �� RelativeSource �� *Self+ � 	Resources 5	       �� MergedDictionaries �� Source   ProgressBar % !MaterialDesignCircularProgressBar � IsIndeterminate�� 5
   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Flipper.xaml?�6%   %0   &	        � 5      #���  6.    . 6�   5      .��5      �� .+�5   
   �� -   5         ��Name$ Image��5      $
��Fill=�62   $	��478��6A   $	��810��6N   ��6   �� 6\   �� 5   
   
������  �� Orientation$ 
Horizontal=�6.   $��Center=�6G   .+�5      �� -   5        	 ��Name$	 DownloadButton��5   G     MaterialDesignFlatButton#��[ 6   .��6|   
DOWNLOAD6�   �� 5      #��[ 6   )  #MaterialDesignThemes.Wpf.DialogHost
   CloseDialogCommand#��Z
 6G   .��6�   CLOSE6�   5      5      5      