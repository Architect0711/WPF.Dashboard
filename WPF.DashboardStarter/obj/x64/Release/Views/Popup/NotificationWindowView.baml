   M S B A M L   `   `   `  ���� E  AWPF.Basics, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE1clr-namespace:WPF.Basics.MVVM;assembly=WPF.BasicsWPF.Basics.MVVM  O KWPF.DashboardStarter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullS.clr-namespace:WPF.DashboardStarter.Views.Popup WPF.DashboardStarter.Views.Popup =   7WPF.DashboardStarter.Views.Popup.NotificationWindowView   :mvvm1clr-namespace:WPF.Basics.MVVM;assembly=WPF.Basics  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     @local.clr-namespace:WPF.DashboardStarter.Views.Popup     $
��Auto��$
��Auto��  � DataContext  ��    ViewModelLocator �� Source# [   �� Path$ Notification� � 	Resources    BooleanToVisibilityConverter��%   &	       �� .���   SecondaryBackground#��[  � RowDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto ��� $
��Auto � � ColumnDefinitions �� $
��Auto ��� $
��Auto ��� $
��Auto �.+��� -   $��NotificationImage��$��Right=�$��	0,20,20,0q�$��64��$��64��$��Uniform=�$��Bottom=�$��1��$��0������ *NotificationImage+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $��TxtNotificationTitle��$��	30,40,0,0q�$��20(�$��0��$��0������ *NotificationTitle+$ OneWay=�$ PropertyChanged=��� -   $��TxtNotificationText��$
��Wrap=�$��	30,20,0,0q�$��16(�$��0��$��2������ *NotificationText+$ OneWay=�$ PropertyChanged=�� $��Right=�$��3��$��0��$��4��$��0,15,5,5q� �� �� �� .+��� -   $��	BtnCancel��#��[" �  SecondaryButtonBackground#��[   SecondaryButtonForeground#��[ $��	12,7,12,7q�$��17(�$��0��$��4������ $ CancelButton�$ OneWay=�$ PropertyChanged=����� $ CancelCommand�y��� $ 	CanCancel� �� 	Converter# [ 	 � ToolTip	 �� *
CancelInfo+$ OneWay=�$ PropertyChanged=��� -   $��
BtnDecline��#��[" �#��[ #��[ $��	12,7,12,7q�$��17(�$��1��$��4������ $ DeclineButton�$ OneWay=�$ PropertyChanged=����� $ DeclineCommand�y��� $ 
CanDecline�# [ 	 �� *DeclineInfo+$ OneWay=�$ PropertyChanged=��� -   $��
BtnConfirm��#��[" �#��[ #��[ $��	12,7,12,7q�$��17(�$��2��$��4������ $ ConfirmButton�$ OneWay=�$ PropertyChanged=����� $ ConfirmCommand�y��� $ 
CanConfirm�# [ 	 �� *ConfirmInfo+$ OneWay=�$ PropertyChanged=�