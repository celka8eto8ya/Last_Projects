   M S B A M L   `   `   `  ����   NAudioWpfDemoG    ANAudioWpfDemo.MediaFoundationPlayback.MediaFoundationPlaybackView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .���   � RowDefinitions  �� $
��Auto ��� $
��263* �.+��� $
��Left=�$��	10,10,0,0q�$
��Wrap=�$q��kDemonstrates the use of the MediaFoundationReader for playback, repositioning. Currently a work in progress��$	��Top=��� $��1��$	��...��$��0,10.08,10,0q�$	��Top=�$��Right=�$��34������ *LoadCommand+�� $��1��$
��Play��$
��Left=�$��11,73.08,0,0q�$	��Top=�$��75������ *PlayCommand+�� $��1��$��Pause��$
��Left=�$��91,73.08,0,0q�$	��Top=�$��75������ *PauseCommand+�� $��1��$
��Stop��$
��Left=�$��171,73.08,0,0q�$	��Top=�$��75������ *StopCommand+�� $��1��$'��!Default PCM decompression format:��$
��Left=�$��11,34.08,0,0q�$	��Top=��� $��1��$
��Left=�$��211,34.08,0,0q�$	��Top=����� *DefaultDecompressionFormat+�� -   $��waveFormCanvas��$��1��
���   �$
��Left=�$��48��$��11,127.08,0,0q�$	��Top=�$	��480���� $��1��$��11,100.08,19,0q�$	��Top=� � Value �� *SliderPosition+ �� Mode$ TwoWay=��� $��1��$��Request IEEE Float��$
��Left=�$��367,76.08,0,0q�$	��Top=�{��� *	IsStopped+ d� 	IsChecked �� *RequestFloatOutput+$ TwoWay=��� $
��Left=�$��11,11.08,0,0q�$��1��$
��Wrap=�$��Selected File or URL:��$	��Top=��� $��126,10.08,49,0q�$��1��$	��Top=� �� 
IsEditable .  �� Text �� *	InputPath+$ TwoWay=����� *InputPathHistory+