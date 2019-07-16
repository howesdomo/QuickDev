using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

namespace QuickDev.iOS
{
    public class MyBluetooth : QuickDev.IBluetooth
    {
        /// <summary>
        /// 系统蓝牙设备管理对象，可以把他理解为主设备，通过他，可以去扫描和链接外设 
        /// </summary>
        CoreBluetooth.CBCentralManager mManager { get; set; }

        public MyBluetooth()
        {
            // mManager = [[CoreBluetooth.CBCentralManager alloc] initWithDelegate: self queue:dispatch_get_main_queue()];
            mManager = new CoreBluetooth.CBCentralManager();

            mManager.DiscoveredPeripheral += manager_DiscoveredPeripheral; // 找到外设的委托
            mManager.ConnectedPeripheral += manager_ConnectedPeripheral; //连接外设成功的委托
            mManager.FailedToConnectPeripheral += manager_FailedToConnectPeripheral; //外设连接失败的委托
            mManager.DisconnectedPeripheral += manager_DisconnectedPeripheral; //断开外设的委托
            mManager.UpdatedState += manager_UpdatedState;
        }

        private void manager_UpdatedState(object sender, EventArgs e)
        {
            string msg = string.Empty;
            switch (mManager.State)
            {
                case CoreBluetooth.CBCentralManagerState.Unknown:
                    msg = @">>>CBCentralManagerStateUnknown";
                    System.Diagnostics.Debug.WriteLine(msg);
                    break;
                case CoreBluetooth.CBCentralManagerState.Resetting:
                    msg = @">>>CBCentralManagerStateResetting";
                    System.Diagnostics.Debug.WriteLine(msg);
                    break;
                case CoreBluetooth.CBCentralManagerState.Unsupported:
                    msg = @">>>CBCentralManagerStateUnsupported";
                    System.Diagnostics.Debug.WriteLine(msg);
                    break;
                case CoreBluetooth.CBCentralManagerState.Unauthorized:
                    msg = @">>>CBCentralManagerStateUnauthorized";
                    System.Diagnostics.Debug.WriteLine(msg);
                    break;
                case CoreBluetooth.CBCentralManagerState.PoweredOff:
                    msg = @">>>CBCentralManagerStatePoweredOff";
                    System.Diagnostics.Debug.WriteLine(msg);
                    break;
                case CoreBluetooth.CBCentralManagerState.PoweredOn:
                    msg = @">>>CBCentralManagerStatePoweredOn";
                    System.Diagnostics.Debug.WriteLine(msg);
                    // 开始扫描周围的外设
                    mManager.ScanForPeripherals(serviceUuid: null, options: null);
                    break;
                default:
                    break;
            }
        }

        private void manager_DiscoveredPeripheral(object sender, CoreBluetooth.CBDiscoveredPeripheralEventArgs e)
        {
            CoreBluetooth.CBPeripheral toAdd = e.Peripheral;
            NSNumber rssi = e.RSSI;

            string msg = string.Empty;
            msg = Util.JsonUtils.SerializeObjectWithFormatted(toAdd);
            System.Diagnostics.Debug.WriteLine(msg);

            msg = Util.JsonUtils.SerializeObjectWithFormatted(rssi);
            System.Diagnostics.Debug.WriteLine(msg);
        }

        private void manager_ConnectedPeripheral(object sender, CoreBluetooth.CBPeripheralEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("manager_ConnectedPeripheral");
        }

        private void manager_FailedToConnectPeripheral(object sender, CoreBluetooth.CBPeripheralErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("manager_FailedToConnectPeripheral");
        }

        private void manager_DisconnectedPeripheral(object sender, CoreBluetooth.CBPeripheralErrorEventArgs e)
        {
            System.Diagnostics.Debug.WriteLine("manager_DisconnectedPeripheral");
        }

        public void StartScan()
        {
            // var uuid = CoreBluetooth.CBUUID.FromString("00001101-0000-1000-8000-00805f9b34fb");
            mManager.ScanForPeripherals(serviceUuid: null, options: null);
        }
    }
}