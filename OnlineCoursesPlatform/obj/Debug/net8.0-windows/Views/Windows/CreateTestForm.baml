   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:OnlineCoursesPlatform.Views.Windows#OnlineCoursesPlatform.Views.Windows  5   	   8    2OnlineCoursesPlatform.Views.Windows.CreateTestForm   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:OnlineCoursesPlatform.Views.Windows     5   	   X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5   	     � Title$  CreateTestForm��5	   	   $	��300��6    $	��620��6-    � WindowStyle$
 None=�5
   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ NoResize=�66   
������  � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %    5      .��5      ��  �� CornerRadius$ 10��6   
�������
�������$��1q�6E   ._�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      .+�5      �� $��23��6:   
������ $��22��5      $��10q�6!   $��1��6-   
������ $	��Top=�5      $��Right=�6-   ��5      �� *CloseFormCommand+.��5        FontAwesome5.ImageAwesome  	   Icon$	 Solid_WindowClose=�6"   $��20��6;   
   
Foreground
 �#2D00136F   5      �� 5      $��10, 15q�6   ���#D8EEFF.+�5       �� $��20q�6   .+�5!      �� $��
Question: ��6    �� 5"      ._�5#      �� 
������ 
������ ��6"   �� *QuestionText+ �� UpdateSourceTrigger$ PropertyChanged=�6~   5$      �� 5%      $	��250��6   $��1��6)   
���   �64   �� 5'      $��Answer: ��6    �� 5(      ._�5)      �� $��50��6c   
������ 
������ ��6"   �� *
AnswerText+$ PropertyChanged=�6�   5*      �� 5+      $	��250��6   $��1��6)   
���   �64   5-      �� 5/      $	��Add��6   $��70��6N   $��30��6Y   $��5q�6e   ��6'   �� *AddQuestionCommand+ 50       �� 
TargetType �� Property �� Value��%^   '��       �� 51      " ��6    .�52      ��  �@��CornerRadius$ 7��6=   53      54      55      57      �� 58      $��1��6?   $��Center=�59      $	��240��64   $	��Top=�6A   $	��220��6Y   $��5, 15q�6e   ��58      �� *AddingQuestions+ �� SelectedItem 6z   �� *SelectedQuestion+��5:      �� 5;      .R�5<      ��  �� Orientation$ 
Horizontal=�6%   $��10, 4q�6>   .+�5=      �� ��6(   �� *QuestionText+�� 5>      $��  :     ��6(   �� 5?      $
��Wrap=�6@   ��6(   �� *Answer+6@   5@      5A      5C      �� 5D      $ 
Horizontal=�6   $��1��62   $��25��6B   $��Bottom=�6N   $��Center=�6i   $��10q�6�   .+�5E      �� $��	Save test��6   $��70��6-   $��
10, 0, 5,0q�68   ��6L   �� *SaveTestCommand+ 5F      ��%^   '��       �� 5G      " ��6    .�5H      ��  �@��CornerRadius$ 7��6=   5I      5J      5K      �� 5L      $��70��6   $��
5, 0,10, 0q�6$   
�������
���  ����68   �� *DeleteQuestionCommand+ 5M      ��%^   '��       �� 5N      " ��6    .�5O      ��  �@��CornerRadius$ 7��6=   5P      5Q      .��5R        $	 Solid_TrashAlt=�6&   $��14��6<   

 �  ��6G   5S      5T      5U      5X      5Y      