   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:OnlineCoursesPlatform.Views.CustomFields(OnlineCoursesPlatform.Views.CustomFields  5      S.clr-namespace:OnlineCoursesPlatform.ViewModels OnlineCoursesPlatform.ViewModels  5	      ;    5OnlineCoursesPlatform.Views.CustomFields.ArchiveField   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:OnlineCoursesPlatform.Views.CustomFields     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5      7vm.clr-namespace:OnlineCoursesPlatform.ViewModels  5	        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %    5      .��5      � .+�5   
   � $��30, 10q�6   $	��650��6     � RowDefinitions 5      �� 5      $
��auto �6    �� 5      .+�5      �� $��0��6   .+�5      �� $��Archived courses��6   $��26(�63   $��0, 0, 0, 10q�6A   
������ $
��Bold"�6o   ���#22234A6�   5      �� 5      -   5        $��CatalogListView��5   I    %� 
ScrollUnit$ Pixel=�6   $��1��6<   $��Disabled=�6`   $��Hidden=�5      $��Center=�6J   
������ $
{�True��5   k   $��0,0,0,10q�6|   ��6   �� *CoursesCatalogDT+��5      �� 5       .R�5!      �� $��1q�6!    �� CornerRadius$ 20��65   $	��530��6G   ���#F3FAFF$	��150��6h   $��	0, 30,0,5q�6u   
������ ._�5"      � $��0, 25, 0, 5q�6#    � ColumnDefinitions 5#   "   �� 5$   &   $	��150 �67   �� 5%   &   �� 5&   &   $	��100 �67   .+�5)   "   �� $	��100��5+      $	��100��6!   $��5q�6.   $��0��5,      ��5*      �� *
LogoPath+5,      �� 5-   "   $��5q�6-   $��1��68   .+�5.   &   ��  �� Orientation$ 
Horizontal=�61   .+�5/   *   �� �� 50      $��18(�66   ���#22234A$��DemiBold"�6Y   �6    �� *Name+6Y    �� 51      $�   / ��6   $
��Bold"�6,   $��18(�6>   ���#22234A6L    �� 52      $��14(�6>   $��Light"�6L   ���#595976�6   �� *Category.Name+6_   53   +   54   '   �� 55   &   $��45��56      $
��Wrap=�6)   $��CharacterEllipsis=�6=   $��12(�6^   $��Light"�57      ���#595976$��
0, 8, 0, 5q�6E   ��55   0   �� *Description+57   E   �� 58   &   �� 59      $	�★��6   
��� ���$��18(�66    �� 5:      ���#22234A$��12(�6U   �6   �� *Rating+6U   5;   '   5<   #   �� 5?   "   $��40��6)   $��40��64   
������ ���#22234A$��2��5C      $��10q�6&   $��Bottom=�62   $��Right=�6M   ��5A      ��  �� Path$ DataContext.Navigate�	 �� RelativeSource	 �� 
 �� AncestorType
 UserControl��5B      �� ��5D   &     FontAwesome5.ImageAwesome  5E   *      Icon$ Solid_AngleRight=�6:   $��8��6R      
Foreground
 �����6]     5G   &    �� 
TargetType �� Property �� Value��%_   '��       �� 5H   *   " ��60   .�5I   .   ��  �@��CornerRadius$ 20��6M   5J   +   5K   '   5L   #   �� 5M   "   $��2��6H   $	��Top=�6X   $��Right=�6p   $��0, 0, 20, 0q�6�   
������ ���#FF3F9B J� Opacity$	 0.4Q�6�   ��6,   �� *
Complexity+6�   5N      5O      5Q      5S      5U      5V      5W      