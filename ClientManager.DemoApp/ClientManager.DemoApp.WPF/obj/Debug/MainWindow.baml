   M S B A M L   `   `   `  ����T  PClientManager.DemoApp.WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullW0clr-namespace:ClientManager.DemoApp.Domain.Enums"ClientManager.DemoApp.Domain.Enums  5   	   *    $ClientManager.DemoApp.WPF.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Blocal0clr-namespace:ClientManager.DemoApp.Domain.Enums     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  ClientManager��5   	   $	��700��6   $	��800��6,   $��20(�68   .��5	      �  � ColumnDefinitions 5
   
   �� 5      �� 5       � RowDefinitions 5   
   �� 5      $	��28* �6   �� 5      $
��306* �6   �� 5      $
��335* �6   .+�5   
   ��  �� DisplayMemberPath$ 	FirstName��63   $��0��6Q   $��3��6a   
����� ���6   �� *	Clients+6r   �� 5   
   
�������$��1��6)   $��0��69   $��2��6F   .+�5      �� -   5        $��
cmdcommand��5      $��Right=�5      $��30��61   $	��Top=�6=   ��5      �� 5       �� Orientation$ 
Horizontal=�6!   .+�5      �� $��Import from xml file��6$   5      ��5      �� 5        �� 
StartPoint$	 0,0&�6*    �� EndPoint$	 1,1&�6;   .��5!      �  � Color$ 	#FFD9EDFF��6'    � Offset$ 0Q�69   � 5"      $ 	#FFC0DEFF��6'   $ 0.445Q�69   � 5#      $ 	#FFAFD1F8��6'   $
 0.53Q�69   5$      5&      �� 5'      .��6   Name6   �� 5(      ��6   �� *Name+�� 5)      .��6   Date of entry6#   �� 5*      ��6   �� *DateOfEntry+�� 5+      -   5        $��Export to JSON��5+   *   $��0 50 0 0q�6C   5,      �� 5.   
   $��1��6   $��1��6%   $��Bottom=�62   $��	0 0 0 100q�6M   $��2��6`   .+�5/      �� .��6   
First Name6    �� 50      -   5        $��	FirstName��50      ��6'   �� *NewClient.FirstName+	 �� Mode$	 TwoWay=�
 �� UpdateSourceTrigger$
 PropertyChanged=��� 51      .��6   	Last Name6   �� 52      -   5        $��LastName��52      ��6&   �� *NewClient.LastName+$	 TwoWay=�$
 PropertyChanged=��� 53      .��6   Client type6!   �� 54      -   5        $��
ClientType��54      $��0 0 0 10q�6)   ��6;   �� *ClientTypes+�� 55      -   5        $��Create new client��55   J   ��6   �� *SaveCommand+6J   56      57      58      