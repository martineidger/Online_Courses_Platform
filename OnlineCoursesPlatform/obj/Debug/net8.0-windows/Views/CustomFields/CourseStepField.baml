   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullc6clr-namespace:OnlineCoursesPlatform.Views.CustomFields(OnlineCoursesPlatform.Views.CustomFields  5      >    8OnlineCoursesPlatform.Views.CustomFields.CourseStepField   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Hlocal6clr-namespace:OnlineCoursesPlatform.Views.CustomFields     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5        � 	Resources  5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %    5      .��5      � .+�5   
   �� $��Hidden=�6   .��5   
   �  � RowDefinitions 5      �� 5      $��20 �6    �� 5      $��70 �6    �� 5      $	��300 �6    �� 5      $
��auto �6    �� 5      $��55 �6    .+�5      �� 
������ 
������ $��14(�6o   ���#22234A$��
ExtraLight"�5   *   $��Center=�6B   $��20, 0q�6]   $��1��5       $
��Left=�6"   $��	SelCourse��6Z   ��5      �� *CurrentCourse.Name+��5    =   �� *
Navigate+6Z   �� 5"      $��Center=�6   $��1��66   .+�5#      ��  �� Orientation$ 
Horizontal=�6   $��Center=�66   .+�5$      �� 
������ $��0q�66   $��10, 5q�6J   .��5%        FontAwesome5.ImageAwesome     Icon$ Solid_AngleLeft=�6*   $��10��6A      
Foreground �#FF1F8B J� Opacity$	 0.6Q�6b   5&      �� 5'      ���#22234A$��Normal"�65   $��20(�6I   
������ �� 5(      $�Lesson ��6    �� 5)      �6   �� *
CourseStep+5*      �� 5+      
������ $��0q�66   $��Steps��6g   $��10, 5q�6�   ��6J   �� *
Navigate+.��5,        $ Solid_AngleRight=�6*   $��10��6B    �#FF1F8B$	 0.6Q�6c   5-      5.      �� 5/      ���#22234A$��0q�6.   $��1��6B   $	��100��6M   $��5q�6Y   �� 50      ���#22234A$��Light"�6b   $��16(�6u   $��Center=�6�   $��0,0,0,10q�6�   ��6   �� *
StepName+6�   51      � 54      -   5        $��2��54      $	��300��6    $	��620��6-   .+�55      r� -   5        $��mePlayer��55   V    r� LoadedBehavior$ Manual=�6>   	 r� Source	 6   �� *LoadedVideo+6V   �� 56      -   5        
 ��Name$
 ControlBorder��56      ���#F5F5F5$��50��6F   $	 0.2Q�6R   $��Bottom=�6`   ._�57      �� $��Bottom=�6!   .+�58      �� -   5        $��	lblStatus��58      $��Enter play..��6-   $��Center=�6D   $
��5, 0q�6h   
������ 6v   � 59      $��Center=�6    $��5q�6=   .+�5:      �� -   5        $��btnPlay��5:   !   
������ 
������ $��10, 0q�6y   .��5;        $ 
Solid_Play=�6.   $��15��6@   5<      �� 5=      -   5        $��btnPause��5=   %   
������ $��10, 0q�6e   
������ .��5>        $ Solid_Pause=�6.   $��15��6A   5?      �� 5@      -   5        $��btnStop��5@   %   
������ $��10, 0q�6c   
������ .��5A        $ 
Solid_Stop=�6.   $��15��6@   5B      5C      5D      5E      5F      �� 5H      $��3��6   .+�5I      �� ���#22234A$��18(�62   $��20, 5, 0, 0q�6@   �� 5J      $�Video lesson��6   $��Medium"�6/    �� 5K      $�summary:��6   $��Medium"�6*   ���#7E00356>   5L      �� 5M      ���#FFF6FA �� CornerRadius$ 0��6.   $��0, 10q�6?   ._�5N      �� $
��Wrap=�5R   ^   $��Light"�5S       $��16(�64   $��20, 15q�6B   ���#2D0013 �� TextAlignment$ Justify=�6g   ��5N       �� *
StepText+5S   g   5U      5V      �� 5[      $ 
Horizontal=�6   $
��25,5q�63   $��4��6A   $��Center=�6O   .+�5\      �� ���#F8F4FC   RoundCheckBoxStyle#��[  60   $��15��6\   $��15��6g   $
��Left=�6s    d� 	IsChecked 6�   �� *IsStepCompleted+ �� Mode$ TwoWay=��� 5]      $��Mark as completed��6   ���#7E0035$��Regular"�6J   $��10, 0q�6_   $��13(�6n   5^      �� 5`      $��Steps��6Q   $	��100��5a      $��25��6!   $��Right=�6-   $��20,10q�6I   $��4��6X   ���#C36E96$��0q�5b   *   
�������$��Medium"�6Q   ��5`      �� *
ButtonText+��64   �� *
Navigate+  5c       �� 
TargetType �� Property �� Value��%_   '��       �� 5d      " ��6   .�5e      ��  �@��CornerRadius$ 10��69   5f      5g      5h      5j      5k      5l      5m      