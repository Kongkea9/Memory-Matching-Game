   M S B A M L   `   `   `  ����M  IMemoryMatchingGame, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:MemoryMatchingGameMemoryMatchingGame  5   	   !    MemoryMatchingGame.frmCover   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   2local clr-namespace:MemoryMatchingGame     5   	     � Title$  frmCover��5   	   $	��800��6   $
��1000��6&   
����ح� � WindowState$ 	Maximized=�5
   	    � WindowStyle$
 None=�5   	   .��5   
   � ��5      �� 5       �� ImageSource$ CoverImage/Cover.png��6    j� Stretch$
 Fill=�6@   .+�5      �� $��Center=�6   $��Center=�5      $��	0,420,0,0q�5      .+�5      �� -   5        $��btnQuickGame��5      $��
Quick Game��5      $	��200��5      $��60��6%   ���#4EB1FA$��20(�5!      $
��Bold"�6'   
������� � Cursor$
 Hand��5#       J� Effect 5&      3  -System.Windows.Media.Effects.DropShadowEffect  5'         Color$ Black��6+      
BlurRadius$ 10Q�5(   +   	   ShadowDepth$	 5Q�5)   +   
   Opacity$	
 0.5Q�5*   +   ��5-      �� 5.       �� 
TargetType" ��6*   .R�5/      ��  ��Name$ border��6%   #��z��50   %    �� CornerRadius$ 18��51   %   
�������$��3q�53   %   ._�54   "   �� $��Center=�63   $��Center=�55   3   56       �� Triggers 57      P� 59       P� Property �@J�IsMouseOver P� Value . . �5:   "   ��  �� 
TargetName$ border��6)    �� Property � �� �� Value �#3A91C86S   �� 5;   "    �@�Cursor$
 Hand��6;   5<      5?      5A      �� 5C      -   5        $��
btnPlayers��5D      $��	2 Players��5C      $	��200��5E      $��60��6%   ���#3BB54A$��20(�5G      $
��Bold"�6'   
�������$
 Hand��5I      $��16q�5J       5M        5N      $ Black��6+   $ 10Q�5O   +   $	 5Q�5P   +   $	
 0.5Q�5Q   +   ��5T      �� 5U      " ��6*   .R�5V      �� $ border��6%   #��z��5W   %   $ 18��5X   %   
�������$��3q�5Z   %   ._�5[   "   �� $��Center=�63   $��Center=�5\   3   5]       5^      P� 5`       �@J�IsMouseOver . . �5a   "   �� $ border��6)    � �� �#3194436S   �� 5b   "    �@�Cursor$
 Hand��6;   5c      5f      5h      �� 5i      -   5        $��btnQuit��5j      $
��Quit��5i      $	��200��5k      $��60��6%   ���#F7C503$��20(�5m      $
��Bold"�6'   
�������$
 Hand��5o       5r        5s      $ Black��6+   $ 10Q�5t   +   $	 5Q�5u   +   $	
 0.5Q�5v   +   ��5y      �� 5z      " ��6*   .R�5{      �� $ border��6%   #��z��5|   %   $ 18��5}   %   
�������$��3q�5   %   ._�5�   "   �� $��Center=�63   $��Center=�5�   3   5�       5�      P� 5�       �@J�IsMouseOver . . �5�   "   �� $ border��6)    � �� �#D6A8026S   �� 5�   "    �@�Cursor$
 Hand��6;   5�      5�      5�      5�      5�      5�      