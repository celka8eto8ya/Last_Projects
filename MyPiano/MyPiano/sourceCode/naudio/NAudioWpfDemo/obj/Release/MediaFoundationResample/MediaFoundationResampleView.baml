   M S B A M L   `   `   `  ����   NAudioWpfDemoG    ANAudioWpfDemo.MediaFoundationResample.MediaFoundationResampleView   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     @d2http://schemas.microsoft.com/expression/blend/2008     .���   � RowDefinitions  �� $
��Auto ��� $��* �.+��� $��5q�$����For testing the MediaFoundationResampler class. Select any file that Media Foundation can play, and then click Resample to create a WAV file at the desired sample rate. The Media Foundation Resampler also supports changing bit depth and channel count.��$
��Wrap=�$	��Top=��� $��1��$��Input File:��$
��Left=�$��	10,10,0,0q�$	��Top=��� $��1��$��23��$��137,10.12,43,0q� �� TextWrapping$
 Wrap=�$	��Top=� �� 
IsReadOnly . ���� *	InputFile+�� $��1��$	��...��$��	0,10,10,0q�$	��Top=�$��Right=�$��28������ *SelectInputFileCommand+�� $��1��$��Output Sample Rate:��$
��Left=�$��10,72.12,0,0q�$	��Top=��� $��1��$
��Left=�$��137,72.12,0,0q�$	��Top=�$	��120������ *SampleRates+ �� SelectedItem �� *
SampleRate+ �� Mode$ TwoWay=��� $��1��$��Resample��$
��Left=�$��10,165.12,0,0q�$	��Top=�$��75������ *ResampleCommand+�� $��1��$��Input File Format:��$
��Left=�$��10,41.12,0,0q�$	��Top=��� $��1��$
��Left=�$��118,41.12,0,0q�$	��Top=����� *InputFileFormat+�� $��
Bit Depth:��$
��Left=�$��10,103.12,0,0q�$��1��$	��Top=��� $
��Left=�$��137,103.12,0,0q�$��1��$	��Top=�$	��120������ *	BitDepths+ �� SelectedIndex �� *SelectedBitDepthIndex+$ TwoWay=��� $��Channel Count:��$
��Left=�$��10,134.12,0,0q�$��1��$	��Top=��� $
��Left=�$��137,134.12,0,0q�$��1��$	��Top=�$	��120������ *ChannelCounts+ �� *SelectedChannelCountIndex+$ TwoWay=��� $��Reposition Test��$
��Left=�$��10,210.12,0,0q�$��1��$	��Top=�$	��103������ *RepositionTestCommand+