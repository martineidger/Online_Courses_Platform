   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullY1clr-namespace:OnlineCoursesPlatform.Views.Windows#OnlineCoursesPlatform.Views.Windows  5   	   5    /OnlineCoursesPlatform.Views.Windows.ReplyWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Clocal1clr-namespace:OnlineCoursesPlatform.Views.Windows     5   	     � Title$  ReplyWindow��5   	   $	��200��6   $	��300��6*    � WindowStyle$
 None=�5	   	    � AllowsTransparency$
 True��6    � 
ResizeMode$ NoResize=�66   
������  � 	Resources 5
       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %    5      .��5      ��  �� CornerRadius$ 10��6   
�������
�������$	��0.3q�6F   ._�5   
   �  � ColumnDefinitions 5      �� 5      �� 5      	 � RowDefinitions	 5      �� 5      $��20 �6    �� 5      $��30 �6    �� 5      �� 5      $��50 �6    .+�5      �� $��2��6   $��0��6)   ���#270461._�5      � .+�5       �� $��Reply��6    $��Center=�6-   
�������6J   �� 5!      $��x��6   $��20��6J   $��20��6U   
�������$��Right=�6u   
������ $��0q�6�   ��6)   �� *CloseCommand+6�   5"      5#      �� 5%      $��1��6   $��0��6&   
 �� Orientation$
 
Horizontal=�66   .+�5&      �� $��from:��6   ���#270461$��Light"�6>   �� 5'      ���#270461$��10, 0, 0, 0q�63   ��6H   �� *CurUser.Username+5(      �� 5)      $��1��6   $��1��6&   $
 
Horizontal=�66   .+�5*      �� $	��to:��6   ���#270461$��Light"�6<   �� 5+      ���#270461$��10, 0, 0, 0q�63   ��6H   �� *CommentUser.Username+5,      �� 5.      $ 10��6   $��5q�6'   $��2��62   $��2��6F   $��1q�6S   
�������._�5/      �� $��5q�65   ��6   �� *	ReplyText+65   50      �� 52      $
��Exit��6   $��0��6E   $��3��6U   
������ 
���������6$   �� *CloseCommand+6{   �� 53      $
��Send��6   $��1��6I   $��3��6Y   ���#270461
�������$��5q�6�   ��6$   �� *SendReplyCommand+6�   54      56      57      