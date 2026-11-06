# FrmModbusRTU

基于自研 Modbus RTU / Modbus TCP 通讯库的 WinForms 上位机示例。

项目演示了串口与以太网两种接入方式下的连接管理、寄存器读写、实时数据采集和多从站轮询，适合作为学习 Modbus 协议与上位机开发的脚手架。

## 窗体一览

| 窗体 | 说明 |
| --- | --- |
| `FrmModbusTCP` | 程序启动窗体。Modbus TCP 主界面：连接、读线圈 / 寄存器、按 ABCD / BADC 等格式解析数据 |
| `FrmModbusRtu` | Modbus RTU 串口界面：输出线圈 `0x`、输入线圈 `1x`、输出寄存器 `4x`、输入寄存器 `3x` 四个存储区的读写 |
| `FrmPLC_ModbusTCP` | 面向 PLC（如汇川、汇辰等）的 TCP 读写示例 |
| `FrmCollector` | 多从站轮询采集：每个站独立一个 `CancellationTokenSource`，可随时启停 |

## 目录结构要求

本项目通过 `ProjectReference` 直接引用另外两个仓库，因此**三个仓库必须并排克隆**，否则无法编译：

```
ModbusRTU.slnx 所在层级/
├── ModbusRTU/       # 串口通讯库
├── modbustcp/       # 以太网通讯库
└── FrmModbusRTU/    # 本仓库（WinForms 界面）
```

```bash
git clone https://github.com/4006755/ModbusRTU.git
git clone https://github.com/4006755/modbustcp.git
git clone https://github.com/4006755/FrmModbusRTU.git
```

## 构建与运行

需要 **Windows** + **.NET 10 SDK**（`dotnet --version` 确认）。

```bash
cd FrmModbusRTU
dotnet build
dotnet run
```

也可以直接用 Visual Studio 2022 / 2026 打开 `FrmModbusRTU.csproj`（`Program.cs` 中 `Application.Run(new FrmModbusTCP())` 指定启动窗体）。

## 依赖

| 包 | 版本 | 用途 |
| --- | --- | --- |
| `System.IO.Ports` | 10.0.12 | 串口通讯 |
| `thinger.DataConvertLib` | 4.0.1 | 字节 / 数值转换（大小端、BCD 等） |

## 相关仓库

- [ModbusRTU](https://github.com/4006755/ModbusRTU) — Modbus RTU 协议实现（串口）
- [modbustcp](https://github.com/4006755/modbustcp) — Modbus TCP 协议实现（Socket）

## 许可

[MIT](LICENSE)
