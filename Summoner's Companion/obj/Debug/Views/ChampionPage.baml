   M S B A M L   `   `   `  ����M  ISummonersCompanion, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullQ-clr-namespace:Summoner_s_Companion.ViewModelsSummoner_s_Companion.ViewModels  5      Q-clr-namespace:Summoner_s_Companion.ConvertersSummoner_s_Companion.Converters  5	      G(clr-namespace:Summoner_s_Companion.ViewsSummoner_s_Companion.Views  5
      H DRiotSharp, Version=2.5.5.38286, Culture=neutral, PublicKeyToken=null^=clr-namespace:RiotSharp.StaticDataEndpoint;assembly=RiotSharpRiotSharp.StaticDataEndpoint 5      -    'Summoner_s_Companion.Views.ChampionPage   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      E ADragablz, Version=0.0.3.186, Culture=neutral, PublicKeyToken=null6dragablz'http://dragablz.net/winfx/xaml/dragablz  5      U QMaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      >
viewModels-clr-namespace:Summoner_s_Companion.ViewModels  5      >
converters-clr-namespace:Summoner_s_Companion.Converters  5	      4views(clr-namespace:Summoner_s_Companion.Views  5
      VstaticDataEndpoint=clr-namespace:RiotSharp.StaticDataEndpoint;assembly=RiotSharp  5        � DataContext  5      7   1Summoner_s_Companion.ViewModels.ChampionViewModel  5   
   -   5        ChampionViewModel��5   D    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $f `pack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.Button.xaml?�6%   �� 5      $i cpack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBlock.xaml?�6%   �� 5      $k epack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.ProgressBar.xaml?�6%   %    5      .��5      � .+�5   
     Dragablz.TabablzControl  .@�5      �� $��General��6   .��5      �  � RowDefinitions 5      �� 5      $
��Auto �6(   68   �� 5       $
��Auto �6(   68   .+�5"      �  � ColumnDefinitions 5#      �� 5$      $	��168 �6+   69   �� 5%      $
��Auto �6+   6:   �� 5&      $
��Auto �6+   6:   �� 5'      $
��Auto �6+   6:   �� 5(      $
��Auto �6+   6:   �� 5)      $
��Auto �6+   6:   �� 5*      $
��Auto �6+   6:    5,      �� 5-      $��3* �6(   66   �� 5.      $��4* �6(   66   .+�50      �� -   5         ��Name$ ChampionImageRectangle��50   �    � ToolTip$K EClick To Toggle Rectangle/Ellipse
Double Click To Toggle Splash/Small��6     �� RadiusX$	 100��6�   	 �� RadiusY$		 100��6�   $	��120��6�   $	��120��6�   $	��Top=�6�   $��Right=�6  $��0,48,0,0q�6,  ��51      �� 52      
 �� ImageSource
 6)   �� *Champion.Image.Full+   ChampionImageConverter �� 	Converter# [  6�   54      �� 55      $��0��6!   $��1��6.   $��30,70q�6>   .+�56      ��    MaterialDesignTitleTextBlock#��[ 6$   ��6Z   �� *Champion.Name+6{   �� 57      $��0,5,0,0q�6$    % !MaterialDesignSubheadingTextBlock#��[ 65   ��6p   �� *Champion.Title+6�   �� 58      $��0,5,0,0q�6$   #��[ 65   ��6p   �� *Champion.Tags+  ArrayToStringConverter# [ 6�   59      �� 5:      $��0��6!   $��2��6.   $
��5,80q�6>   $	��Top=�6L    �� Orientation$ 
Horizontal=�6d   .+�5;      � $
��Left=�6   $��50��6:   $��50��6E   $ Attack��6Q   .+�5<      � -   5         �Name$ AttackProgress��5<   �   $��50��6*   $��50��66    % !MaterialDesignCircularProgressBar#��[ 6A    � Maximum$
 10.1Q�6�    � Value 6|   �� *Champion.Info.Attack+6�   �� 5=      $��Center=�6_   $��Center=�6|   ��6(   ��  �� ElementName$ AttackProgress�� �� Path$ Value�6�   5>      � 5?      $��50��6   $��50��6*   $
��10,0q�66   $ Magic��6D   .+�5@      � -   5        $ MagicProgress��5@   �   ���#9C27B0$��50��6?   $��50��6K   #��[ 6V   $
 10.1Q�6�    6�   �� *Champion.Info.Magic+6�   �� 5A      $��Center=�6^   $��Center=�6{   ��6(   �� $ MagicProgress��$ Value�6�   5B      � 5C      $��50��6   $��50��6*   $
��10,0q�66   $ Defense��6D   .+�5D      � -   5        $ DefenseProgress��5D   �   ���#4CAF50$��50��6?   $��50��6K   #��[ 6V   $
 10.1Q�6�    6�   �� *Champion.Info.Defense+6�   �� 5E      $��Center=�6`   $��Center=�6}   ��6(   �� $ DefenseProgress��$ Value�6�   5F      � 5G      $��50��6   $��50��6*   $
��10,0q�66   $ 
Difficulty��6D   .+�5H      � -   5        $ DifficultyProgress��5H   �   ���#3F51B5$��50��6?   $��50��6K   #��[ 6V   $
 10.1Q�6�    6�   �� *Champion.Info.Difficulty+6�   �� 5I      $��Center=�6c   $��Center=�6�   ��6(   �� $ DifficultyProgress��$ Value�6�   5J      5K      �� 5L      $��10,70q�6!   $��0��60   $��3��6=   .+�5M      �� -   5         ��Name$ 
LoreButton��5M   !   .��6P   LORE6V   �� 5N      -   5        $ BlorbButton��5N   3   $
��0,10q�6%   .��6d   BLURB6k   5O      �� 5P      $��10,70q�6$   $��4��63   $��0��6C   Uses �� 5Q      $
��Bold"�6#   �65   �� *Champion.Partype+6Y   �� 6^   to cast spells5R      �� 5S      $��5��6    $��0��60   $��20,200q�6=   $��13(�6M   PL = Per Level6k   �� 5T      $ 
Horizontal=�6%   $��5��6>   $��0��6N   .+�5U      �� $ Vertical=�6)   $��20,70q�6@   $	��300��6O   .+�5V   "   �� $ 
Horizontal=�6-   .+�5W   &   �� $
��Bold"�60   Armor6I   �� 5X   &   $
��10,0q�60   ��5Y   *   `� 5Z   .    �� StringFormat$ {0} ({1} PL)��6;   .1�5[   2   �� $ Champion.Stats.Armor�6:   6X   �� 5\   2   $" Champion.Stats.ArmorPerLevel�6:   6`   5]   /   5_   '   5`   #   �� 5a   "   $
��0,10q�6-   $ 
Horizontal=�6;   .+�5b   &   �� $
��Bold"�60   Magic Resist6P   �� 5c   &   $
��10,0q�60   ��5d   *   `� 5e   .   $ {0} ({1} PL)��6;   .1�5f   2   �� $ Champion.Stats.SpellBlock�6:   6]   �� 5g   2   $' !Champion.Stats.SpellBlockPerLevel�6:   6e   5h   /   5j   '   5k   #   �� 5l   "   $	��0,0q�6-   $ 
Horizontal=�6:   .+�5m   &   �� $
��Bold"�60   Health6J   �� 5n   &   $
��10,0q�60   ��5o   *   `� 5p   .   $ {0} ({1} PL)��6;   .1�5q   2   �� $ Champion.Stats.Hp�6:   6U   �� 5r   2   $ Champion.Stats.HpPerLevel�6:   6]   5s   /   5u   '   5v   #   �� 5w   "   $
��0,10q�6-   $ 
Horizontal=�6;   .+�5x   &   �� $
��Bold"�60   Health Generation6U   �� 5y   &   $
��10,0q�60   ��5z   *   `� 5{   .   $ {0} ({1} PL)��6;   .1�5|   2   �� $ Champion.Stats.HpRegen�6:   6Z   �� 5}   2   $$ Champion.Stats.HpRegenPerLevel�6:   6b   5~   /   5�   '   5�   #   �� 5�   "   $	��0,0q�6-   $ 
Horizontal=�6:   .+�5�   &   �� $
��Bold"�60   Mana6H   �� 5�   &   $
��10,0q�60   ��5�   *   `� 5�   .   $ {0} ({1} PL)��6;   .1�5�   2   �� $ Champion.Stats.Mp�6:   6U   �� 5�   2   $ Champion.Stats.MpPerLevel�6:   6]   5�   /   5�   '   5�   #   5�      �� 5�      $ Vertical=�6)   $��30,70q�6@   .+�5�   "   �� $	��0,0q�6-   $ 
Horizontal=�6:   .+�5�   &   �� $
��Bold"�60   Attack Damage6Q   �� 5�   &   $
��10,0q�60   ��6>   �� *Champion.Stats.AttackDamage+6m   5�   #   �� 5�   "   $
��0,10q�6-   $ 
Horizontal=�6;   .+�5�   &   �� $
��Bold"�60   Attack Speed6P   �� 5�   &   $
��10,0q�60   ��5�   *   `� 5�   .   $ {0} ({1} PL)��6;   .1�5�   2   �� $&  Champion.Stats.AttackSpeedOffset�6:     AttackSpeedConverter# [ 6b   6�   �� 5�   2   $( "Champion.Stats.AttackSpeedPerLevel�6:   6f   5�   /   5�   '   5�   #   �� 5�   "   $	��0,0q�6-   $ 
Horizontal=�6:   .+�5�   &   �� $
��Bold"�60   Mana Generation6S   �� 5�   &   $
��10,0q�60   ��5�   *   `� 5�   .   $ {0} ({1} PL)��6;   .1�5�   2   �� $ Champion.Stats.MpRegen�6:   6Z   �� 5�   2   $$ Champion.Stats.MpRegenPerLevel�6:   6b   5�   /   5�   '   5�   #   �� 5�   "   $
��0,10q�6-   $ 
Horizontal=�6;   .+�5�   &   �� $
��Bold"�60   Movement Speed6R   �� 5�   &   $
��10,0q�60   ��6>   �� *Champion.Stats.MoveSpeed+6j   5�   #   �� 5�   "   $	��0,0q�6-   $ 
Horizontal=�6:   .+�5�   &   �� $
��Bold"�60   Attack Range6P   �� 5�   &   $
��10,0q�60   ��6>   �� *Champion.Stats.AttackRange+6l   5�   #   5�      5�      5�      � 5�      $��1��6   $��30q�6(   $
��1300��64    5�      �� 5�      $��* �6/   6;   �� 5�      $��* �6/   6;   .+�5�      � $��0��6#   $	��Top=�63   $��
0,-150,0,0q�6K   .+�5�      �� $
��Auto=�6+   $��Disabled=�6N   .��5�   "   �� .+�5�   &   �� #��[ 60    �� Padding$ 5q�5�   0   ��5�   0   �� $ Champion.Name�$ If you are {0}:��5�   '   �� 5�   &   $��10q�6X   ��6.   �� *Champion.AllyTips+��5�   *   �� 5�   .   .R�5�   2   �� $
��Wrap=�6M   ��6<   �� 6c   5�   /   5�   '   5�   #   5�      5�      � 5�      $��1��6   $	��Top=�6/   $��30,-150,0,0q�6G   .+�5�      �� $
��Auto=�6+   $��Disabled=�6N   .��5�   "   �� .+�5�   &   �� #��[ 60   $ 5q�5�      ��6,   �� $ Champion.Name�$% If you are playing against {0}:��5�   '   �� 5�   &   $��10q�6Y   ��6.   �� *Champion.EnemyTips+��5�   *   �� 5�   .   .R�5�   2   �� $
��Wrap=�6M   ��6<   �� 6c   5�   /   5�   '   5�   #   5�      5�      5�      5�      5�      �� 5�      $��Spells��6   .��5�      � $	��606��6   $
��1347��6'   .+�5�      �� .��5�      �� .+�5�      ,   &Summoner_s_Companion.Views.PassiveView     Passive 60   �� *Champion.Passive+6W   �� 5�      6*   *   $Summoner_s_Companion.Views.SpellView  5�         SpellString$ Q��6S      Spell 6.   �� *Champion.Spells[0]+6e   �� 5�      6*     5�      $ W��6S    6.   �� *Champion.Spells[1]+6e   �� 5�      6*     5�      $ E��6S    6.   �� *Champion.Spells[2]+6e   �� 5�      6*     5�      $ R��6S    6.   �� *Champion.Spells[3]+6e   5�      5�      5�      5�      �� 5�      $��Builds & Counters��6   .��5�      � .+�5�      (  "System.Windows.Controls.WebBrowser  -	   5          Name$ 
WebBrowser��5�     $	��Top=�6�   $	��530��6�    K� ZIndex$ -5��6�   6   0Summoner_s_Companion.Converters.WebBrowserHelper   BindableSource 6!   �� *Champion.Name+$. (https://tr.op.gg/champion/{0}/statistics��  NameFlatConverter# [ 6  �� 5�      -
   5        $ BrowserBackButton��5�   �   $
 2500��6   $ Web Browser Back��61    & "MaterialDesignFloatingActionButton#��[ 6�   $��Bottom=�6  $
��Left=�65  $��	16,0,0,16q�6P  ��6L   ��  �� RelativeSource ��  �� Mode$ FindAncestor=� �� AncestorType$ UserControlL�$ BrowserBackCommand�.��5�      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.3.0.823, Culture=neutral, PublicKeyToken=null]]   Kind$ ArrowLeftBold=�62   6I   5�      �� 5�      -   5        $ BrowserForwardButton��5�   �   $
 2500��6   $ Web Browser Forward��61   #��[ 6�   $��Bottom=�6#  $
��Left=�6>  $��
106,0,0,16q�6Y  ��6O   ��  �� $ FindAncestor=�$ UserControlL�$ BrowserForwardCommand�.��5�        $ ArrowRightBold=�62   6J   5�      5�      5�      �� 5�      $��Skins��6   .��5�      7	  1MaterialDesignThemes.Wpf.Transitions.Transitioner	  -   5         	 Name$ Transitioner��5�   .     �� SelectedIndex$  0��6D   ��5�      �� 5�      ! �� DataType$#! staticDataEndpoint:SkinStatic��6'   .R�5�      <
  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide
  .��5   "   �� ��5  &   `� 5  *     SkinImageConverter" `� 	Converter#" [ 67   .1�5  .   �� $ Transitioner��66   $
 Name�6Q   6_   �� 5  .   $	 Num�66   6C   5  +   5  #   5     5	     5     5     5     �� 5  
   -   5        $ 
BackButton��5  +   $ Go To Main Page��6   #��[ 6?   $��Bottom=�6{   $��Right=�6�   $��	0,0,16,16q�6�   # 	  MovePreviousCommand#��Z# 6�   .��5       $ ArrowLeftBold=�6&   6=   5     5     5     