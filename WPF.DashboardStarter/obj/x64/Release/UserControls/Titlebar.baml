   M S B A M L   `   `   `  ���� O  KWPF.DashboardStarter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullU/clr-namespace:WPF.DashboardStarter.Localization!WPF.DashboardStarter.Localization  U/clr-namespace:WPF.DashboardStarter.UserControls!WPF.DashboardStarter.UserControls  0    *WPF.DashboardStarter.UserControls.Titlebar   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     ?loc/clr-namespace:WPF.DashboardStarter.Localization     Alocal/clr-namespace:WPF.DashboardStarter.UserControls     -     >�Name$  
MyTitleBar�� � 	Resources     BooleanToVisibilityConverter��%   &	        �� .���   PrimaryTitlebarBackground#��[   
BaseHeight#��[  � ColumnDefinitions �� $	��300 ��� $��* ��� $��* ���   ColumnWidth#��[ �� #��[ �� #��[ �� #��[ �� #��[ .+��� -   $��CompanyLogo��$
��Left=�$��2,2,2,2q�$��Uniform=�$��Bottom=�$��0������ *AppLogoPath+�� -   $��AppTitle��$��1��$��Center=�$��Center=�$��22(�  PrimaryTitlebarForeground#��[ ����  �� Path$ AppTitleText� �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=��� -   $��LoggedInUser��$��2��$��Center=�$��Center=�$��22(�#��[ ���� $ LoggedInUserText�$ TwoWay=�$ PropertyChanged=�y��� $ 
IsLoggedIn� �� 	Converter# [  �� -   $��LogoutButton��#��[" �$��Stretch=�$��Stretch=�/   )WPF.DashboardStarter.Localization.Strings   HoverText_Logout � ToolTip# Z $��3��	 K� ZIndex$	 0��y��� $ 
IsLoggedIn�# [  ���� $ RequestLogoutCommand�.���� -   $��
LogoutIcon��$��30��$��30��
 J� RenderTransformOrigin$
 0.5,0.5&�����  �� ElementName$ 
MyTitleBar��$ LogoutIconPath��� -   $��AboutButton��#��[" �   HoverText_About# Z $��Stretch=�$��Stretch=�$��4��$	 0������ $ RequestAboutCommand�.���� -   $��	AboutIcon��$��30��$��30��$
 0.5,0.5&����� $ 
MyTitleBar��$ AboutIconPath��� -	   $��MinimizeButton��#��[" �   HoverText_Minimize# Z $��Stretch=�$��Stretch=�$��5��$	 0��.���� -
   $��MinimizeIcon��$��40��$��40��$
 0.5,0.5&����� $ 
MyTitleBar��$ MinimizeIconPath��� -   $��MaximizeButton��#��[" �$��Stretch=�$��Stretch=�$��6��$	 0�� �� $ 
MyTitleBar��$ MaximizeIconTooltip�.���� -   $��MaximizeIcon��$��40��$��40��$
 0.5,0.5&����� $ 
MyTitleBar��$ MaximizeIconPath��� -   $��CloseButton��#��[" �   HoverText_Close# Z $��Stretch=�$��Stretch=�$��7��$	 0��.���� -   $��ExitIcon��$��40��$��40��$
 0.5,0.5&����� $ 
MyTitleBar��$ ExitIconPath�