   M S B A M L   `   `   `  ����  SummonersCompanion*    $Summoner_s_Companion.Views.SpellView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      -   5          >�Name$
  Root��5   8    � 	Resources 5       �� MergedDictionaries �� Source�� 5	   
    5
      �� 5      $i cpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml?�6%   %    5      .��5      �  � DataContext 6   �� *Spell+ �� ElementName$
 Root�� � RowDefinitions 5   
   �� 5      $
��131* �6   �� 5      $	��75* �6   6+   �� 5      $
��472* �6   .+�5   
   �� $��Center=�6    #  MaterialDesignDisplay3TextBlock#��[  6E   $��	50,0,20,0q�6~   ��6/   �� *Name+6�   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   $��Center=�6;   $��	50,0,20,0q�6V   .+�5      �� $��Center=�6S   $��0,13,0,0q�6n      MaterialDesignTitleTextBlock#��[ 6�   ��6   �� *CooldownBurn+ �� StringFormat$ Cooldown: {0}��6�   �� 5      $��Center=�6M   $��	15,13,0,0q�6h   #��[ 6{   ��6   �� *	RangeBurn+$ 
Range: {0}��6�   �� 5      -   5        	 ��Name$	 	SpellCost��5      $��Center=�6+   $��	15,13,0,0q�6F   #��[ 6Y   ��5      `� 5      $ Cost: {0}{1}��6#   .1�5      �� 
 �� Path$
 CostBurn�6"   64   �� 5      $
 CostType�6"   64   5      5       5!      �� 5"   
   $ 
Horizontal=�6   $��2��6.   .+�5#      A� $	��128��6   $	��128��6"   $��80q�6/   $��Center=�6;   ��5$      �� 5%       �� ImageSource 6!   �� *
Image.Full+  SpellImageConverter �� 	Converter# [ 6u   5'      � 5(      $	��820��6   $	��400��6"   .+�5)      �� $��Center=�6   $��Disabled=�6:   $
��Auto=�6c   .��5*      �� -   5        $	 	SpellDesc��5*       $��15(�63    # MaterialDesignDisplay1TextBlock#��[ 6c   $
��Wrap=�6�    �� Padding$ 40,20q�6�   ��6A   �� *SanitizedTooltip+6�   5+      5,      5-      �� 5.   
   $��Bottom=�6   $
��Left=�6/   $��2��6J   $��
140,0,0,50q�6W   #��[ 6k   ��6�   �� *SpellString+$
 Root��6�   5/      50      