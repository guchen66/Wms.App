/*
 Navicat Premium Data Transfer

 Source Server         : mysql
 Source Server Type    : MySQL
 Source Server Version : 80036
 Source Host           : localhost:3306
 Source Schema         : system_cargo

 Target Server Type    : MySQL
 Target Server Version : 80036
 File Encoding         : 65001

 Date: 14/04/2024 21:35:23
*/
-- 1. 如果数据库已存在，则先删除（可选，为了保持环境干净）
DROP DATABASE IF EXISTS `system_cargo`;

-- 2. 创建新的数据库，并指定字符集
CREATE DATABASE `system_cargo` CHARACTER SET 'utf8mb4' COLLATE 'utf8mb4_general_ci';

-- 3. 指定接下来的操作都在这个数据库中进行
USE `system_cargo`;
SET NAMES utf8mb4;
SET FOREIGN_KEY_CHECKS = 0;

-- ----------------------------
-- Table structure for asidemenucontrol
-- ----------------------------
DROP TABLE IF EXISTS `asidemenucontrol`;
CREATE TABLE `asidemenucontrol`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `Icon` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Content` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `NameSpace` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of asidemenucontrol
-- ----------------------------
INSERT INTO `asidemenucontrol` VALUES (1, 'HomeLightbulb', '首页', 'HomeView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (2, 'AccountCheck', '用户', 'UserInfoView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (3, 'ArchiveOutline', '订单管理', 'OrderManageView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (4, 'HomeCircle', '仓库', 'WareHouseView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (5, 'FileTree', '工位', 'WorkStationView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (6, 'Sitemap', '工序', 'WorkStepView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (7, 'DatabaseCheckOutline', '产品数据', 'ProductInfoView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (8, 'CogOutline', '设置', 'SetView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');
INSERT INTO `asidemenucontrol` VALUES (9, 'AlarmLight', '报警', 'AlarmView', '2024-04-14 17:58:41', '2024-04-14 17:58:41', 'Admin', 'Admin', NULL, '0');

-- ----------------------------
-- Table structure for deviceinfo
-- ----------------------------
DROP TABLE IF EXISTS `deviceinfo`;
CREATE TABLE `deviceinfo`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `DeviceName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '设备名称',
  `Count` int(0) NOT NULL COMMENT '设备数量',
  `SafetyRisk` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '设备安全风险',
  `DeviceInfoId` int(0) NOT NULL,
  `WorkStationId` int(0) NOT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of deviceinfo
-- ----------------------------

-- ----------------------------
-- Table structure for goodinfo
-- ----------------------------
DROP TABLE IF EXISTS `goodinfo`;
CREATE TABLE `goodinfo`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `GoodName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '商品名称',
  `Count` int(0) NOT NULL COMMENT '商品数量',
  `Buyers` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '买家信息',
  `OrderTime` datetime(0) NOT NULL COMMENT '下单时间',
  `OrderState` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '订单状态',
  `OrderHeaderId` int(0) NOT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of goodinfo
-- ----------------------------
INSERT INTO `goodinfo` VALUES (1, '沙子', 1, '买家1', '2024-04-13 14:00:57', 'None', 1, '2024-04-13 14:00:57', '2024-04-13 14:00:57', NULL, NULL, NULL, '0');
INSERT INTO `goodinfo` VALUES (2, '沙子2', 1, '买家21', '2024-04-13 14:01:53', 'None', 2, '2024-04-13 14:01:53', '2024-04-13 14:01:53', NULL, NULL, NULL, '0');
INSERT INTO `goodinfo` VALUES (3, '沙子3', 1, '买家21', '2024-04-13 14:01:53', 'None', 3, '2024-04-13 14:01:53', '2024-04-13 14:01:53', NULL, NULL, NULL, '0');
INSERT INTO `goodinfo` VALUES (4, '沙子4', 1, '买家31', '2024-04-13 14:01:53', 'None', 4, '2024-04-13 14:01:53', '2024-04-13 14:01:53', NULL, NULL, NULL, '0');
INSERT INTO `goodinfo` VALUES (5, '沙子5', 1, '买家41', '2024-04-13 14:01:53', 'None', 5, '2024-04-13 14:01:53', '2024-04-13 14:01:53', NULL, NULL, NULL, '0');
INSERT INTO `goodinfo` VALUES (6, '水泥', 12, '买家1', '2024-04-13 14:11:45', 'Lock', 1, '2024-04-13 14:11:45', '2024-04-13 14:11:45', NULL, NULL, NULL, '0');

-- ----------------------------
-- Table structure for orderheaderitem
-- ----------------------------
DROP TABLE IF EXISTS `orderheaderitem`;
CREATE TABLE `orderheaderitem`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `Title` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Path` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 7 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of orderheaderitem
-- ----------------------------
INSERT INTO `orderheaderitem` VALUES (1, '全部订单', '地址1', '2024-04-13 14:04:15', '2024-04-13 14:04:15', NULL, NULL, NULL, '0');
INSERT INTO `orderheaderitem` VALUES (2, '待付款', '待付款1', '2024-04-13 14:04:15', '2024-04-13 14:04:15', NULL, NULL, NULL, '0');
INSERT INTO `orderheaderitem` VALUES (3, '待发货', '地址1', '2024-04-13 14:04:15', '2024-04-13 14:04:15', NULL, NULL, NULL, '0');
INSERT INTO `orderheaderitem` VALUES (4, '已付款', '地址1', '2024-04-13 14:04:15', '2024-04-13 14:04:15', NULL, NULL, NULL, '0');
INSERT INTO `orderheaderitem` VALUES (5, '已发货', '地址1', '2024-04-13 14:04:15', '2024-04-13 14:04:15', NULL, NULL, NULL, '0');
INSERT INTO `orderheaderitem` VALUES (6, '已关闭', '地址1', '2024-04-13 14:04:15', '2024-04-13 14:04:15', NULL, NULL, NULL, '0');

-- ----------------------------
-- Table structure for product_data_config
-- ----------------------------
DROP TABLE IF EXISTS `product_data_config`;
CREATE TABLE `product_data_config`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `Code` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Name` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `Batch` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 2 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of product_data_config
-- ----------------------------
INSERT INTO `product_data_config` VALUES (1, '1', 'AD-2024-4', '123', '2024-04-12 10:35:20', NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for productdata
-- ----------------------------
DROP TABLE IF EXISTS `productdata`;
CREATE TABLE `productdata`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `ProductCode` int(0) NOT NULL COMMENT '产品唯一标识符',
  `ProductName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '产品名称',
  `OkCount` int(0) NOT NULL COMMENT '产品Ok数量',
  `NgCount` int(0) NOT NULL COMMENT '产品Ng数量',
  `ProductState` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '产品状态',
  `Image` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '产品图片',
  `ProductId` int(0) NOT NULL,
  `WorkStationId` int(0) NOT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of productdata
-- ----------------------------
INSERT INTO `productdata` VALUES (1, 1234543, '产品1', 12, 2, '完成产品', '111', 1, 1, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `productdata` VALUES (2, 2345643, '产品2', 21, 21, '生产产品', '21', 2, 1, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `productdata` VALUES (3, 23243, '产品3', 2, 1, '生产产品', '21', 3, 1, NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `productdata` VALUES (4, 123, '产品4', 2, 1, '生产产品', '21', 4, 1, NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for producttype
-- ----------------------------
DROP TABLE IF EXISTS `producttype`;
CREATE TABLE `producttype`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `CategoryId` int(0) NOT NULL,
  `CategoryName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '分类名称',
  `Description` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '分类描述',
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of producttype
-- ----------------------------
INSERT INTO `producttype` VALUES (1, 1, '全部产品', '全部产品', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `producttype` VALUES (2, 2, '生产产品', '生产产品', NULL, NULL, NULL, NULL, NULL, NULL);
INSERT INTO `producttype` VALUES (3, 3, '完成产品', '完成产品', NULL, NULL, NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for producttypemapping
-- ----------------------------
DROP TABLE IF EXISTS `producttypemapping`;
CREATE TABLE `producttypemapping`  (
  `ProductId` int(0) NOT NULL,
  `ProducTypetId` int(0) NOT NULL,
  `Remark` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL COMMENT 'ProductTypeId1表示全部产品，2表示投入产品3表示完成产品'
) ENGINE = InnoDB CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of producttypemapping
-- ----------------------------
INSERT INTO `producttypemapping` VALUES (1, 1, NULL);
INSERT INTO `producttypemapping` VALUES (2, 1, NULL);
INSERT INTO `producttypemapping` VALUES (3, 1, NULL);
INSERT INTO `producttypemapping` VALUES (4, 1, NULL);
INSERT INTO `producttypemapping` VALUES (2, 2, NULL);
INSERT INTO `producttypemapping` VALUES (3, 2, NULL);
INSERT INTO `producttypemapping` VALUES (1, 3, NULL);

-- ----------------------------
-- Table structure for roleinfo
-- ----------------------------
DROP TABLE IF EXISTS `roleinfo`;
CREATE TABLE `roleinfo`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Sort` int(0) NOT NULL COMMENT '1-10数字越大等级越高 10表示程序设计人员',
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 8 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of roleinfo
-- ----------------------------
INSERT INTO `roleinfo` VALUES (1, '普通员工', 1, '2024-04-08 09:24:06', '2024-04-08 09:24:06', NULL, NULL, NULL, '0');
INSERT INTO `roleinfo` VALUES (2, '组长', 2, '2024-04-08 09:30:08', '2024-04-08 09:30:08', NULL, NULL, NULL, '0');
INSERT INTO `roleinfo` VALUES (3, '科长', 3, '2024-04-08 09:30:08', '2024-04-08 09:30:08', NULL, NULL, NULL, '0');
INSERT INTO `roleinfo` VALUES (4, '经理', 4, '2024-04-08 09:30:08', '2024-04-08 09:30:08', NULL, NULL, NULL, '0');
INSERT INTO `roleinfo` VALUES (5, '管理员', 5, '2024-04-08 09:30:08', '2024-04-08 09:30:08', NULL, NULL, NULL, '0');
INSERT INTO `roleinfo` VALUES (6, '超级管理员', 6, '2024-04-08 09:30:08', '2024-04-08 09:30:08', NULL, NULL, NULL, '0');
INSERT INTO `roleinfo` VALUES (7, '开发者', 7, '2024-04-08 09:30:08', '2024-04-08 09:30:08', NULL, NULL, NULL, '0');

-- ----------------------------
-- Table structure for userinfo
-- ----------------------------
DROP TABLE IF EXISTS `userinfo`;
CREATE TABLE `userinfo`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `DisplayName` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Name` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `JobNumber` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL COMMENT '工号',
  `Password` varchar(255) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `Department` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `RoleId` int(0) NOT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 23 CHARACTER SET = utf8mb3 COLLATE = utf8mb3_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of userinfo
-- ----------------------------
INSERT INTO `userinfo` VALUES (1, NULL, 'Admin', '0001', '123456', NULL, 7, '2024-04-07 16:49:49', '2024-04-23 16:49:53', NULL, NULL, NULL, '0');
INSERT INTO `userinfo` VALUES (2, NULL, '张三', '0002', '123', NULL, 2, '2024-04-07 22:10:04', NULL, NULL, NULL, NULL, '0');
INSERT INTO `userinfo` VALUES (3, NULL, '李四', '0003', '321', NULL, 3, '2024-04-07 22:13:59', NULL, NULL, NULL, NULL, '0');
INSERT INTO `userinfo` VALUES (4, NULL, '王五', '0004', '123', NULL, 4, '2024-04-08 10:01:22', NULL, NULL, NULL, NULL, '1');
INSERT INTO `userinfo` VALUES (6, NULL, '21', '0006', '123', NULL, 6, '2024-04-08 10:11:01', NULL, NULL, NULL, NULL, '1');
INSERT INTO `userinfo` VALUES (8, NULL, '123', '0003', '123', NULL, 4, '2024-04-08 16:31:56', NULL, NULL, NULL, NULL, NULL);
INSERT INTO `userinfo` VALUES (9, NULL, '123', '0003', '123', NULL, 5, '2024-04-08 16:31:56', NULL, NULL, NULL, NULL, NULL);
INSERT INTO `userinfo` VALUES (10, NULL, '007', '007', '123', NULL, 6, '2024-04-08 16:47:24', NULL, NULL, NULL, NULL, NULL);
INSERT INTO `userinfo` VALUES (11, NULL, '008', '0007', '321', NULL, 7, '2024-04-08 16:49:31', NULL, NULL, NULL, NULL, NULL);
INSERT INTO `userinfo` VALUES (20, NULL, '1', '1', '1', NULL, 4, '2024-04-08 17:05:09', NULL, NULL, NULL, NULL, '1');
INSERT INTO `userinfo` VALUES (21, NULL, '122', '1', '121', NULL, 2, '2024-04-08 17:05:31', NULL, NULL, NULL, NULL, '1');
INSERT INTO `userinfo` VALUES (22, NULL, '倦收天32', '2', '321', NULL, 1, '2024-04-11 10:33:02', '2024-03-11 10:41:26', NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for warehouse
-- ----------------------------
DROP TABLE IF EXISTS `warehouse`;
CREATE TABLE `warehouse`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `WareHouseId` int(0) NOT NULL,
  `WareHouseName` varchar(20) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL,
  `ItemTotal` int(0) NOT NULL COMMENT '物件总数',
  `ItemType` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL COMMENT '物件类型',
  `Price` decimal(10, 2) NOT NULL COMMENT '物件价格',
  `Tag` varchar(256) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NULL DEFAULT NULL COMMENT '物件标记',
  `UserId` int(0) NOT NULL,
  `AssociatedPerson` varchar(50) CHARACTER SET utf8mb3 COLLATE utf8mb3_general_ci NOT NULL COMMENT '负责人',
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 9 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of warehouse
-- ----------------------------
INSERT INTO `warehouse` VALUES (1, 1, '仓库02', 1001, '1', 1.00, NULL, 1, '1', NULL, '2024-04-11 10:09:44', NULL, NULL, NULL, '0');
INSERT INTO `warehouse` VALUES (2, 0, '仓库02', 100, '1', 1.00, NULL, 1, '张三', NULL, '1900-01-01 00:00:00', NULL, NULL, NULL, '1');
INSERT INTO `warehouse` VALUES (3, 0, '仓库01', 100, '1', 1.00, NULL, 2, '周流六虚功', NULL, '1900-01-01 00:00:00', NULL, NULL, NULL, '1');
INSERT INTO `warehouse` VALUES (5, 1, '仓库02', 1003, '12', 1.00, '2', 1, '李四', NULL, '2024-04-11 10:16:29', NULL, NULL, NULL, NULL);
INSERT INTO `warehouse` VALUES (6, 0, '无1', 212, '233', 23.00, '3', 1, '4', NULL, '2024-04-11 10:30:32', NULL, NULL, NULL, NULL);
INSERT INTO `warehouse` VALUES (7, 0, '五', 231, '231', 33.00, NULL, 1, '银票当家', '1900-01-01 00:00:00', '1900-01-01 00:00:00', NULL, NULL, NULL, NULL);
INSERT INTO `warehouse` VALUES (8, 0, '23', 23, '23', 23.00, NULL, 1, '23', '1900-01-01 00:00:00', '2024-04-11 11:00:57', NULL, NULL, NULL, NULL);
INSERT INTO `warehouse` VALUES (9, 0, '24', 43, '43', 3.00, NULL, 1, '3', '2024-04-11 11:01:28', '2024-04-11 13:40:06', NULL, NULL, NULL, '1');

-- ----------------------------
-- Table structure for workstation
-- ----------------------------
DROP TABLE IF EXISTS `workstation`;
CREATE TABLE `workstation`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `WorkId` int(0) NOT NULL COMMENT '工站Id',
  `WorkName` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '工站名称',
  `Location` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '工位位置信息',
  `Capacity` int(0) NOT NULL COMMENT '工位容纳能力',
  `IsAutomatic` tinyint(1) NOT NULL COMMENT '是否自动化工位',
  `CreateTime` datetime(0) NOT NULL COMMENT '投产日期',
  `UpdateTime` datetime(0) NOT NULL COMMENT '最后维护日期',
  `MaintenancePerson` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '维护人员',
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of workstation
-- ----------------------------
INSERT INTO `workstation` VALUES (1, 1, '工位1', '位置1', 3, 0, '2024-04-02 17:35:48', '2024-04-16 17:35:51', '张三', NULL, NULL, NULL, NULL);
INSERT INTO `workstation` VALUES (2, 2, '工位2', '位置2', 2, 1, '2024-04-02 17:36:31', '2024-04-03 17:36:36', '李四', NULL, NULL, NULL, NULL);

-- ----------------------------
-- Table structure for workstep
-- ----------------------------
DROP TABLE IF EXISTS `workstep`;
CREATE TABLE `workstep`  (
  `Id` int(0) NOT NULL AUTO_INCREMENT,
  `WorkStepId` int(0) NOT NULL,
  `WorkStepName` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '工序名称',
  `OperationSequence` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作顺序',
  `OperationParameters` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '操作参数',
  `RequiredSkills` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '所需技能',
  `Duration` int(0) NOT NULL COMMENT '工序持续时间',
  `RequiredMaterials` varchar(255) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NOT NULL COMMENT '所需材料',
  `WorkStationId` int(0) NOT NULL,
  `CreateTime` datetime(0) NULL DEFAULT NULL,
  `UpdateTime` datetime(0) NULL DEFAULT NULL,
  `CreateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `UpdateUserName` varchar(16) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `Remark` varchar(200) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  `IsDelete` varchar(1) CHARACTER SET utf8mb4 COLLATE utf8mb4_general_ci NULL DEFAULT NULL,
  PRIMARY KEY (`Id`) USING BTREE
) ENGINE = InnoDB AUTO_INCREMENT = 1 CHARACTER SET = utf8mb4 COLLATE = utf8mb4_general_ci ROW_FORMAT = Dynamic;

-- ----------------------------
-- Records of workstep
-- ----------------------------
INSERT INTO `workstep` VALUES (1, 1, '工序名称', '顺序1', '参数1', '技能1', 100, '材料1', 2, NULL, NULL, NULL, NULL, NULL, NULL);

SET FOREIGN_KEY_CHECKS = 1;
