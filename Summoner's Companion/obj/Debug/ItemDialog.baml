   M S B A M L   `   `   `  ����H  DRiotSharp, Version=2.5.5.38286, Culture=neutral, PublicKeyToken=null^=clr-namespace:RiotSharp.StaticDataEndpoint;assembly=RiotSharpRiotSharp.StaticDataEndpoint  5      M ISummonersCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Summoner_s_Companion.ConvertersSummoner_s_Companion.Converters 5      %   Summoner_s_Companion.ItemDialog   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      \staticDataEndpoint=clr-namespace:RiotSharp.StaticDataEndpoint;assembly=RiotSharp     5      D
converters-clr-namespace:Summoner_s_Companion.Converters     5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      -   5          >�Name$
  Root��5
   �   $��25q�6#    � DataContext 6D   ��  �� RelativeSource �� *Self+ �� Path$
 Item� �� UpdateSourceTrigger$ PropertyChanged=� � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $i cpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml?�6%   �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   %    5      .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   .+�5   
   �� $	��400��6   	 �� Padding$	 15,20q�69    #  MaterialDesignDisplay1TextBlock#��[  6I   $
��Wrap=�6�   ��6#   �� *Name+6�   �� 5   
   $��Disabled=�6   $
��Auto=�6J   $��1��6z   $	��400��6�   $	 5q�6�      MaterialDesignBody1TextBlock#��[ 6�   $
��Wrap=�5   >   ��6   �� *SanitizedDescription+6T   � 5   
   $	��350��6   $��2��6   .+�5      �� $��Disabled=�6   $
��Auto=�6D   .��5      �� 
 �� Orientation$
 
Horizontal=�6   $��Center=�66   .+�5       �� $	��Top=�6!   6  0Summoner_s_Companion.Converters.VisibilityHelper   	IsVisible 69   ��  �� ElementName$	 Lb1��$ Items.Count�  GreaterThanZeroConverter �� 	Converter# [ .+�5!      �� �� 5"      $��Builds Into��6$    % !MaterialDesignSubheadingTextBlock#��[ 67   $	 5q�6r   6�   �� 5#      -   5         ��Name$	 Lb1��5#   "   $
��0,10q�6c   ��6/   �� *
BuildsInto+$
 Root����5$      �� 5%   "    �� DataType$# staticDataEndpoint:ItemStatic��6/   .R�5&   &   �  � ColumnDefinitions 5'   *   �� 5(   .   $
��Auto �6?    z� SharedSizeGroup$
 Col1��6L   6e   �� 5)   .   $
��Auto �6?   $
 Col2��6L   6e   .+�5+   *   A� $��60��62   $��60��6=   $��5q�6I   ��5,   .   �� 5-   2    �� ImageSource 6=   �� *Id+  ItemImageConverter# [ 6�   5/   +   �� 50   *   $��1��65   $��10,20q�6E   .+�51   .   �� $
 
Horizontal=�69   .+�52   2   �� ��6<   �� *Gold.BasePrice+6^   �� 53   2   $B��<http://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/gold.png��68   $��16��6~   $��16��6�   $��0,4,0,0q�6�   6�   54   /   55   +   56   '   57   #   ��59      �� 5:   "    �� 
TargetType" ��6(    �� BasedOn# [B��6J   .�5;   &   -   5        5<   #   5>      5?      �� 5@      $	��Top=�6!    69   �� $	 Lb2��$ Items.Count�# [ .+�5A      �� �� 5B      $��Builds From��6$   #��[ 67   $	 5q�6r   6�   �� 5C      -   5        $	 Lb2��5C   "   $
��0,10q�6c   ��6/   �� *
BuildsFrom+$
 Root����5D      �� 5E   "   $# staticDataEndpoint:ItemStatic��6/   .R�5F   &   �  5G   *   �� 5H   .   $
��Auto �6?   $
 Col1��6L   6e   �� 5I   .   $
��Auto �6?   $
 Col2��6L   6e   .+�5K   *   A� $��60��62   $��60��6=   $��5q�6I   ��5L   .   �� 5M   2    6=   �� *Id+# [ 6�   5O   +   �� 5P   *   $��1��65   $��10,20q�6E   .+�5Q   .   �� $
 
Horizontal=�69   .+�5R   2   �� ��6<   �� *Gold.BasePrice+6^   �� 5S   2   $B��<http://ddragon.leagueoflegends.com/cdn/5.5.1/img/ui/gold.png��68   $��16��6~   $��16��6�   $��0,4,0,0q�6�   6�   5T   /   5U   +   5V   '   5W   #   ��5Y      �� 5Z   "   " ��6(   # [B��6J   .�5[   &   -   5        5\   #   5^      5_      5`      5a      5b      �� 5c   
   $��3��6     MaterialDesignFlatButton#��[ 6   )  #MaterialDesignThemes.Wpf.DialogHost   CloseDialogCommand#��Z 6P   $��Center=�6�   .��6�   CLOSE6�   5d      5e      