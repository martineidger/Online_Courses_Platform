   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OnlineCoursesPlatformOnlineCoursesPlatform  5      q=clr-namespace:OnlineCoursesPlatform.Infrastructure.Converters/OnlineCoursesPlatform.Infrastructure.Converters  5      S.clr-namespace:OnlineCoursesPlatform.ViewModels OnlineCoursesPlatform.ViewModels  5      U QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 6H   B    <OnlineCoursesPlatform.Views.CustomFields.CoursesCatalogField   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:OnlineCoursesPlatform     5      b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ] YXceed.Wpf.Toolkit.NET5, Version=4.6.0.0, Culture=neutral, PublicKeyToken=3e4669d2f30244f44xctk)http://schemas.xceed.com/wpf/xaml/toolkit  5	      X	 TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/ 	 5
      c
 _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity 
 5      Hconv=clr-namespace:OnlineCoursesPlatform.Infrastructure.Converters 
 5      7vm.clr-namespace:OnlineCoursesPlatform.ViewModels 
 5      6sys,clr-namespace:System;assembly=System.Runtime 
 6H   $	��620��5        � 	Resources  5       �� MergedDictionaries �� SourceR  LOnlineCoursesPlatform.Infrastructure.Converters.BooleanToVisibilityConverter    BooleanToVisibilityConverter�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %   &	          5      60   5      .��5      � .+�5   
   � $��30, 10q�6   $	��650��6     � RowDefinitions 5      �� 5      $
��auto �6    �� 5      .+�5      �� $��0��6   .+�5      �  � ColumnDefinitions 5      �� 5       $��* �6+   �� 5!      $��* �6+   .+�5#      �� $��Courses Catalog��6   $��26(�66   $��0, 0, 0, 10q�6D   
������ $
��Bold"�6r   ���#22234A$��0��6�   �� 5$       �� Orientation$ 
Horizontal=�6!   $��1��6:   $��Right=�6J   .+�5%      ��  �� CornerRadius$ 10��6!   $	��0.3q�63   ���#78C6FF$��30��6_   y�6k   �� *IsSearchVisible+ �� 	Converter# [  ._�5&      �� $��5q�6&   $	��220��6s   $��20��6   
������ $��0q�6�   ��61   �� *
SearchText+ �� UpdateSourceTrigger$ PropertyChanged=�6�   5'      �� 5(      
������ $��0q�6:   $��5q�6N   $��20��6Y   ��6e   �� *SetVisibleSearchCommand+.��5)       	 FontAwesome5.ImageAwesome  	   Icon$	 Solid_Search=�6.   $��20��6B   
   
Foreground
 �#22234A6M   5*      5+      5,      �� 5-      $ 
Horizontal=�6   .+�5.      �� $��Sort by:��6   $��Light"�6/   $��14(�6B   � 50      .+�51      �� -   5        $��CategoryCombo��51   M     RoundedComboBox#���  6#   $	��140��52      $��1q�6   $��10, 0q�6+     ComboBoxAsCheckboxItemStyle#��[ 53   6   ��6   �� *CategorySearchList+ �� SelectedItem 6x   �� *CategorySelectedItem+. 
 (System.Windows.Interactivity.Interaction   Triggers 54      / 
 )System.Windows.Interactivity.EventTrigger  55   "      	EventName$ SelectionChanged��61   . 
 (System.Windows.Interactivity.TriggerBase   Actions. 56   &   6 
 0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *CategorySelChCommand+57   #   59      �� 5:      -   5         ��Name$ CategoryComboText��5:   $   $��Category��6?   $
��Left=�6O   $��55��6j   $
��15,0q�6u   $��Center=�6�   $��14(�6�   ���#8BABC1$��Light"�6�   5;      � 5>      .+�5?      �� -   5        $��	NameCombo��5?   M   #���  6#   $	��140��5@      ���#C3E6FF���#F3FAFF$��1q�5A   !   $��10, 0q�65   ��5B      �� *NameSearchList+ 63   �� *NameSelectedItem+ 5C        5D   "   $ SelectionChanged��61   . 5E   &      6<   �� *NameSelChCommand+5F   #   5H      �� 5I      -   5        $ NameComboText��5I   $   $
��Name��6;   $
��Left=�6G   $��40��6b   $
��15,0q�6m   $��Center=�6{   $��14(�6�   ���#8BABC1$��Light"�6�   5J      � 5L      .+�5M      �� -   5        $��DifficultyCombo��5M   M   #���  6#   $	��142��5N      ���#C3E6FF���#F3FAFF$��1q�5O      $��10, 0q�6   ��6.   �� *NameSearchList+ 6U   �� *ComplexitySelectedItem+ 5P        5Q   "   $ SelectionChanged��61   . 5R   &      6<   �� *ComplexitySelChCommand+5S   #   5U      �� 5V      -   5        $ DifficultyComboText��5V   $   $��
Difficulty��6A   $
��Left=�6S   $��50��6n   $
��15,0q�6y   $��Center=�6�   $��14(�6�   ���#8BABC1$��Light"�6�   5X      5[      5\      �� 5]      -   5        $��CatalogListView��5]   I    %� 
ScrollUnit$ Pixel=�6   $��1��6<   $��Disabled=�6`   $��Hidden=�5^      $��Center=�6J   
������ $
{�True��5_   k   $��0,0,0,10q�6|   ��6   �� *CoursesCatalogDT+��5`      �� 5a      .R�5b      �� $��1q�6!   $ 20��65   $	��530��6G   ���#F3FAFF$	��150��6h   $��	0, 30,0,5q�6u   
������ ._�5c      � $��0, 25, 0, 5q�6#    5d   "   �� 5e   &   $	��150 �67   �� 5f   &   �� 5g   &   $	��100 �67   .+�5j   "   �� $	��100��5l   (   $	��100��64   $��5q�6A   $��0��5m   (   ��5k   (   �� *
LogoPath+5m   (   �� 5n   "   $��5q�6-   $��1��68   .+�5o   &   �� $ 
Horizontal=�61   .+�5p   *   �� �� 5q   .   $��18(�6I   ���#22234A$��DemiBold"�6l   �63   �� *Name+6l    �� 5r   .   $�   / ��62   $
��Bold"�6?   $��18(�6Q   ���#22234A6_    �� 5s   .   $��14(�6Q   $��Light"�6_   ���#595976�62   �� *Category.Name+6r   5t   +   5u   '   �� 5v   &   $��45��5w   0   $
��Wrap=�6<   $��CharacterEllipsis=�6P   $��12(�6q   $��Light"�5x   0   ���#595976$��
0, 8, 0, 5q�6X   ��5v   0   �� *Description+5x   X   �� 5y   &   �� 5z   *   $	�★��6.   
��� ���$��18(�6I    �� 5{   *   ���#22234A$��12(�6h   �6.   �� *Rating+6h   5|   '   5}   #   �� 5�   "   $��40��6)   $��40��64   
������ ���#22234A$��2��5�   )   $��10q�69   $��Bottom=�6E   $��Right=�6`   ��5�   )   ��  �� Path$ DataContext.Navigate� �� RelativeSource ��  �� AncestorType UserControl��5�   )   �� ��5�   &     5�   *   $	 Solid_AngleRight=�6:   $��8��6R   

 �����6]     5�   &    �� 
TargetType �� Property �� Value��%_   '��       �� 5�   *   " ��60   .�5�   .   ��  �@��CornerRadius$ 20��6M   5�   +   5�   '   5�   #   �� 5�   "   $��2��6H   $	��Top=�6X   $��Right=�6p   $��0, 0, 20, 0q�6�   
������ ���#FF3F9B J� Opacity$	 0.4Q�6�   ��6,   �� *
Complexity+6�   5�      5�      5�      5�      5�      5�      5�      