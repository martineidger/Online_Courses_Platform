   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:OnlineCoursesPlatform.Views.CustomFields(OnlineCoursesPlatform.Views.CustomFields  5      q=clr-namespace:OnlineCoursesPlatform.Infrastructure.Converters/OnlineCoursesPlatform.Infrastructure.Converters  5
      U QSystem.Runtime, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a7,clr-namespace:System;assembly=System.RuntimeSystem 5      S.clr-namespace:OnlineCoursesPlatform.ViewModels OnlineCoursesPlatform.ViewModels  5      <    6OnlineCoursesPlatform.Views.CustomFields.SettingsField   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:OnlineCoursesPlatform.Views.CustomFields     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5      c _System.Windows.Interactivity, Version=4.5.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35Bi:http://schemas.microsoft.com/expression/2010/interactivity  5	      Hconv=clr-namespace:OnlineCoursesPlatform.Infrastructure.Converters  5
      6sys,clr-namespace:System;assembly=System.Runtime  5      7vm.clr-namespace:OnlineCoursesPlatform.ViewModels  5        � 	Resources  5       �� MergedDictionaries �� SourceQ   KOnlineCoursesPlatform.Infrastructure.Converters.AccessToVisibilityConverter   AccessToVisibilityConverter�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %   &	          5      6/   5      .��5      �  � RowDefinitions 5   
   �� 5      $��70 �6   �� 5      �� 5      $��50 �6    � ColumnDefinitions 5   
   �� 5      $��3* �6   �� 5      .+�5!   
   �� $��26(�6*   ���#22234A$��Center=�6_   $
��Bold"�5"      $��2��6&   $��0��6:   $��30,10q�6G   ��5!      �� *Text+5"   G   �� 5#   
   
������ $��1��6/   $��2��6<   $
��30,0q�6P   .@�5$      �� $��Your profile��6   $	��100��6,   $��14(�68   .��5%      �� $
��Left=�6   $��20, 0q�68   .+�5(      ��  �� Orientation$ 
Horizontal=�6!   $��35��6:   $	��Top=�6F   $��5q�6^   $��Right=�6j   .+�5)      �� $��Status: ��6$   $��Center=�64   $��2q�6O   �� 5*      $��22��6J   $	��200��6V   ��6#   �� *StatusesValues+ �� SelectedItem 6b   �� *SelectedStatus+5+      �� 5-      $ 
Horizontal=�6!   $��35��6:   $	��Top=�6F   $��5q�6^   $��Right=�6j   .+�5.      �� $��Organisation: ��6$   $��Center=�6:   $��2q�6U   �� 5/      $��22��6e   $	��200��6q   ��6"   �� *Organisation+ �� UpdateSourceTrigger$ PropertyChanged=�6q   50      �� 51      $��Save changes��6   $��5q�6[   $��25��6f   ��64   �� *SaveChangesCommand+  52       �� 
TargetType	 �� Property
 �� Value��%_   '��       �� 53      " ��6$   .�54   "   �� 	 �@��CornerRadius$
 10��6A   55      56      57      58      5:      �� 5;      $��Access settings��6   $��14(�6/   $	��120��6=   y�6I   �� *	CurUser+ �� 	Converter# [  .��5<      �  5=      �� 5>      $��3* �6+   �� 5?       5A      �� 5B      �� 5C      .+�5F      �� $ 
Horizontal=�6!   $��0��6:   $��0��6J   $��25��6W   $	��Top=�6c   $
��5, 0q�6{   $
��Left=�6�   .+�5G      �� $��16(�6$   �� 5H      $�Users��6"    �� 5I      $	� / ��6"   $��Light"�6-   5J      �� 5K       �� DisplayMemberPath$
 Name��6E   $��20��6^   $	��100��6j   ��6#   �� *	CoursesCB+ 6v   �� *SelectedCourseCB+.  (System.Windows.Interactivity.Interaction   Triggers 5L      /  )System.Windows.Interactivity.EventTrigger  5M   "      	EventName$ SelectionChanged��61   .  (System.Windows.Interactivity.TriggerBase   Actions. 5N   &   6  0System.Windows.Interactivity.InvokeCommandAction     Command 6<   �� *!CourseCBSelectionChangedCommand+5O   #   5Q      5R      &   System.Windows.Controls.DataGrid  5S         
IsReadOnly$
 True��6      AutoGenerateColumns$ False��61   $��0��6m   $��0��6}   $��5, 25, 5, 5q�6�   ��6M   �� *	UsersDT+ 6�   �� *SelectedUser+   Columns 5T      0  *System.Windows.Controls.DataGridTextColumn  5U      ,  &System.Windows.Controls.DataGridColumn   Header$ UserName��61   1	  +System.Windows.Controls.DataGridBoundColumn 	  Binding 6C   �� *
UserName+  5V      $ Status��61    6A   �� *Status+  5W      $ Organisation��61    6G   �� *Organisation+ 5Y        5Z      $ SelectionChanged��6-   . 5[   "      68   �� *UserSelectionChangedCommand+5\      5^      �� 5`      $��1��6!   $��0��61   $��5, 25q�6>   .+�5a      �� $��40��5b   !   $	��0,5q�6-   ���#22234A
�������
������ ��5a   !   �� *SetAccessStatusButton+��6^   �� *SetAccessStatusCommand+��6�   �� *SetAccessStatusButton+  5c      ��%_   '��       �� 5d   "   " ��6(   .�5e   &   �� 	 �@��CornerRadius$
 10��6E   5f   #   5g      5h      �� 5i      $��Block��6!   
�������
���  ��
���  ��$��40��5j      $
��0, 5q�6)   ��5i   1   �� *BlockCommand+  5k      ��%_   '��       �� 5l   "   " ��6(   .�5m   &   �� 	 �@��CornerRadius$
 10��6E   5n   #   5o      5p      �� 5q      $��Delete user��6!   
�������
���  ��
���  ��$��40��5r   !   $
��0, 5q�6-   ��5q   7   �� *DeleteUserCommand+��6]   �� *SelectedUser+  5s      ��%_   '��       �� 5t   "   " ��6(   .�5u   &   �� 	 �@��CornerRadius$
 10��6E   5v   #   5w      5x      5y      �� 5|      $ 
Horizontal=�6!   $��0��6:   $��1��6J   $��25��6W   $	��Top=�6c   $
��5, 0q�6{   $
��Left=�6�   .+�5}      �� $��16(�6$   �� 5~      $�Courses��6"   5      5�        5�      $
 True��6   $ False��61   $��0��6�   $��2��6�   $��5, 25, 5, 5q�6�   ��6M   �� *	CoursesDT+ 6o   �� *SelectedCourse+ 5�        5�      $
 Name��61    6?   �� *Name+  5�      $ Category ID��61    6F   �� *
CategoryId+  5�      $ Rating��61    6A   �� *Rating+4
  .System.Windows.Controls.DataGridCheckBoxColumn
  5�      $ Open access��65    6J   �� *IsOpen+  5�      $ Author��61    6A   �� *Author+5�      �� 5�      $��1��6!   $��1��61   $��5, 25q�6>   .+�5�      �� $
��Edit��6!   ���#22234A
�������$��40��5�   !   ��5�   1   �� *EditCourseCommand+  5�      ��%_   '��       �� 5�   "   " ��6(   .�5�   &   �� 	 �@��CornerRadius$
 10��6E   5�   #   5�      5�      �� 5�      $��Delete course��6!   
�������
���  ��
���  ��$��40��5�      $
��0, 5q�6)   ��5�   9   �� *DeleteCourseCommand+  5�      ��%_   '��       �� 5�   "   " ��6(   .�5�   &   �� 	 �@��CornerRadius$
 10��6E   5�   #   5�      5�      5�      5�      5�      5�      �� 5�   
   $ 
Horizontal=�6   $��3��6.   $��0��6;   .+�5�      �� $��20��67   $
��Left=�5�      $��30, 5, 10, 5q�61   
������ 
������ ��5�      �� *LogOutCommand+.��5�        FontAwesome5.ImageAwesome     Icon$ Solid_SignOutAlt=�6"   $��20��6:      
Foreground
 �����6E   5�      �� 5�      $��1��6   $��20��6   
�������
������ 6=   �� 5�      
������ 
������ $��20��6H   $��10, 5q�5�      ��5�      �� *DeleteAccountCommand+.��5�      �� $��Delete account��6   $��	Underline{�62   
�������6N   5�      5�      �� 5�   
   $��
Add course��6   $��	AddCourse��6C   ���#22234A
����������#22234A$��30��5�      $	��100��6   $��3��6)   $��1��66   ��5�   &   �� *
Navigate+y�5�      �� *	CurUser+# [    5�      ��%^   '��       �� 5�      " ��6   .�5�      �� 	 �@��CornerRadius$
 7��65   5�      5�      5�      5�      5�      