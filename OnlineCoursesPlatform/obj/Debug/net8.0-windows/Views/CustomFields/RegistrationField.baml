   M S B A M L   `   `   `  ����P  LOnlineCoursesPlatform, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:OnlineCoursesPlatformOnlineCoursesPlatform  5      S.clr-namespace:OnlineCoursesPlatform.ViewModels OnlineCoursesPlatform.ViewModels  5	      -    'OnlineCoursesPlatform.RegistrationField   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      5local#clr-namespace:OnlineCoursesPlatform     5      X TFontAwesome5.Net, Version=2.1.11.0, Culture=neutral, PublicKeyToken=9cfaf01297a008f8.fa%http://schemas.fontawesome.com/icons/  5      7vm.clr-namespace:OnlineCoursesPlatform.ViewModels  5	        � 	Resources  5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $ \Styles\MainStyles.xaml?�6%   %    5      .��5      � .+�5   
   ��  J� Opacity$ 1Q�6   $	��700��6   $	��420��6)    �� CornerRadius$ 15��66   
�������$��2q�6\   ��5      �� 5       �� 
StartPoint$	 0,0&�6&    �� EndPoint$	 0,1&�67   .��5      �  � Color$ 	#13FFFFFF��6#    � Offset$ 0Q�65   � 5      $ 	#5FFFFFFF��6#   $ 1Q�65   5      ._�5      � 	 � RowDefinitions	 5      �� 5      $��60 �6$   �� 5      �� 5      $��70 �6$   
 � ColumnDefinitions
 5!      �� 5"      �� 5#      $	��200 �6'   .+�5&      ��  � Cursor$
 Hand��6<   ��6   �� *ToLoginCommand+��5'      �� 5(       �� 
TargetType" ��6*   .R�5)      �� $��15��6%   $��15��60   $
��Left=�6<   $	��Top=�6W   $��10, 20q�6o   .+�5*   "     FontAwesome5.ImageAwesome     Icon$ Solid_AngleLeft=�62   $��14��6I      
Foreground
 �����6T   5+      5,      5.      �� 50      -   5        $��HeaderLogIn��50   6    �� Orientation$ 
Horizontal=�6   $��Center=�6I   $��0��6f   $��0��6v   $��10q�6�   .+�51      �� $��Nice to meet you!��6    
�������$��Medium"�6L   $��30(�6a   
������ 6o   52      �� 54      -   5        $��InputsLogIn��54      $��Center=�60   $��0��6M   $��1��6]   $
��auto��6j   $
��auto��6w   $��0, 50q�6�   .+�55      �� $��	USER NAME��6    
�������$��Light"�6D   $��10, 5q�6W   �� 56      ���	#4DFFFFFF
�������$��1q�6H   $ 10��6\   $	��320��6n   $��30��6z   $��10, 0, 10, 10q�6�   ._�57      �� 
������ $��0q�6;   
�������$��
4,4, 4, -5q�6b   $��14(�6v   ��6�   �� *
UsNameTB+58      �� 59      $��PASSWORD��6    
�������$��Light"�6C   $��10, 5q�6V   �� 5:      ���	#4DFFFFFF
�������$��1q�6H   $ 10��6\   $	��320��6n   $��30��6z   $��10, 0, 10, 10q�6�   ._�5;      �� 
������ $��0q�6;   
�������$��
4,4, 4, -5q�6b   $��14(�6v   ��6�   �� *
PasswordTB+5<      �� 5=      ���	#4DFFFFFF
�������$��1q�6H   $ 10��6\   $	��320��6n   $��30��6z   $��10, 0, 10, 5q�6�   ._�5>      �� 
������ $��0q�6;   
�������$��
4,4, 4, -5q�6b   $��14(�6v   ��6�   �� *SecPasswordTB+5?      �� 5@      
������ $��10, 0q�6W   
���  ��$	��320��6w   
������ $|�False��5A   ;   ��5@      �� *ErrorStringTB+5A   ;   5B      �� 5D      $��0��6   $��2��6.   .+�5E      �� $��Sign up��6   $	��320��6/   $��30��6;   
����������#8D97F7
�������$��18(�5F   *   $��Medium"�68   $
 Hand��6L   ��5G      �� *RegisterUserCommand+��5H      �� 5I       �� 
TargetType" ��6$   .�5J   "   ��  �� Property � �� �� Value 5K   &   �� 5L   *   " ��6:   .R�5M   .   �� #��z��65   #��z��6_   #��z��5N      $ 10��6J   ._�5O   2   �� $��Center=�6C   $��Center=�6`   5P   /   5Q   +   5S   #   5T      5V      5X      �� 5Z      $ 10��6   
�������$	��200��6>   $��Right=�6J   $��3��6f   $��1��6w   5\      5^      5_      5`      