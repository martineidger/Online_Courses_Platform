   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OnlineCoursesPlatformOnlineCoursesPlatform  5      S.clr-namespace:OnlineCoursesPlatform.ViewModels OnlineCoursesPlatform.ViewModels  5      &     OnlineCoursesPlatform.LoginField   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:OnlineCoursesPlatform     5      =vm.clr-namespace:OnlineCoursesPlatform.ViewModels     5        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %    5      .��5      � .+�5   
   ��  J� Opacity$ 1Q�6   $	��700��6   $	��420��6)    �� CornerRadius$ 15��66   
�������$��2q�6\   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5      �  � Color$ 	#13FFFFFF��6#    � Offset$ 0Q�65   � 5      $ 	#5FFFFFFF��6#   $ 1Q�65   5      ._�5      � 	 � RowDefinitions	 5      �� 5      $��60 �6$   �� 5      �� 5      $��70 �6$   
 � ColumnDefinitions
 5!      �� 5"      �� 5#      $	��200 �6'   .+�5&      �� -   5        $��HeaderLogIn��5&   6    �� Orientation$ 
Horizontal=�6   $��Center=�6I   $��0��6f   $��0��6v   $��10q�6�   .+�5'      �� $��Hello!��6    
�������$��Medium"�6A   $��30(�6V   
������ 6d   5(      �� 5*      -   5        $��InputsLogIn��5*      $��Center=�60   $��0��6M   $��1��6]   $
��auto��6j   $
��auto��6w   $��0, 30q�6�   .+�5+      �� $��	USER NAME��6    
�������$��Light"�6D   $��10, 5q�6W   �� 5,      ���	#4DFFFFFF
�������$��1q�6H   $ 10��6\   $	��320��6n   $��30��6z   $��10, 0, 10, 10q�6�   ._�5-      �� 
������ $��0q�6;   
�������$��
4,4, 4, -5q�6b   $��14(�6v   ��5.   "   �� *
UsNameTB+5/      �� 50      $��PASSWORD��6    
�������$��Light"�6C   $��10, 5q�6V   �� 51      ���	#4DFFFFFF
�������$��1q�6H   $ 10��6\   $	��320��6n   $��30��6z   $��10, 0, 10, 10q�6�   ._�52      �� 
������ $��0q�6;   
�������$��
4,4, 4, -5q�6b   $��14(�6v   ��53   &   �� *
PasswordTB+54      �� 55      
������ $��10, 0q�6W   
���  ��$	��320��6w   
������ $|�False��56   8   ��55      �� *ErrorStringTB+56   8   5;      �� 5=      $��0��6   $��2��6.   .+�5>      �� $��Log in��6   $	��320��6.   $��30��6:   
����������#8D97F7
�������$��18(�5?   *   $��Medium"�68    � Cursor$
 Hand��6L   ��5@      �� *LoginCommand+��5A      �� 5B       �� 
TargetType" ��6$   .�5C   "   ��  �� Property � �� �� Value 5D   &   �� 5E   *    �� 
TargetType" ��6:   .R�5F   .   �� #��z��65   #��z��6_   #��z��5G      $ 10��6J   ._�5H   2   �� $��Center=�6C   $��Center=�6`   5I   /   5J   +   5L   #   5M      5O      �� 5P      
�������$��Center=�63   $��10q�6P   $��14(�6\   �� 5Q      $�Don’t have an account? ��6    �� 5R      $�Create!��6    �� TextDecorations$ 	Underline{�6&   $��Medium"�6B    � Cursor$
 Hand��6V   .�6e    �� InputBindings 5S      d� 5T       d� Gesture$ 	LeftClicka�6)    �� Command 6=   �� *ToRegCommand+.�5U   *   5V      5W      5X      �� 5Z      $ 10��6   
�������$	��200��6>   $��Right=�6J   $��3��6f   $��1��6w   5\      5^      5_      5`      