## 架构说明

![image](https://raw.githubusercontent.com/wanf425/BoosterStation/main/tolson.BoosterStation/Config/architecture.png)

## 技术栈 
c# / winform / mysql / s7plc

## 使用说明

#### 导入项目

* 路径：BoosterStation\tolson.BoosterStation\tolson.BoosterStation.csproj

* 依赖版本：.net framwork 4.7.2

#### 初始化数据库

* 建表语句：BoosterStation\tolson.BoosterStation\Config\initMySQL.sql

#### 初始化PLC

##### PLC程序代码

* 下载链接: https://pan.baidu.com/s/1PDfYTMcYwqouOhGsK0z0AQ?pwd=1234 

##### 仿真软件安装
* 【S7-PLCSIM V15 PLC仿真软件安装】 https://www.bilibili.com/video/BV19R4y1w7oh/?share_source=copy_web&vd_source=4ea6e1cc5995af79a9f6bc87da8de7a8

*  【S7-PLCSIM Advanced V3.0 PLC仿真软件安装】 https://www.bilibili.com/video/BV1av4y1K7Uc/?share_source=copy_web&vd_source=4ea6e1cc5995af79a9f6bc87da8de7a8


#### 修改配置文件
* 文件目录：BoosterStation/tolson.BoosterStation/Config/
  数据库连接：MySQLConfig.ini
  PLC连接：PlcConfig.ini
  系统配置：SysConfig.ini
* 数据库连接配置：BoosterStation/tolson.BoosterStation/Config/MySQLConfig.ini
* Config目录下的文件，修改后需刷新到bin/debug/Config文件目录才会生效。自动刷新方法：右键 -> 选择【属性】-> 设置【高级】-【复制到输出目录】：如果较新则复制

#### 启动项目
启动前修改BoosterStation/tolson.BoosterStation/Program.cs

```c#
// 初始化主界面-加压站
Application.Run(new FormMain());
// 初始化主界面-雷赛运动控制
//Application.Run(new FormLSMotion());
```