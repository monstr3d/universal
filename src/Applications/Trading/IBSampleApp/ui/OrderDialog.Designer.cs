/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */
using IBApi.types;
using IBSampleApp.ui;
namespace IBSampleApp
{
    partial class OrderDialog
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OrderDialog));
            contractSymbol = new TextBox();
            conditionsTab = new TabControl();
            orderContractTab = new TabPage();
            baseGroup = new GroupBox();
            label24 = new Label();
            usePriceMgmtAlgo = new CheckBox();
            cashQty = new TextBox();
            cashQtyLabel = new Label();
            modelCode = new TextBox();
            modelCodeLabel = new Label();
            timeInForce = new ComboBox();
            auxPrice = new TextBox();
            lmtPrice = new TextBox();
            orderType = new ComboBox();
            displaySize = new TextBox();
            quantity = new TextBox();
            action = new ComboBox();
            timeInForceLabel = new Label();
            auxPriceLabel = new Label();
            account = new ComboBox();
            limitPriceLabel = new Label();
            orderTypeLabel = new Label();
            displaySizeLabel = new Label();
            quantityLabel = new Label();
            actionLabel = new Label();
            accountLabel = new Label();
            contractGroup = new GroupBox();
            orderPrimExchLabel = new Label();
            contractPrimaryExch = new TextBox();
            orderLocalSymbol = new Label();
            orderCurrencyLabel = new Label();
            orderExchangeLabel = new Label();
            orderSymbolLabel = new Label();
            orderMultiplierLabel = new Label();
            orderRightLabel = new Label();
            contractSecType = new ComboBox();
            orderStrikeLabel = new Label();
            contractLastTradeDateOrContractMonth = new TextBox();
            orderLastTradeDateOrContractMonthLabel = new Label();
            contractStrike = new TextBox();
            orderSecTypeLabel = new Label();
            contractRight = new ComboBox();
            contractLocalSymbol = new TextBox();
            contractMultiplier = new TextBox();
            contractCurrency = new TextBox();
            contractExchange = new TextBox();
            extendedOrderTab = new TabPage();
            solicited = new CheckBox();
            manualOrderCancelTime = new TextBox();
            labelManualOrderCancelTime = new Label();
            manualOrderTime = new TextBox();
            labelManualOrderTime = new Label();
            advancedErrorOverride = new TextBox();
            label27 = new Label();
            autoCancelParent = new CheckBox();
            postToAts = new TextBox();
            label26 = new Label();
            duration = new TextBox();
            label25 = new Label();
            relativeDiscretionary = new CheckBox();
            omsContainer = new CheckBox();
            dontUseAutoPriceForHedge = new CheckBox();
            label22 = new Label();
            mifid2ExecutionAlgo = new TextBox();
            label23 = new Label();
            mifid2ExecutionTrader = new TextBox();
            label18 = new Label();
            mifid2DecisionAlgo = new TextBox();
            label19 = new Label();
            mifid2DecisionMaker = new TextBox();
            label17 = new Label();
            softDollarTier = new ComboBox();
            trailingPercentLabel = new Label();
            transmit = new CheckBox();
            overrideConstraints = new CheckBox();
            label5 = new Label();
            optOutSmart = new CheckBox();
            trailingPercent = new TextBox();
            discretionaryAmount = new TextBox();
            hidden = new CheckBox();
            outsideRTH = new CheckBox();
            label3 = new Label();
            allOrNone = new CheckBox();
            label2 = new Label();
            notHeld = new CheckBox();
            block = new CheckBox();
            label1 = new Label();
            sweepToFill = new CheckBox();
            percentOffsetLabel = new Label();
            tiggerMethodLabel = new Label();
            rule80ALabel = new Label();
            goodUntilLabel = new Label();
            goodAfterLabel = new Label();
            ocaGroup = new TextBox();
            hedgeParam = new TextBox();
            ocaType = new ComboBox();
            hedgeType = new ComboBox();
            orderMinQtyLabel = new Label();
            orderRefLabel = new Label();
            trailStopPrice = new TextBox();
            percentOffset = new TextBox();
            triggerMethod = new ComboBox();
            rule80A = new ComboBox();
            goodUntil = new TextBox();
            goodAfter = new TextBox();
            minQty = new TextBox();
            orderReference = new TextBox();
            advisorTab = new TabPage();
            faPercentage = new TextBox();
            faProfile = new TextBox();
            faMethod = new ComboBox();
            faGroup = new TextBox();
            profileLabel = new Label();
            orLabel = new Label();
            percentageLabel = new Label();
            methodLabel = new Label();
            groupLabel = new Label();
            volatilityTab = new TabPage();
            stockRangeLower = new TextBox();
            stockRangeUpper = new TextBox();
            deltaNeutralConId = new TextBox();
            deltaNeutralAuxPrice = new TextBox();
            deltaNeutralOrderType = new ComboBox();
            optionReferencePrice = new ComboBox();
            volatilityType = new ComboBox();
            volatility = new TextBox();
            continuousUpdate = new CheckBox();
            stockRangeLowerLabel = new Label();
            sockRangeUpperLabel = new Label();
            hedgeContractConIdLabel = new Label();
            hedgeOrderAuxPriceLabel = new Label();
            hedgeOrderTypeLabel = new Label();
            optionReferencePriceLabel = new Label();
            volatilityLabel = new Label();
            scaleTab = new TabPage();
            priceAdjustInterval = new TextBox();
            priceAdjustValue = new TextBox();
            initialFillQuantity = new TextBox();
            initialPosition = new TextBox();
            priceIncrement = new TextBox();
            profitOffset = new TextBox();
            subsequentLevelSize = new TextBox();
            initialLevelSize = new TextBox();
            autoReset = new CheckBox();
            randomiseSize = new CheckBox();
            secondsLabel = new Label();
            initialPositionLabel = new Label();
            initialFillQuantityLabel = new Label();
            everyLabel = new Label();
            priceAdjustValueLabel = new Label();
            subsequentLevelSizeLabel = new Label();
            profitOffsetLabel = new Label();
            priceIncrementLabel = new Label();
            initialLevelSizeLabel = new Label();
            algoTab = new TabPage();
            useOddLots = new TextBox();
            noTradeAhead = new TextBox();
            getDone = new TextBox();
            displaySizeAlgo = new TextBox();
            forceCompletion = new TextBox();
            riskAversion = new TextBox();
            noTakeLiq = new TextBox();
            strategyType = new TextBox();
            pctVol = new TextBox();
            maxPctVol = new TextBox();
            allowPastEndTime = new TextBox();
            endTime = new TextBox();
            startTime = new TextBox();
            useOddLotsLabel = new Label();
            noTradeAheadLabel = new Label();
            getDoneLabel = new Label();
            displaySizeAlgoLabel = new Label();
            forceCompletionLabel = new Label();
            riskAversionLabel = new Label();
            noTakeLiqLabel = new Label();
            strategyTypeLabel = new Label();
            pctVolLabel = new Label();
            maxPctVolLabel = new Label();
            allowPastEndTimeLabel = new Label();
            endTimeLabel = new Label();
            startTimeLabel = new Label();
            algoStrategy = new ComboBox();
            algoStrategyLabel = new Label();
            peg2benchTab = new TabPage();
            pgdStockRangeLower = new TextBox();
            pgdStockRangeUpper = new TextBox();
            label20 = new Label();
            label21 = new Label();
            cbPeggedChangeType = new ComboBox();
            tbReferenceChangeAmount = new TextBox();
            tbPeggedChangeAmount = new TextBox();
            tbStartingReferencePrice = new TextBox();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            tbStartingPrice = new TextBox();
            label4 = new Label();
            adjustStopTab = new TabPage();
            label16 = new Label();
            cbAdjustedTrailingAmntUnit = new ComboBox();
            tbAdjustedTrailingAmnt = new TextBox();
            label15 = new Label();
            tbAdjustedStopLimitPrice = new TextBox();
            label14 = new Label();
            tbAdjustedStopPrice = new TextBox();
            label13 = new Label();
            tbTriggerPrice = new TextBox();
            label12 = new Label();
            cbAdjustedOrderType = new ComboBox();
            label11 = new Label();
            tabPage1 = new TabPage();
            ignoreRth = new CheckBox();
            cancelOrder = new ComboBox();
            conditionList = new DataGridView();
            Description = new DataGridViewTextBoxColumn();
            Logic = new DataGridViewComboBoxColumn();
            lbAddCondition = new LinkLabel();
            lbRemoveCondition = new LinkLabel();
            PegBestPegMidTab = new TabPage();
            tbMidOffsetAtHalf = new TextBox();
            labelMidOffsetAtHalf = new Label();
            tbMidOffsetAtWhole = new TextBox();
            labelMidOffsetAtWhole = new Label();
            cbCompeteAgainstBestOffsetUpToMid = new CheckBox();
            tbCompeteAgainstBestOffset = new TextBox();
            labelCompeteAgainstBestOffset = new Label();
            tbMinCompeteSize = new TextBox();
            labelMinCompeteSize = new Label();
            tbMinTradeQty = new TextBox();
            labelMinTradeQty = new Label();
            contractSearchControl1 = new ContractSearchControl();
            sendOrderButton = new Button();
            textBox6 = new TextBox();
            textBox7 = new TextBox();
            textBox8 = new TextBox();
            checkMarginButton = new Button();
            closeOrderDialogButton = new Button();
            cancelOrderButton = new Button();
            conditionsTab.SuspendLayout();
            orderContractTab.SuspendLayout();
            baseGroup.SuspendLayout();
            contractGroup.SuspendLayout();
            extendedOrderTab.SuspendLayout();
            advisorTab.SuspendLayout();
            volatilityTab.SuspendLayout();
            scaleTab.SuspendLayout();
            algoTab.SuspendLayout();
            peg2benchTab.SuspendLayout();
            adjustStopTab.SuspendLayout();
            tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)conditionList).BeginInit();
            PegBestPegMidTab.SuspendLayout();
            SuspendLayout();
            // 
            // contractSymbol
            // 
            contractSymbol.Location = new Point(96, 28);
            contractSymbol.Margin = new Padding(4, 3, 4, 3);
            contractSymbol.Name = "contractSymbol";
            contractSymbol.Size = new Size(82, 23);
            contractSymbol.TabIndex = 0;
            contractSymbol.Text = "AAPL";
            // 
            // conditionsTab
            // 
            conditionsTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            conditionsTab.Controls.Add(orderContractTab);
            conditionsTab.Controls.Add(extendedOrderTab);
            conditionsTab.Controls.Add(advisorTab);
            conditionsTab.Controls.Add(volatilityTab);
            conditionsTab.Controls.Add(scaleTab);
            conditionsTab.Controls.Add(algoTab);
            conditionsTab.Controls.Add(peg2benchTab);
            conditionsTab.Controls.Add(adjustStopTab);
            conditionsTab.Controls.Add(tabPage1);
            conditionsTab.Controls.Add(PegBestPegMidTab);
            conditionsTab.Location = new Point(1, 1);
            conditionsTab.Margin = new Padding(4, 3, 4, 3);
            conditionsTab.Name = "conditionsTab";
            conditionsTab.SelectedIndex = 0;
            conditionsTab.Size = new Size(873, 471);
            conditionsTab.TabIndex = 1;
            // 
            // orderContractTab
            // 
            orderContractTab.BackColor = Color.LightGray;
            orderContractTab.Controls.Add(baseGroup);
            orderContractTab.Controls.Add(contractGroup);
            orderContractTab.Location = new Point(4, 24);
            orderContractTab.Margin = new Padding(4, 3, 4, 3);
            orderContractTab.Name = "orderContractTab";
            orderContractTab.Padding = new Padding(4, 3, 4, 3);
            orderContractTab.Size = new Size(865, 443);
            orderContractTab.TabIndex = 0;
            orderContractTab.Text = "Basic Order";
            // 
            // baseGroup
            // 
            baseGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            baseGroup.Controls.Add(label24);
            baseGroup.Controls.Add(usePriceMgmtAlgo);
            baseGroup.Controls.Add(cashQty);
            baseGroup.Controls.Add(cashQtyLabel);
            baseGroup.Controls.Add(modelCode);
            baseGroup.Controls.Add(modelCodeLabel);
            baseGroup.Controls.Add(timeInForce);
            baseGroup.Controls.Add(auxPrice);
            baseGroup.Controls.Add(lmtPrice);
            baseGroup.Controls.Add(orderType);
            baseGroup.Controls.Add(displaySize);
            baseGroup.Controls.Add(quantity);
            baseGroup.Controls.Add(action);
            baseGroup.Controls.Add(timeInForceLabel);
            baseGroup.Controls.Add(auxPriceLabel);
            baseGroup.Controls.Add(account);
            baseGroup.Controls.Add(limitPriceLabel);
            baseGroup.Controls.Add(orderTypeLabel);
            baseGroup.Controls.Add(displaySizeLabel);
            baseGroup.Controls.Add(quantityLabel);
            baseGroup.Controls.Add(actionLabel);
            baseGroup.Controls.Add(accountLabel);
            baseGroup.Location = new Point(422, 7);
            baseGroup.Margin = new Padding(4, 3, 4, 3);
            baseGroup.Name = "baseGroup";
            baseGroup.Padding = new Padding(4, 3, 4, 3);
            baseGroup.Size = new Size(416, 396);
            baseGroup.TabIndex = 0;
            baseGroup.TabStop = false;
            baseGroup.Text = "Order Base Attributes";
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.Location = new Point(15, 340);
            label24.Margin = new Padding(4, 0, 4, 0);
            label24.Name = "label24";
            label24.Size = new Size(157, 15);
            label24.TabIndex = 25;
            label24.Text = "Use Price Management Algo";
            // 
            // usePriceMgmtAlgo
            // 
            usePriceMgmtAlgo.AutoSize = true;
            usePriceMgmtAlgo.Checked = true;
            usePriceMgmtAlgo.CheckState = CheckState.Indeterminate;
            usePriceMgmtAlgo.Location = new Point(224, 340);
            usePriceMgmtAlgo.Margin = new Padding(4, 3, 4, 3);
            usePriceMgmtAlgo.Name = "usePriceMgmtAlgo";
            usePriceMgmtAlgo.Size = new Size(15, 14);
            usePriceMgmtAlgo.TabIndex = 24;
            usePriceMgmtAlgo.UseVisualStyleBackColor = true;
            // 
            // cashQty
            // 
            cashQty.Location = new Point(141, 310);
            cashQty.Margin = new Padding(4, 3, 4, 3);
            cashQty.Name = "cashQty";
            cashQty.Size = new Size(103, 23);
            cashQty.TabIndex = 23;
            // 
            // cashQtyLabel
            // 
            cashQtyLabel.AutoSize = true;
            cashQtyLabel.Location = new Point(16, 314);
            cashQtyLabel.Margin = new Padding(4, 0, 4, 0);
            cashQtyLabel.Name = "cashQtyLabel";
            cashQtyLabel.Size = new Size(55, 15);
            cashQtyLabel.TabIndex = 22;
            cashQtyLabel.Text = "Cash Qty";
            // 
            // modelCode
            // 
            modelCode.Location = new Point(141, 62);
            modelCode.Margin = new Padding(4, 3, 4, 3);
            modelCode.Name = "modelCode";
            modelCode.Size = new Size(103, 23);
            modelCode.TabIndex = 3;
            // 
            // modelCodeLabel
            // 
            modelCodeLabel.AutoSize = true;
            modelCodeLabel.Location = new Point(15, 70);
            modelCodeLabel.Margin = new Padding(4, 0, 4, 0);
            modelCodeLabel.Name = "modelCodeLabel";
            modelCodeLabel.Size = new Size(72, 15);
            modelCodeLabel.TabIndex = 2;
            modelCodeLabel.Text = "Model Code";
            // 
            // timeInForce
            // 
            timeInForce.FormattingEnabled = true;
            timeInForce.Items.AddRange(new object[] { "DAY", "GTC", "OPG", "IOC", "GTD", "GTT", "AUC", "FOK", "GTX", "DTC", "Minutes" });
            timeInForce.Location = new Point(141, 279);
            timeInForce.Margin = new Padding(4, 3, 4, 3);
            timeInForce.Name = "timeInForce";
            timeInForce.Size = new Size(103, 23);
            timeInForce.TabIndex = 15;
            timeInForce.Text = "DAY";
            // 
            // auxPrice
            // 
            auxPrice.Location = new Point(141, 249);
            auxPrice.Margin = new Padding(4, 3, 4, 3);
            auxPrice.Name = "auxPrice";
            auxPrice.Size = new Size(103, 23);
            auxPrice.TabIndex = 14;
            // 
            // lmtPrice
            // 
            lmtPrice.Location = new Point(141, 219);
            lmtPrice.Margin = new Padding(4, 3, 4, 3);
            lmtPrice.Name = "lmtPrice";
            lmtPrice.Size = new Size(103, 23);
            lmtPrice.TabIndex = 13;
            lmtPrice.Text = "0.80";
            // 
            // orderType
            // 
            orderType.FormattingEnabled = true;
            orderType.Items.AddRange(new object[] { "MKT", "LMT", "STP", "STP LMT", "REL", "TRAIL", "BOX TOP", "FIX PEGGED", "LIT", "LMT + MKT", "LOC", "MIT", "MKT PRT", "MOC", "MTL", "PASSV REL", "PEG BENCH", "PEG BEST", "PEG MID", "PEG MKT", "PEG PRIM", "PEG STK", "REL +LMT", "REL + MKT", "STP PRT", "TRAIL LIMIT", "TRAIL LMT + MKT", "TRAIL LIT", "TRAIL REL + MKT", "TRAIL MIT", "TRAIL REL + MKT", "VOL", "VWAP" });
            orderType.Location = new Point(141, 188);
            orderType.Margin = new Padding(4, 3, 4, 3);
            orderType.Name = "orderType";
            orderType.Size = new Size(134, 23);
            orderType.TabIndex = 11;
            orderType.Text = "MKT";
            // 
            // displaySize
            // 
            displaySize.Location = new Point(141, 158);
            displaySize.Margin = new Padding(4, 3, 4, 3);
            displaySize.Name = "displaySize";
            displaySize.Size = new Size(103, 23);
            displaySize.TabIndex = 9;
            // 
            // quantity
            // 
            quantity.Location = new Point(141, 128);
            quantity.Margin = new Padding(4, 3, 4, 3);
            quantity.Name = "quantity";
            quantity.Size = new Size(103, 23);
            quantity.TabIndex = 7;
            quantity.Text = "1";
            // 
            // action
            // 
            action.FormattingEnabled = true;
            action.Items.AddRange(new object[] { "BUY", "SELL", "SSHORT" });
            action.Location = new Point(141, 93);
            action.Margin = new Padding(4, 3, 4, 3);
            action.Name = "action";
            action.Size = new Size(103, 23);
            action.TabIndex = 5;
            action.Text = "BUY";
            // 
            // timeInForceLabel
            // 
            timeInForceLabel.AutoSize = true;
            timeInForceLabel.Location = new Point(15, 283);
            timeInForceLabel.Margin = new Padding(4, 0, 4, 0);
            timeInForceLabel.Name = "timeInForceLabel";
            timeInForceLabel.Size = new Size(80, 15);
            timeInForceLabel.TabIndex = 8;
            timeInForceLabel.Text = "Time-in-force";
            // 
            // auxPriceLabel
            // 
            auxPriceLabel.AutoSize = true;
            auxPriceLabel.Location = new Point(15, 253);
            auxPriceLabel.Margin = new Padding(4, 0, 4, 0);
            auxPriceLabel.Name = "auxPriceLabel";
            auxPriceLabel.Size = new Size(60, 15);
            auxPriceLabel.TabIndex = 7;
            auxPriceLabel.Text = "Aux. Price";
            // 
            // account
            // 
            account.FormattingEnabled = true;
            account.Location = new Point(141, 29);
            account.Margin = new Padding(4, 3, 4, 3);
            account.Name = "account";
            account.Size = new Size(103, 23);
            account.TabIndex = 1;
            // 
            // limitPriceLabel
            // 
            limitPriceLabel.AutoSize = true;
            limitPriceLabel.Location = new Point(15, 220);
            limitPriceLabel.Margin = new Padding(4, 0, 4, 0);
            limitPriceLabel.Name = "limitPriceLabel";
            limitPriceLabel.Size = new Size(63, 15);
            limitPriceLabel.TabIndex = 5;
            limitPriceLabel.Text = "Limit Price";
            // 
            // orderTypeLabel
            // 
            orderTypeLabel.AutoSize = true;
            orderTypeLabel.Location = new Point(15, 192);
            orderTypeLabel.Margin = new Padding(4, 0, 4, 0);
            orderTypeLabel.Name = "orderTypeLabel";
            orderTypeLabel.Size = new Size(64, 15);
            orderTypeLabel.TabIndex = 10;
            orderTypeLabel.Text = "Order Type";
            // 
            // displaySizeLabel
            // 
            displaySizeLabel.AutoSize = true;
            displaySizeLabel.Location = new Point(15, 162);
            displaySizeLabel.Margin = new Padding(4, 0, 4, 0);
            displaySizeLabel.Name = "displaySizeLabel";
            displaySizeLabel.Size = new Size(68, 15);
            displaySizeLabel.TabIndex = 8;
            displaySizeLabel.Text = "Display Size";
            // 
            // quantityLabel
            // 
            quantityLabel.AutoSize = true;
            quantityLabel.Location = new Point(15, 132);
            quantityLabel.Margin = new Padding(4, 0, 4, 0);
            quantityLabel.Name = "quantityLabel";
            quantityLabel.Size = new Size(53, 15);
            quantityLabel.TabIndex = 6;
            quantityLabel.Text = "Quantity";
            // 
            // actionLabel
            // 
            actionLabel.AutoSize = true;
            actionLabel.Location = new Point(15, 104);
            actionLabel.Margin = new Padding(4, 0, 4, 0);
            actionLabel.Name = "actionLabel";
            actionLabel.Size = new Size(42, 15);
            actionLabel.TabIndex = 4;
            actionLabel.Text = "Action";
            // 
            // accountLabel
            // 
            accountLabel.AutoSize = true;
            accountLabel.Location = new Point(15, 38);
            accountLabel.Margin = new Padding(4, 0, 4, 0);
            accountLabel.Name = "accountLabel";
            accountLabel.Size = new Size(52, 15);
            accountLabel.TabIndex = 0;
            accountLabel.Text = "Account";
            // 
            // contractGroup
            // 
            contractGroup.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contractGroup.Controls.Add(orderPrimExchLabel);
            contractGroup.Controls.Add(contractPrimaryExch);
            contractGroup.Controls.Add(orderLocalSymbol);
            contractGroup.Controls.Add(orderCurrencyLabel);
            contractGroup.Controls.Add(orderExchangeLabel);
            contractGroup.Controls.Add(orderSymbolLabel);
            contractGroup.Controls.Add(orderMultiplierLabel);
            contractGroup.Controls.Add(contractSymbol);
            contractGroup.Controls.Add(orderRightLabel);
            contractGroup.Controls.Add(contractSecType);
            contractGroup.Controls.Add(orderStrikeLabel);
            contractGroup.Controls.Add(contractLastTradeDateOrContractMonth);
            contractGroup.Controls.Add(orderLastTradeDateOrContractMonthLabel);
            contractGroup.Controls.Add(contractStrike);
            contractGroup.Controls.Add(orderSecTypeLabel);
            contractGroup.Controls.Add(contractRight);
            contractGroup.Controls.Add(contractLocalSymbol);
            contractGroup.Controls.Add(contractMultiplier);
            contractGroup.Controls.Add(contractCurrency);
            contractGroup.Controls.Add(contractExchange);
            contractGroup.Location = new Point(7, 7);
            contractGroup.Margin = new Padding(4, 3, 4, 3);
            contractGroup.Name = "contractGroup";
            contractGroup.Padding = new Padding(4, 3, 4, 3);
            contractGroup.Size = new Size(542, 369);
            contractGroup.TabIndex = 14;
            contractGroup.TabStop = false;
            contractGroup.Text = "Contract";
            // 
            // orderPrimExchLabel
            // 
            orderPrimExchLabel.AutoSize = true;
            orderPrimExchLabel.Location = new Point(6, 188);
            orderPrimExchLabel.Margin = new Padding(4, 0, 4, 0);
            orderPrimExchLabel.Name = "orderPrimExchLabel";
            orderPrimExchLabel.Size = new Size(79, 15);
            orderPrimExchLabel.TabIndex = 18;
            orderPrimExchLabel.Text = "Primary Exch.";
            // 
            // contractPrimaryExch
            // 
            contractPrimaryExch.Location = new Point(96, 185);
            contractPrimaryExch.Margin = new Padding(4, 3, 4, 3);
            contractPrimaryExch.Name = "contractPrimaryExch";
            contractPrimaryExch.Size = new Size(82, 23);
            contractPrimaryExch.TabIndex = 17;
            // 
            // orderLocalSymbol
            // 
            orderLocalSymbol.AutoSize = true;
            orderLocalSymbol.Location = new Point(8, 153);
            orderLocalSymbol.Margin = new Padding(4, 0, 4, 0);
            orderLocalSymbol.Name = "orderLocalSymbol";
            orderLocalSymbol.Size = new Size(78, 15);
            orderLocalSymbol.TabIndex = 16;
            orderLocalSymbol.Text = "Local Symbol";
            // 
            // orderCurrencyLabel
            // 
            orderCurrencyLabel.AutoSize = true;
            orderCurrencyLabel.Location = new Point(31, 122);
            orderCurrencyLabel.Margin = new Padding(4, 0, 4, 0);
            orderCurrencyLabel.Name = "orderCurrencyLabel";
            orderCurrencyLabel.Size = new Size(55, 15);
            orderCurrencyLabel.TabIndex = 15;
            orderCurrencyLabel.Text = "Currency";
            // 
            // orderExchangeLabel
            // 
            orderExchangeLabel.AutoSize = true;
            orderExchangeLabel.Location = new Point(24, 92);
            orderExchangeLabel.Margin = new Padding(4, 0, 4, 0);
            orderExchangeLabel.Name = "orderExchangeLabel";
            orderExchangeLabel.Size = new Size(58, 15);
            orderExchangeLabel.TabIndex = 14;
            orderExchangeLabel.Text = "Exchange";
            // 
            // orderSymbolLabel
            // 
            orderSymbolLabel.AutoSize = true;
            orderSymbolLabel.Location = new Point(41, 31);
            orderSymbolLabel.Margin = new Padding(4, 0, 4, 0);
            orderSymbolLabel.Name = "orderSymbolLabel";
            orderSymbolLabel.Size = new Size(47, 15);
            orderSymbolLabel.TabIndex = 0;
            orderSymbolLabel.Text = "Symbol";
            // 
            // orderMultiplierLabel
            // 
            orderMultiplierLabel.AutoSize = true;
            orderMultiplierLabel.Location = new Point(255, 129);
            orderMultiplierLabel.Margin = new Padding(4, 0, 4, 0);
            orderMultiplierLabel.Name = "orderMultiplierLabel";
            orderMultiplierLabel.Size = new Size(58, 15);
            orderMultiplierLabel.TabIndex = 13;
            orderMultiplierLabel.Text = "Multiplier";
            // 
            // orderRightLabel
            // 
            orderRightLabel.AutoSize = true;
            orderRightLabel.Location = new Point(259, 98);
            orderRightLabel.Margin = new Padding(4, 0, 4, 0);
            orderRightLabel.Name = "orderRightLabel";
            orderRightLabel.Size = new Size(50, 15);
            orderRightLabel.TabIndex = 12;
            orderRightLabel.Text = "Put/Call";
            // 
            // contractSecType
            // 
            contractSecType.FormattingEnabled = true;
            contractSecType.Items.AddRange(new object[] { "STK", "OPT", "FUT", "CASH", "BOND", "CFD", "FOP", "WAR", "IOPT", "FWD", "BAG", "IND", "BILL", "FUND", "FIXED", "SLB", "NEWS", "CMDTY", "BSK", "ICU", "ICS", "CRYPTO" });
            contractSecType.Location = new Point(96, 58);
            contractSecType.Margin = new Padding(4, 3, 4, 3);
            contractSecType.Name = "contractSecType";
            contractSecType.Size = new Size(82, 23);
            contractSecType.TabIndex = 1;
            contractSecType.Text = "STK";
            // 
            // orderStrikeLabel
            // 
            orderStrikeLabel.AutoSize = true;
            orderStrikeLabel.Location = new Point(272, 66);
            orderStrikeLabel.Margin = new Padding(4, 0, 4, 0);
            orderStrikeLabel.Name = "orderStrikeLabel";
            orderStrikeLabel.Size = new Size(36, 15);
            orderStrikeLabel.TabIndex = 11;
            orderStrikeLabel.Text = "Strike";
            // 
            // contractLastTradeDateOrContractMonth
            // 
            contractLastTradeDateOrContractMonth.Location = new Point(318, 25);
            contractLastTradeDateOrContractMonth.Margin = new Padding(4, 3, 4, 3);
            contractLastTradeDateOrContractMonth.Name = "contractLastTradeDateOrContractMonth";
            contractLastTradeDateOrContractMonth.Size = new Size(82, 23);
            contractLastTradeDateOrContractMonth.TabIndex = 2;
            // 
            // orderLastTradeDateOrContractMonthLabel
            // 
            orderLastTradeDateOrContractMonthLabel.Location = new Point(208, 25);
            orderLastTradeDateOrContractMonthLabel.Margin = new Padding(4, 0, 4, 0);
            orderLastTradeDateOrContractMonthLabel.Name = "orderLastTradeDateOrContractMonthLabel";
            orderLastTradeDateOrContractMonthLabel.Size = new Size(104, 32);
            orderLastTradeDateOrContractMonthLabel.TabIndex = 10;
            orderLastTradeDateOrContractMonthLabel.Text = "Last trade date / contract month";
            // 
            // contractStrike
            // 
            contractStrike.Location = new Point(318, 62);
            contractStrike.Margin = new Padding(4, 3, 4, 3);
            contractStrike.Name = "contractStrike";
            contractStrike.Size = new Size(82, 23);
            contractStrike.TabIndex = 3;
            // 
            // orderSecTypeLabel
            // 
            orderSecTypeLabel.AutoSize = true;
            orderSecTypeLabel.Location = new Point(30, 63);
            orderSecTypeLabel.Margin = new Padding(4, 0, 4, 0);
            orderSecTypeLabel.Name = "orderSecTypeLabel";
            orderSecTypeLabel.Size = new Size(49, 15);
            orderSecTypeLabel.TabIndex = 9;
            orderSecTypeLabel.Text = "SecType";
            // 
            // contractRight
            // 
            contractRight.FormattingEnabled = true;
            contractRight.Location = new Point(318, 95);
            contractRight.Margin = new Padding(4, 3, 4, 3);
            contractRight.Name = "contractRight";
            contractRight.Size = new Size(82, 23);
            contractRight.TabIndex = 4;
            // 
            // contractLocalSymbol
            // 
            contractLocalSymbol.Location = new Point(96, 150);
            contractLocalSymbol.Margin = new Padding(4, 3, 4, 3);
            contractLocalSymbol.Name = "contractLocalSymbol";
            contractLocalSymbol.Size = new Size(82, 23);
            contractLocalSymbol.TabIndex = 8;
            // 
            // contractMultiplier
            // 
            contractMultiplier.Location = new Point(318, 126);
            contractMultiplier.Margin = new Padding(4, 3, 4, 3);
            contractMultiplier.Name = "contractMultiplier";
            contractMultiplier.Size = new Size(82, 23);
            contractMultiplier.TabIndex = 5;
            // 
            // contractCurrency
            // 
            contractCurrency.Location = new Point(96, 119);
            contractCurrency.Margin = new Padding(4, 3, 4, 3);
            contractCurrency.Name = "contractCurrency";
            contractCurrency.Size = new Size(82, 23);
            contractCurrency.TabIndex = 7;
            contractCurrency.Text = "USD";
            // 
            // contractExchange
            // 
            contractExchange.Location = new Point(96, 89);
            contractExchange.Margin = new Padding(4, 3, 4, 3);
            contractExchange.Name = "contractExchange";
            contractExchange.Size = new Size(82, 23);
            contractExchange.TabIndex = 6;
            contractExchange.Text = "SMART";
            // 
            // extendedOrderTab
            // 
            extendedOrderTab.BackColor = Color.LightGray;
            extendedOrderTab.Controls.Add(solicited);
            extendedOrderTab.Controls.Add(manualOrderCancelTime);
            extendedOrderTab.Controls.Add(labelManualOrderCancelTime);
            extendedOrderTab.Controls.Add(manualOrderTime);
            extendedOrderTab.Controls.Add(labelManualOrderTime);
            extendedOrderTab.Controls.Add(advancedErrorOverride);
            extendedOrderTab.Controls.Add(label27);
            extendedOrderTab.Controls.Add(autoCancelParent);
            extendedOrderTab.Controls.Add(postToAts);
            extendedOrderTab.Controls.Add(label26);
            extendedOrderTab.Controls.Add(duration);
            extendedOrderTab.Controls.Add(label25);
            extendedOrderTab.Controls.Add(relativeDiscretionary);
            extendedOrderTab.Controls.Add(omsContainer);
            extendedOrderTab.Controls.Add(dontUseAutoPriceForHedge);
            extendedOrderTab.Controls.Add(label22);
            extendedOrderTab.Controls.Add(mifid2ExecutionAlgo);
            extendedOrderTab.Controls.Add(label23);
            extendedOrderTab.Controls.Add(mifid2ExecutionTrader);
            extendedOrderTab.Controls.Add(label18);
            extendedOrderTab.Controls.Add(mifid2DecisionAlgo);
            extendedOrderTab.Controls.Add(label19);
            extendedOrderTab.Controls.Add(mifid2DecisionMaker);
            extendedOrderTab.Controls.Add(label17);
            extendedOrderTab.Controls.Add(softDollarTier);
            extendedOrderTab.Controls.Add(trailingPercentLabel);
            extendedOrderTab.Controls.Add(transmit);
            extendedOrderTab.Controls.Add(overrideConstraints);
            extendedOrderTab.Controls.Add(label5);
            extendedOrderTab.Controls.Add(optOutSmart);
            extendedOrderTab.Controls.Add(trailingPercent);
            extendedOrderTab.Controls.Add(discretionaryAmount);
            extendedOrderTab.Controls.Add(hidden);
            extendedOrderTab.Controls.Add(outsideRTH);
            extendedOrderTab.Controls.Add(label3);
            extendedOrderTab.Controls.Add(allOrNone);
            extendedOrderTab.Controls.Add(label2);
            extendedOrderTab.Controls.Add(notHeld);
            extendedOrderTab.Controls.Add(block);
            extendedOrderTab.Controls.Add(label1);
            extendedOrderTab.Controls.Add(sweepToFill);
            extendedOrderTab.Controls.Add(percentOffsetLabel);
            extendedOrderTab.Controls.Add(tiggerMethodLabel);
            extendedOrderTab.Controls.Add(rule80ALabel);
            extendedOrderTab.Controls.Add(goodUntilLabel);
            extendedOrderTab.Controls.Add(goodAfterLabel);
            extendedOrderTab.Controls.Add(ocaGroup);
            extendedOrderTab.Controls.Add(hedgeParam);
            extendedOrderTab.Controls.Add(ocaType);
            extendedOrderTab.Controls.Add(hedgeType);
            extendedOrderTab.Controls.Add(orderMinQtyLabel);
            extendedOrderTab.Controls.Add(orderRefLabel);
            extendedOrderTab.Controls.Add(trailStopPrice);
            extendedOrderTab.Controls.Add(percentOffset);
            extendedOrderTab.Controls.Add(triggerMethod);
            extendedOrderTab.Controls.Add(rule80A);
            extendedOrderTab.Controls.Add(goodUntil);
            extendedOrderTab.Controls.Add(goodAfter);
            extendedOrderTab.Controls.Add(minQty);
            extendedOrderTab.Controls.Add(orderReference);
            extendedOrderTab.Location = new Point(4, 24);
            extendedOrderTab.Margin = new Padding(4, 3, 4, 3);
            extendedOrderTab.Name = "extendedOrderTab";
            extendedOrderTab.Padding = new Padding(4, 3, 4, 3);
            extendedOrderTab.Size = new Size(865, 443);
            extendedOrderTab.TabIndex = 1;
            extendedOrderTab.Text = "Extended Attributes";
            // 
            // solicited
            // 
            solicited.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            solicited.AutoSize = true;
            solicited.CheckAlign = ContentAlignment.MiddleRight;
            solicited.Location = new Point(559, 213);
            solicited.Margin = new Padding(4, 3, 4, 3);
            solicited.Name = "solicited";
            solicited.Size = new Size(71, 19);
            solicited.TabIndex = 59;
            solicited.Text = "Solicited";
            solicited.UseVisualStyleBackColor = true;
            // 
            // manualOrderCancelTime
            // 
            manualOrderCancelTime.Location = new Point(396, 377);
            manualOrderCancelTime.Margin = new Padding(4, 3, 4, 3);
            manualOrderCancelTime.Name = "manualOrderCancelTime";
            manualOrderCancelTime.Size = new Size(81, 23);
            manualOrderCancelTime.TabIndex = 58;
            // 
            // labelManualOrderCancelTime
            // 
            labelManualOrderCancelTime.AutoSize = true;
            labelManualOrderCancelTime.Location = new Point(239, 381);
            labelManualOrderCancelTime.Margin = new Padding(4, 0, 4, 0);
            labelManualOrderCancelTime.Name = "labelManualOrderCancelTime";
            labelManualOrderCancelTime.Size = new Size(129, 15);
            labelManualOrderCancelTime.TabIndex = 57;
            labelManualOrderCancelTime.Text = "Manual Order Cxl Time";
            // 
            // manualOrderTime
            // 
            manualOrderTime.Location = new Point(146, 377);
            manualOrderTime.Margin = new Padding(4, 3, 4, 3);
            manualOrderTime.Name = "manualOrderTime";
            manualOrderTime.Size = new Size(81, 23);
            manualOrderTime.TabIndex = 56;
            // 
            // labelManualOrderTime
            // 
            labelManualOrderTime.AutoSize = true;
            labelManualOrderTime.Location = new Point(26, 381);
            labelManualOrderTime.Margin = new Padding(4, 0, 4, 0);
            labelManualOrderTime.Name = "labelManualOrderTime";
            labelManualOrderTime.Size = new Size(109, 15);
            labelManualOrderTime.TabIndex = 55;
            labelManualOrderTime.Text = "Manual Order Time";
            // 
            // advancedErrorOverride
            // 
            advancedErrorOverride.Location = new Point(637, 345);
            advancedErrorOverride.Margin = new Padding(4, 3, 4, 3);
            advancedErrorOverride.Name = "advancedErrorOverride";
            advancedErrorOverride.Size = new Size(81, 23);
            advancedErrorOverride.TabIndex = 54;
            // 
            // label27
            // 
            label27.AutoSize = true;
            label27.Location = new Point(492, 348);
            label27.Margin = new Padding(4, 0, 4, 0);
            label27.Name = "label27";
            label27.Size = new Size(136, 15);
            label27.TabIndex = 53;
            label27.Text = "Advanced Error Override";
            // 
            // autoCancelParent
            // 
            autoCancelParent.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            autoCancelParent.AutoSize = true;
            autoCancelParent.CheckAlign = ContentAlignment.MiddleRight;
            autoCancelParent.Location = new Point(502, 190);
            autoCancelParent.Margin = new Padding(4, 3, 4, 3);
            autoCancelParent.Name = "autoCancelParent";
            autoCancelParent.Size = new Size(128, 19);
            autoCancelParent.TabIndex = 52;
            autoCancelParent.Text = "Auto Cancel Parent";
            autoCancelParent.UseVisualStyleBackColor = true;
            // 
            // postToAts
            // 
            postToAts.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            postToAts.Location = new Point(653, 104);
            postToAts.Margin = new Padding(4, 3, 4, 3);
            postToAts.Name = "postToAts";
            postToAts.Size = new Size(63, 23);
            postToAts.TabIndex = 51;
            // 
            // label26
            // 
            label26.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label26.AutoSize = true;
            label26.Location = new Point(574, 108);
            label26.Margin = new Padding(4, 0, 4, 0);
            label26.Name = "label26";
            label26.Size = new Size(65, 15);
            label26.TabIndex = 50;
            label26.Text = "Post To Ats";
            // 
            // duration
            // 
            duration.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            duration.Location = new Point(470, 104);
            duration.Margin = new Padding(4, 3, 4, 3);
            duration.Name = "duration";
            duration.Size = new Size(81, 23);
            duration.TabIndex = 34;
            // 
            // label25
            // 
            label25.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label25.AutoSize = true;
            label25.Location = new Point(408, 108);
            label25.Margin = new Padding(4, 0, 4, 0);
            label25.Name = "label25";
            label25.Size = new Size(53, 15);
            label25.TabIndex = 33;
            label25.Text = "Duration";
            // 
            // relativeDiscretionary
            // 
            relativeDiscretionary.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            relativeDiscretionary.AutoSize = true;
            relativeDiscretionary.CheckAlign = ContentAlignment.MiddleRight;
            relativeDiscretionary.Location = new Point(492, 315);
            relativeDiscretionary.Margin = new Padding(4, 3, 4, 3);
            relativeDiscretionary.Name = "relativeDiscretionary";
            relativeDiscretionary.Size = new Size(138, 19);
            relativeDiscretionary.TabIndex = 48;
            relativeDiscretionary.Text = "Relative discretionary";
            relativeDiscretionary.UseVisualStyleBackColor = true;
            // 
            // omsContainer
            // 
            omsContainer.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            omsContainer.AutoSize = true;
            omsContainer.CheckAlign = ContentAlignment.MiddleRight;
            omsContainer.Location = new Point(523, 293);
            omsContainer.Margin = new Padding(4, 3, 4, 3);
            omsContainer.Name = "omsContainer";
            omsContainer.Size = new Size(107, 19);
            omsContainer.TabIndex = 45;
            omsContainer.Text = "OMS Container";
            omsContainer.UseVisualStyleBackColor = true;
            // 
            // dontUseAutoPriceForHedge
            // 
            dontUseAutoPriceForHedge.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            dontUseAutoPriceForHedge.AutoSize = true;
            dontUseAutoPriceForHedge.CheckAlign = ContentAlignment.MiddleRight;
            dontUseAutoPriceForHedge.Location = new Point(444, 267);
            dontUseAutoPriceForHedge.Margin = new Padding(4, 3, 4, 3);
            dontUseAutoPriceForHedge.Name = "dontUseAutoPriceForHedge";
            dontUseAutoPriceForHedge.Size = new Size(186, 19);
            dontUseAutoPriceForHedge.TabIndex = 44;
            dontUseAutoPriceForHedge.Text = "Don't use auto price for hedge";
            dontUseAutoPriceForHedge.UseVisualStyleBackColor = true;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.Location = new Point(239, 348);
            label22.Margin = new Padding(4, 0, 4, 0);
            label22.Name = "label22";
            label22.Size = new Size(130, 15);
            label22.TabIndex = 49;
            label22.Text = "MiFID II Execution Algo";
            // 
            // mifid2ExecutionAlgo
            // 
            mifid2ExecutionAlgo.Location = new Point(396, 345);
            mifid2ExecutionAlgo.Margin = new Padding(4, 3, 4, 3);
            mifid2ExecutionAlgo.Name = "mifid2ExecutionAlgo";
            mifid2ExecutionAlgo.Size = new Size(81, 23);
            mifid2ExecutionAlgo.TabIndex = 0;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.Location = new Point(239, 318);
            label23.Margin = new Padding(4, 0, 4, 0);
            label23.Name = "label23";
            label23.Size = new Size(137, 15);
            label23.TabIndex = 46;
            label23.Text = "MiFID II Execution Trader";
            // 
            // mifid2ExecutionTrader
            // 
            mifid2ExecutionTrader.Location = new Point(396, 315);
            mifid2ExecutionTrader.Margin = new Padding(4, 3, 4, 3);
            mifid2ExecutionTrader.Name = "mifid2ExecutionTrader";
            mifid2ExecutionTrader.Size = new Size(81, 23);
            mifid2ExecutionTrader.TabIndex = 47;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(8, 348);
            label18.Margin = new Padding(4, 0, 4, 0);
            label18.Name = "label18";
            label18.Size = new Size(123, 15);
            label18.TabIndex = 23;
            label18.Text = "MiFID II Decision Algo";
            // 
            // mifid2DecisionAlgo
            // 
            mifid2DecisionAlgo.Location = new Point(146, 345);
            mifid2DecisionAlgo.Margin = new Padding(4, 3, 4, 3);
            mifid2DecisionAlgo.Name = "mifid2DecisionAlgo";
            mifid2DecisionAlgo.Size = new Size(81, 23);
            mifid2DecisionAlgo.TabIndex = 24;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(4, 318);
            label19.Margin = new Padding(4, 0, 4, 0);
            label19.Name = "label19";
            label19.Size = new Size(131, 15);
            label19.TabIndex = 21;
            label19.Text = "MiFID II Decision Maker";
            // 
            // mifid2DecisionMaker
            // 
            mifid2DecisionMaker.Location = new Point(146, 315);
            mifid2DecisionMaker.Margin = new Padding(4, 3, 4, 3);
            mifid2DecisionMaker.Name = "mifid2DecisionMaker";
            mifid2DecisionMaker.Size = new Size(81, 23);
            mifid2DecisionMaker.TabIndex = 22;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(56, 287);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(81, 15);
            label17.TabIndex = 19;
            label17.Text = "Soft dollar tier";
            // 
            // softDollarTier
            // 
            softDollarTier.FormattingEnabled = true;
            softDollarTier.Location = new Point(146, 284);
            softDollarTier.Margin = new Padding(4, 3, 4, 3);
            softDollarTier.Name = "softDollarTier";
            softDollarTier.Size = new Size(128, 23);
            softDollarTier.TabIndex = 20;
            // 
            // trailingPercentLabel
            // 
            trailingPercentLabel.AutoSize = true;
            trailingPercentLabel.Location = new Point(46, 258);
            trailingPercentLabel.Margin = new Padding(4, 0, 4, 0);
            trailingPercentLabel.Name = "trailingPercentLabel";
            trailingPercentLabel.Size = new Size(88, 15);
            trailingPercentLabel.TabIndex = 17;
            trailingPercentLabel.Text = "Trailing percent";
            // 
            // transmit
            // 
            transmit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            transmit.AutoSize = true;
            transmit.CheckAlign = ContentAlignment.MiddleRight;
            transmit.Checked = true;
            transmit.CheckState = CheckState.Checked;
            transmit.Location = new Point(647, 136);
            transmit.Margin = new Padding(4, 3, 4, 3);
            transmit.Name = "transmit";
            transmit.Size = new Size(71, 19);
            transmit.TabIndex = 37;
            transmit.Text = "Transmit";
            transmit.UseVisualStyleBackColor = true;
            // 
            // overrideConstraints
            // 
            overrideConstraints.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            overrideConstraints.AutoSize = true;
            overrideConstraints.CheckAlign = ContentAlignment.MiddleRight;
            overrideConstraints.Location = new Point(498, 163);
            overrideConstraints.Margin = new Padding(4, 3, 4, 3);
            overrideConstraints.Name = "overrideConstraints";
            overrideConstraints.Size = new Size(132, 19);
            overrideConstraints.TabIndex = 39;
            overrideConstraints.Text = "Override constraints";
            overrideConstraints.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(340, 77);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(121, 15);
            label5.TabIndex = 31;
            label5.Text = "Discretionary amount";
            // 
            // optOutSmart
            // 
            optOutSmart.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            optOutSmart.AutoSize = true;
            optOutSmart.CheckAlign = ContentAlignment.MiddleRight;
            optOutSmart.Location = new Point(481, 240);
            optOutSmart.Margin = new Padding(4, 3, 4, 3);
            optOutSmart.Name = "optOutSmart";
            optOutSmart.Size = new Size(149, 19);
            optOutSmart.TabIndex = 43;
            optOutSmart.Text = "Opt out SMART routing";
            optOutSmart.UseVisualStyleBackColor = true;
            // 
            // trailingPercent
            // 
            trailingPercent.Location = new Point(146, 254);
            trailingPercent.Margin = new Padding(4, 3, 4, 3);
            trailingPercent.Name = "trailingPercent";
            trailingPercent.Size = new Size(81, 23);
            trailingPercent.TabIndex = 18;
            // 
            // discretionaryAmount
            // 
            discretionaryAmount.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            discretionaryAmount.Location = new Point(470, 74);
            discretionaryAmount.Margin = new Padding(4, 3, 4, 3);
            discretionaryAmount.Name = "discretionaryAmount";
            discretionaryAmount.Size = new Size(81, 23);
            discretionaryAmount.TabIndex = 32;
            // 
            // hidden
            // 
            hidden.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hidden.AutoSize = true;
            hidden.CheckAlign = ContentAlignment.MiddleRight;
            hidden.Location = new Point(398, 213);
            hidden.Margin = new Padding(4, 3, 4, 3);
            hidden.Name = "hidden";
            hidden.Size = new Size(65, 19);
            hidden.TabIndex = 41;
            hidden.Text = "Hidden";
            hidden.UseVisualStyleBackColor = true;
            // 
            // outsideRTH
            // 
            outsideRTH.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            outsideRTH.AutoSize = true;
            outsideRTH.CheckAlign = ContentAlignment.MiddleRight;
            outsideRTH.Location = new Point(356, 240);
            outsideRTH.Margin = new Padding(4, 3, 4, 3);
            outsideRTH.Name = "outsideRTH";
            outsideRTH.Size = new Size(107, 19);
            outsideRTH.TabIndex = 42;
            outsideRTH.Text = "Fill outside RTH";
            outsideRTH.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(329, 48);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(128, 15);
            label3.TabIndex = 28;
            label3.Text = "Hedge type and param";
            // 
            // allOrNone
            // 
            allOrNone.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            allOrNone.AutoSize = true;
            allOrNone.CheckAlign = ContentAlignment.MiddleRight;
            allOrNone.Location = new Point(546, 136);
            allOrNone.Margin = new Padding(4, 3, 4, 3);
            allOrNone.Name = "allOrNone";
            allOrNone.Size = new Size(84, 19);
            allOrNone.TabIndex = 36;
            allOrNone.Text = "All or none";
            allOrNone.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(343, 17);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(116, 15);
            label2.TabIndex = 25;
            label2.Text = "OCA group and type";
            // 
            // notHeld
            // 
            notHeld.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            notHeld.AutoSize = true;
            notHeld.CheckAlign = ContentAlignment.MiddleRight;
            notHeld.Location = new Point(391, 136);
            notHeld.Margin = new Padding(4, 3, 4, 3);
            notHeld.Name = "notHeld";
            notHeld.Size = new Size(72, 19);
            notHeld.TabIndex = 35;
            notHeld.Text = "Not held";
            notHeld.UseVisualStyleBackColor = true;
            // 
            // block
            // 
            block.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            block.AutoSize = true;
            block.CheckAlign = ContentAlignment.MiddleRight;
            block.Location = new Point(377, 163);
            block.Margin = new Padding(4, 3, 4, 3);
            block.Name = "block";
            block.Size = new Size(86, 19);
            block.TabIndex = 38;
            block.Text = "Block order";
            block.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(19, 228);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 15;
            label1.Text = "Trail order stop price";
            // 
            // sweepToFill
            // 
            sweepToFill.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            sweepToFill.AutoSize = true;
            sweepToFill.CheckAlign = ContentAlignment.MiddleRight;
            sweepToFill.Location = new Point(373, 189);
            sweepToFill.Margin = new Padding(4, 3, 4, 3);
            sweepToFill.Name = "sweepToFill";
            sweepToFill.Size = new Size(90, 19);
            sweepToFill.TabIndex = 40;
            sweepToFill.Text = "Sweep to fill";
            sweepToFill.UseVisualStyleBackColor = true;
            // 
            // percentOffsetLabel
            // 
            percentOffsetLabel.AutoSize = true;
            percentOffsetLabel.Location = new Point(51, 198);
            percentOffsetLabel.Margin = new Padding(4, 0, 4, 0);
            percentOffsetLabel.Name = "percentOffsetLabel";
            percentOffsetLabel.Size = new Size(82, 15);
            percentOffsetLabel.TabIndex = 13;
            percentOffsetLabel.Text = "Percent Offset";
            // 
            // tiggerMethodLabel
            // 
            tiggerMethodLabel.AutoSize = true;
            tiggerMethodLabel.Location = new Point(47, 168);
            tiggerMethodLabel.Margin = new Padding(4, 0, 4, 0);
            tiggerMethodLabel.Name = "tiggerMethodLabel";
            tiggerMethodLabel.Size = new Size(88, 15);
            tiggerMethodLabel.TabIndex = 11;
            tiggerMethodLabel.Text = "Trigger Method";
            // 
            // rule80ALabel
            // 
            rule80ALabel.AutoSize = true;
            rule80ALabel.Location = new Point(79, 138);
            rule80ALabel.Margin = new Padding(4, 0, 4, 0);
            rule80ALabel.Name = "rule80ALabel";
            rule80ALabel.Size = new Size(53, 15);
            rule80ALabel.TabIndex = 9;
            rule80ALabel.Text = "Rule 80A";
            // 
            // goodUntilLabel
            // 
            goodUntilLabel.AutoSize = true;
            goodUntilLabel.Location = new Point(75, 108);
            goodUntilLabel.Margin = new Padding(4, 0, 4, 0);
            goodUntilLabel.Name = "goodUntilLabel";
            goodUntilLabel.Size = new Size(63, 15);
            goodUntilLabel.TabIndex = 7;
            goodUntilLabel.Text = "Good until";
            // 
            // goodAfterLabel
            // 
            goodAfterLabel.AutoSize = true;
            goodAfterLabel.Location = new Point(72, 78);
            goodAfterLabel.Margin = new Padding(4, 0, 4, 0);
            goodAfterLabel.Name = "goodAfterLabel";
            goodAfterLabel.Size = new Size(63, 15);
            goodAfterLabel.TabIndex = 5;
            goodAfterLabel.Text = "Good after";
            // 
            // ocaGroup
            // 
            ocaGroup.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ocaGroup.Location = new Point(470, 14);
            ocaGroup.Margin = new Padding(4, 3, 4, 3);
            ocaGroup.Name = "ocaGroup";
            ocaGroup.Size = new Size(81, 23);
            ocaGroup.TabIndex = 26;
            // 
            // hedgeParam
            // 
            hedgeParam.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hedgeParam.Location = new Point(559, 45);
            hedgeParam.Margin = new Padding(4, 3, 4, 3);
            hedgeParam.Name = "hedgeParam";
            hedgeParam.Size = new Size(61, 23);
            hedgeParam.TabIndex = 30;
            // 
            // ocaType
            // 
            ocaType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            ocaType.FormattingEnabled = true;
            ocaType.Location = new Point(559, 14);
            ocaType.Margin = new Padding(4, 3, 4, 3);
            ocaType.Name = "ocaType";
            ocaType.Size = new Size(163, 23);
            ocaType.TabIndex = 27;
            // 
            // hedgeType
            // 
            hedgeType.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            hedgeType.FormattingEnabled = true;
            hedgeType.Location = new Point(470, 44);
            hedgeType.Margin = new Padding(4, 3, 4, 3);
            hedgeType.Name = "hedgeType";
            hedgeType.Size = new Size(81, 23);
            hedgeType.TabIndex = 29;
            // 
            // orderMinQtyLabel
            // 
            orderMinQtyLabel.AutoSize = true;
            orderMinQtyLabel.Location = new Point(82, 50);
            orderMinQtyLabel.Margin = new Padding(4, 0, 4, 0);
            orderMinQtyLabel.Name = "orderMinQtyLabel";
            orderMinQtyLabel.Size = new Size(56, 15);
            orderMinQtyLabel.TabIndex = 3;
            orderMinQtyLabel.Text = "Min. Qty.";
            // 
            // orderRefLabel
            // 
            orderRefLabel.AutoSize = true;
            orderRefLabel.Location = new Point(74, 18);
            orderRefLabel.Margin = new Padding(4, 0, 4, 0);
            orderRefLabel.Name = "orderRefLabel";
            orderRefLabel.Size = new Size(60, 15);
            orderRefLabel.TabIndex = 0;
            orderRefLabel.Text = "Order Ref.";
            // 
            // trailStopPrice
            // 
            trailStopPrice.Location = new Point(146, 224);
            trailStopPrice.Margin = new Padding(4, 3, 4, 3);
            trailStopPrice.Name = "trailStopPrice";
            trailStopPrice.Size = new Size(81, 23);
            trailStopPrice.TabIndex = 16;
            // 
            // percentOffset
            // 
            percentOffset.Location = new Point(146, 195);
            percentOffset.Margin = new Padding(4, 3, 4, 3);
            percentOffset.Name = "percentOffset";
            percentOffset.Size = new Size(81, 23);
            percentOffset.TabIndex = 14;
            // 
            // triggerMethod
            // 
            triggerMethod.FormattingEnabled = true;
            triggerMethod.Location = new Point(146, 164);
            triggerMethod.Margin = new Padding(4, 3, 4, 3);
            triggerMethod.Name = "triggerMethod";
            triggerMethod.Size = new Size(128, 23);
            triggerMethod.TabIndex = 12;
            // 
            // rule80A
            // 
            rule80A.FormattingEnabled = true;
            rule80A.Location = new Point(146, 133);
            rule80A.Margin = new Padding(4, 3, 4, 3);
            rule80A.Name = "rule80A";
            rule80A.Size = new Size(128, 23);
            rule80A.TabIndex = 10;
            // 
            // goodUntil
            // 
            goodUntil.Location = new Point(146, 105);
            goodUntil.Margin = new Padding(4, 3, 4, 3);
            goodUntil.Name = "goodUntil";
            goodUntil.Size = new Size(81, 23);
            goodUntil.TabIndex = 8;
            // 
            // goodAfter
            // 
            goodAfter.Location = new Point(146, 75);
            goodAfter.Margin = new Padding(4, 3, 4, 3);
            goodAfter.Name = "goodAfter";
            goodAfter.Size = new Size(81, 23);
            goodAfter.TabIndex = 6;
            // 
            // minQty
            // 
            minQty.Location = new Point(146, 45);
            minQty.Margin = new Padding(4, 3, 4, 3);
            minQty.Name = "minQty";
            minQty.Size = new Size(81, 23);
            minQty.TabIndex = 4;
            // 
            // orderReference
            // 
            orderReference.Location = new Point(146, 15);
            orderReference.Margin = new Padding(4, 3, 4, 3);
            orderReference.Name = "orderReference";
            orderReference.Size = new Size(81, 23);
            orderReference.TabIndex = 1;
            // 
            // advisorTab
            // 
            advisorTab.BackColor = Color.LightGray;
            advisorTab.Controls.Add(faPercentage);
            advisorTab.Controls.Add(faProfile);
            advisorTab.Controls.Add(faMethod);
            advisorTab.Controls.Add(faGroup);
            advisorTab.Controls.Add(profileLabel);
            advisorTab.Controls.Add(orLabel);
            advisorTab.Controls.Add(percentageLabel);
            advisorTab.Controls.Add(methodLabel);
            advisorTab.Controls.Add(groupLabel);
            advisorTab.Location = new Point(4, 24);
            advisorTab.Margin = new Padding(4, 3, 4, 3);
            advisorTab.Name = "advisorTab";
            advisorTab.Padding = new Padding(4, 3, 4, 3);
            advisorTab.Size = new Size(865, 443);
            advisorTab.TabIndex = 2;
            advisorTab.Text = "Advisor";
            // 
            // faPercentage
            // 
            faPercentage.Location = new Point(89, 75);
            faPercentage.Margin = new Padding(4, 3, 4, 3);
            faPercentage.Name = "faPercentage";
            faPercentage.Size = new Size(82, 23);
            faPercentage.TabIndex = 8;
            // 
            // faProfile
            // 
            faProfile.Location = new Point(89, 135);
            faProfile.Margin = new Padding(4, 3, 4, 3);
            faProfile.Name = "faProfile";
            faProfile.Size = new Size(82, 23);
            faProfile.TabIndex = 7;
            // 
            // faMethod
            // 
            faMethod.FormattingEnabled = true;
            faMethod.Location = new Point(89, 44);
            faMethod.Margin = new Padding(4, 3, 4, 3);
            faMethod.Name = "faMethod";
            faMethod.Size = new Size(111, 23);
            faMethod.TabIndex = 6;
            // 
            // faGroup
            // 
            faGroup.Location = new Point(89, 14);
            faGroup.Margin = new Padding(4, 3, 4, 3);
            faGroup.Name = "faGroup";
            faGroup.Size = new Size(82, 23);
            faGroup.TabIndex = 5;
            // 
            // profileLabel
            // 
            profileLabel.AutoSize = true;
            profileLabel.Location = new Point(40, 135);
            profileLabel.Margin = new Padding(4, 0, 4, 0);
            profileLabel.Name = "profileLabel";
            profileLabel.Size = new Size(41, 15);
            profileLabel.TabIndex = 4;
            profileLabel.Text = "Profile";
            // 
            // orLabel
            // 
            orLabel.AutoSize = true;
            orLabel.Location = new Point(49, 108);
            orLabel.Margin = new Padding(4, 0, 4, 0);
            orLabel.Name = "orLabel";
            orLabel.Size = new Size(38, 15);
            orLabel.TabIndex = 3;
            orLabel.Text = "--or--";
            // 
            // percentageLabel
            // 
            percentageLabel.AutoSize = true;
            percentageLabel.Location = new Point(9, 78);
            percentageLabel.Margin = new Padding(4, 0, 4, 0);
            percentageLabel.Name = "percentageLabel";
            percentageLabel.Size = new Size(66, 15);
            percentageLabel.TabIndex = 2;
            percentageLabel.Text = "Percentage";
            // 
            // methodLabel
            // 
            methodLabel.AutoSize = true;
            methodLabel.Location = new Point(31, 47);
            methodLabel.Margin = new Padding(4, 0, 4, 0);
            methodLabel.Name = "methodLabel";
            methodLabel.Size = new Size(49, 15);
            methodLabel.TabIndex = 1;
            methodLabel.Text = "Method";
            // 
            // groupLabel
            // 
            groupLabel.AutoSize = true;
            groupLabel.Location = new Point(40, 17);
            groupLabel.Margin = new Padding(4, 0, 4, 0);
            groupLabel.Name = "groupLabel";
            groupLabel.Size = new Size(40, 15);
            groupLabel.TabIndex = 0;
            groupLabel.Text = "Group";
            // 
            // volatilityTab
            // 
            volatilityTab.BackColor = Color.LightGray;
            volatilityTab.Controls.Add(stockRangeLower);
            volatilityTab.Controls.Add(stockRangeUpper);
            volatilityTab.Controls.Add(deltaNeutralConId);
            volatilityTab.Controls.Add(deltaNeutralAuxPrice);
            volatilityTab.Controls.Add(deltaNeutralOrderType);
            volatilityTab.Controls.Add(optionReferencePrice);
            volatilityTab.Controls.Add(volatilityType);
            volatilityTab.Controls.Add(volatility);
            volatilityTab.Controls.Add(continuousUpdate);
            volatilityTab.Controls.Add(stockRangeLowerLabel);
            volatilityTab.Controls.Add(sockRangeUpperLabel);
            volatilityTab.Controls.Add(hedgeContractConIdLabel);
            volatilityTab.Controls.Add(hedgeOrderAuxPriceLabel);
            volatilityTab.Controls.Add(hedgeOrderTypeLabel);
            volatilityTab.Controls.Add(optionReferencePriceLabel);
            volatilityTab.Controls.Add(volatilityLabel);
            volatilityTab.Location = new Point(4, 24);
            volatilityTab.Margin = new Padding(4, 3, 4, 3);
            volatilityTab.Name = "volatilityTab";
            volatilityTab.Padding = new Padding(4, 3, 4, 3);
            volatilityTab.Size = new Size(865, 443);
            volatilityTab.TabIndex = 3;
            volatilityTab.Text = "Volatility";
            // 
            // stockRangeLower
            // 
            stockRangeLower.Location = new Point(188, 220);
            stockRangeLower.Margin = new Padding(4, 3, 4, 3);
            stockRangeLower.Name = "stockRangeLower";
            stockRangeLower.Size = new Size(82, 23);
            stockRangeLower.TabIndex = 16;
            // 
            // stockRangeUpper
            // 
            stockRangeUpper.Location = new Point(188, 190);
            stockRangeUpper.Margin = new Padding(4, 3, 4, 3);
            stockRangeUpper.Name = "stockRangeUpper";
            stockRangeUpper.Size = new Size(82, 23);
            stockRangeUpper.TabIndex = 15;
            // 
            // deltaNeutralConId
            // 
            deltaNeutralConId.Location = new Point(188, 160);
            deltaNeutralConId.Margin = new Padding(4, 3, 4, 3);
            deltaNeutralConId.Name = "deltaNeutralConId";
            deltaNeutralConId.Size = new Size(82, 23);
            deltaNeutralConId.TabIndex = 14;
            // 
            // deltaNeutralAuxPrice
            // 
            deltaNeutralAuxPrice.Location = new Point(188, 130);
            deltaNeutralAuxPrice.Margin = new Padding(4, 3, 4, 3);
            deltaNeutralAuxPrice.Name = "deltaNeutralAuxPrice";
            deltaNeutralAuxPrice.Size = new Size(82, 23);
            deltaNeutralAuxPrice.TabIndex = 13;
            // 
            // deltaNeutralOrderType
            // 
            deltaNeutralOrderType.FormattingEnabled = true;
            deltaNeutralOrderType.Items.AddRange(new object[] { "None", "MKT", "LMT", "STP", "STP LMT", "REL", "TRAIL", "BOX TOP", "FIX PEGGED", "LIT", "LMT + MKT", "LOC", "MIT", "MKT PRT", "MOC", "MTL", "PASSV REL", "PEG BENCH", "PEG BEST", "PEG MID", "PEG MKT", "PEG PRIM", "PEG STK", "REL +LMT", "REL + MKT", "STP PRT", "TRAIL LIMIT", "TRAIL LMT + MKT", "TRAIL LIT", "TRAIL REL + MKT", "TRAIL MIT", "TRAIL REL + MKT", "VOL", "VWAP" });
            deltaNeutralOrderType.Location = new Point(188, 99);
            deltaNeutralOrderType.Margin = new Padding(4, 3, 4, 3);
            deltaNeutralOrderType.Name = "deltaNeutralOrderType";
            deltaNeutralOrderType.Size = new Size(134, 23);
            deltaNeutralOrderType.TabIndex = 12;
            deltaNeutralOrderType.Text = "None";
            // 
            // optionReferencePrice
            // 
            optionReferencePrice.FormattingEnabled = true;
            optionReferencePrice.Location = new Point(188, 68);
            optionReferencePrice.Margin = new Padding(4, 3, 4, 3);
            optionReferencePrice.Name = "optionReferencePrice";
            optionReferencePrice.Size = new Size(82, 23);
            optionReferencePrice.TabIndex = 11;
            // 
            // volatilityType
            // 
            volatilityType.FormattingEnabled = true;
            volatilityType.Location = new Point(278, 12);
            volatilityType.Margin = new Padding(4, 3, 4, 3);
            volatilityType.Name = "volatilityType";
            volatilityType.Size = new Size(82, 23);
            volatilityType.TabIndex = 10;
            // 
            // volatility
            // 
            volatility.Location = new Point(188, 12);
            volatility.Margin = new Padding(4, 3, 4, 3);
            volatility.Name = "volatility";
            volatility.Size = new Size(82, 23);
            volatility.TabIndex = 9;
            // 
            // continuousUpdate
            // 
            continuousUpdate.AutoSize = true;
            continuousUpdate.CheckAlign = ContentAlignment.MiddleRight;
            continuousUpdate.Location = new Point(31, 42);
            continuousUpdate.Margin = new Padding(4, 3, 4, 3);
            continuousUpdate.Name = "continuousUpdate";
            continuousUpdate.Size = new Size(166, 19);
            continuousUpdate.TabIndex = 8;
            continuousUpdate.Text = "Continuously update price";
            continuousUpdate.UseVisualStyleBackColor = true;
            // 
            // stockRangeLowerLabel
            // 
            stockRangeLowerLabel.AutoSize = true;
            stockRangeLowerLabel.Location = new Point(65, 224);
            stockRangeLowerLabel.Margin = new Padding(4, 0, 4, 0);
            stockRangeLowerLabel.Name = "stockRangeLowerLabel";
            stockRangeLowerLabel.Size = new Size(109, 15);
            stockRangeLowerLabel.TabIndex = 7;
            stockRangeLowerLabel.Text = "Stock range - lower";
            // 
            // sockRangeUpperLabel
            // 
            sockRangeUpperLabel.AutoSize = true;
            sockRangeUpperLabel.Location = new Point(63, 194);
            sockRangeUpperLabel.Margin = new Padding(4, 0, 4, 0);
            sockRangeUpperLabel.Name = "sockRangeUpperLabel";
            sockRangeUpperLabel.Size = new Size(111, 15);
            sockRangeUpperLabel.TabIndex = 6;
            sockRangeUpperLabel.Text = "Stock range - upper";
            // 
            // hedgeContractConIdLabel
            // 
            hedgeContractConIdLabel.AutoSize = true;
            hedgeContractConIdLabel.Location = new Point(68, 164);
            hedgeContractConIdLabel.Margin = new Padding(4, 0, 4, 0);
            hedgeContractConIdLabel.Name = "hedgeContractConIdLabel";
            hedgeContractConIdLabel.Size = new Size(107, 15);
            hedgeContractConIdLabel.TabIndex = 5;
            hedgeContractConIdLabel.Text = "Delta neutral conId";
            // 
            // hedgeOrderAuxPriceLabel
            // 
            hedgeOrderAuxPriceLabel.AutoSize = true;
            hedgeOrderAuxPriceLabel.Location = new Point(49, 134);
            hedgeOrderAuxPriceLabel.Margin = new Padding(4, 0, 4, 0);
            hedgeOrderAuxPriceLabel.Name = "hedgeOrderAuxPriceLabel";
            hedgeOrderAuxPriceLabel.Size = new Size(125, 15);
            hedgeOrderAuxPriceLabel.TabIndex = 4;
            hedgeOrderAuxPriceLabel.Text = "Delta neutral aux price";
            // 
            // hedgeOrderTypeLabel
            // 
            hedgeOrderTypeLabel.AutoSize = true;
            hedgeOrderTypeLabel.Location = new Point(44, 103);
            hedgeOrderTypeLabel.Margin = new Padding(4, 0, 4, 0);
            hedgeOrderTypeLabel.Name = "hedgeOrderTypeLabel";
            hedgeOrderTypeLabel.Size = new Size(131, 15);
            hedgeOrderTypeLabel.TabIndex = 3;
            hedgeOrderTypeLabel.Text = "Delta neutral order type";
            // 
            // optionReferencePriceLabel
            // 
            optionReferencePriceLabel.AutoSize = true;
            optionReferencePriceLabel.Location = new Point(50, 72);
            optionReferencePriceLabel.Margin = new Padding(4, 0, 4, 0);
            optionReferencePriceLabel.Name = "optionReferencePriceLabel";
            optionReferencePriceLabel.Size = new Size(125, 15);
            optionReferencePriceLabel.TabIndex = 2;
            optionReferencePriceLabel.Text = "Option reference price";
            // 
            // volatilityLabel
            // 
            volatilityLabel.AutoSize = true;
            volatilityLabel.Location = new Point(128, 15);
            volatilityLabel.Margin = new Padding(4, 0, 4, 0);
            volatilityLabel.Name = "volatilityLabel";
            volatilityLabel.Size = new Size(52, 15);
            volatilityLabel.TabIndex = 0;
            volatilityLabel.Text = "Volatility";
            // 
            // scaleTab
            // 
            scaleTab.BackColor = Color.LightGray;
            scaleTab.Controls.Add(priceAdjustInterval);
            scaleTab.Controls.Add(priceAdjustValue);
            scaleTab.Controls.Add(initialFillQuantity);
            scaleTab.Controls.Add(initialPosition);
            scaleTab.Controls.Add(priceIncrement);
            scaleTab.Controls.Add(profitOffset);
            scaleTab.Controls.Add(subsequentLevelSize);
            scaleTab.Controls.Add(initialLevelSize);
            scaleTab.Controls.Add(autoReset);
            scaleTab.Controls.Add(randomiseSize);
            scaleTab.Controls.Add(secondsLabel);
            scaleTab.Controls.Add(initialPositionLabel);
            scaleTab.Controls.Add(initialFillQuantityLabel);
            scaleTab.Controls.Add(everyLabel);
            scaleTab.Controls.Add(priceAdjustValueLabel);
            scaleTab.Controls.Add(subsequentLevelSizeLabel);
            scaleTab.Controls.Add(profitOffsetLabel);
            scaleTab.Controls.Add(priceIncrementLabel);
            scaleTab.Controls.Add(initialLevelSizeLabel);
            scaleTab.Location = new Point(4, 24);
            scaleTab.Margin = new Padding(4, 3, 4, 3);
            scaleTab.Name = "scaleTab";
            scaleTab.Padding = new Padding(4, 3, 4, 3);
            scaleTab.Size = new Size(865, 443);
            scaleTab.TabIndex = 4;
            scaleTab.Text = "Scale";
            // 
            // priceAdjustInterval
            // 
            priceAdjustInterval.Location = new Point(285, 247);
            priceAdjustInterval.Margin = new Padding(4, 3, 4, 3);
            priceAdjustInterval.Name = "priceAdjustInterval";
            priceAdjustInterval.Size = new Size(81, 23);
            priceAdjustInterval.TabIndex = 18;
            // 
            // priceAdjustValue
            // 
            priceAdjustValue.Location = new Point(150, 247);
            priceAdjustValue.Margin = new Padding(4, 3, 4, 3);
            priceAdjustValue.Name = "priceAdjustValue";
            priceAdjustValue.Size = new Size(81, 23);
            priceAdjustValue.TabIndex = 17;
            // 
            // initialFillQuantity
            // 
            initialFillQuantity.Location = new Point(150, 217);
            initialFillQuantity.Margin = new Padding(4, 3, 4, 3);
            initialFillQuantity.Name = "initialFillQuantity";
            initialFillQuantity.Size = new Size(81, 23);
            initialFillQuantity.TabIndex = 16;
            // 
            // initialPosition
            // 
            initialPosition.Location = new Point(150, 187);
            initialPosition.Margin = new Padding(4, 3, 4, 3);
            initialPosition.Name = "initialPosition";
            initialPosition.Size = new Size(81, 23);
            initialPosition.TabIndex = 15;
            // 
            // priceIncrement
            // 
            priceIncrement.Location = new Point(150, 100);
            priceIncrement.Margin = new Padding(4, 3, 4, 3);
            priceIncrement.Name = "priceIncrement";
            priceIncrement.Size = new Size(81, 23);
            priceIncrement.TabIndex = 14;
            // 
            // profitOffset
            // 
            profitOffset.Location = new Point(150, 130);
            profitOffset.Margin = new Padding(4, 3, 4, 3);
            profitOffset.Name = "profitOffset";
            profitOffset.Size = new Size(81, 23);
            profitOffset.TabIndex = 13;
            // 
            // subsequentLevelSize
            // 
            subsequentLevelSize.Location = new Point(150, 44);
            subsequentLevelSize.Margin = new Padding(4, 3, 4, 3);
            subsequentLevelSize.Name = "subsequentLevelSize";
            subsequentLevelSize.Size = new Size(81, 23);
            subsequentLevelSize.TabIndex = 12;
            // 
            // initialLevelSize
            // 
            initialLevelSize.Location = new Point(150, 14);
            initialLevelSize.Margin = new Padding(4, 3, 4, 3);
            initialLevelSize.Name = "initialLevelSize";
            initialLevelSize.Size = new Size(81, 23);
            initialLevelSize.TabIndex = 11;
            // 
            // autoReset
            // 
            autoReset.AutoSize = true;
            autoReset.CheckAlign = ContentAlignment.MiddleRight;
            autoReset.Location = new Point(79, 160);
            autoReset.Margin = new Padding(4, 3, 4, 3);
            autoReset.Name = "autoReset";
            autoReset.Size = new Size(82, 19);
            autoReset.TabIndex = 10;
            autoReset.Text = "Auto-reset";
            autoReset.UseVisualStyleBackColor = true;
            // 
            // randomiseSize
            // 
            randomiseSize.AutoSize = true;
            randomiseSize.CheckAlign = ContentAlignment.MiddleRight;
            randomiseSize.Location = new Point(49, 74);
            randomiseSize.Margin = new Padding(4, 3, 4, 3);
            randomiseSize.Name = "randomiseSize";
            randomiseSize.Size = new Size(107, 19);
            randomiseSize.TabIndex = 9;
            randomiseSize.Text = "Randomise size";
            randomiseSize.UseVisualStyleBackColor = true;
            // 
            // secondsLabel
            // 
            secondsLabel.AutoSize = true;
            secondsLabel.Location = new Point(373, 250);
            secondsLabel.Margin = new Padding(4, 0, 4, 0);
            secondsLabel.Name = "secondsLabel";
            secondsLabel.Size = new Size(50, 15);
            secondsLabel.TabIndex = 8;
            secondsLabel.Text = "seconds";
            // 
            // initialPositionLabel
            // 
            initialPositionLabel.AutoSize = true;
            initialPositionLabel.Location = new Point(62, 190);
            initialPositionLabel.Margin = new Padding(4, 0, 4, 0);
            initialPositionLabel.Name = "initialPositionLabel";
            initialPositionLabel.Size = new Size(82, 15);
            initialPositionLabel.TabIndex = 7;
            initialPositionLabel.Text = "Initial position";
            // 
            // initialFillQuantityLabel
            // 
            initialFillQuantityLabel.AutoSize = true;
            initialFillQuantityLabel.Location = new Point(47, 220);
            initialFillQuantityLabel.Margin = new Padding(4, 0, 4, 0);
            initialFillQuantityLabel.Name = "initialFillQuantityLabel";
            initialFillQuantityLabel.Size = new Size(99, 15);
            initialFillQuantityLabel.TabIndex = 6;
            initialFillQuantityLabel.Text = "Initial fill quantity";
            // 
            // everyLabel
            // 
            everyLabel.AutoSize = true;
            everyLabel.Location = new Point(239, 250);
            everyLabel.Margin = new Padding(4, 0, 4, 0);
            everyLabel.Name = "everyLabel";
            everyLabel.Size = new Size(35, 15);
            everyLabel.TabIndex = 5;
            everyLabel.Text = "every";
            // 
            // priceAdjustValueLabel
            // 
            priceAdjustValueLabel.AutoSize = true;
            priceAdjustValueLabel.Location = new Point(37, 250);
            priceAdjustValueLabel.Margin = new Padding(4, 0, 4, 0);
            priceAdjustValueLabel.Name = "priceAdjustValueLabel";
            priceAdjustValueLabel.Size = new Size(99, 15);
            priceAdjustValueLabel.TabIndex = 4;
            priceAdjustValueLabel.Text = "Price adjust value";
            // 
            // subsequentLevelSizeLabel
            // 
            subsequentLevelSizeLabel.AutoSize = true;
            subsequentLevelSizeLabel.Location = new Point(15, 47);
            subsequentLevelSizeLabel.Margin = new Padding(4, 0, 4, 0);
            subsequentLevelSizeLabel.Name = "subsequentLevelSizeLabel";
            subsequentLevelSizeLabel.Size = new Size(118, 15);
            subsequentLevelSizeLabel.TabIndex = 3;
            subsequentLevelSizeLabel.Text = "Subsequent level size";
            // 
            // profitOffsetLabel
            // 
            profitOffsetLabel.AutoSize = true;
            profitOffsetLabel.Location = new Point(71, 134);
            profitOffsetLabel.Margin = new Padding(4, 0, 4, 0);
            profitOffsetLabel.Name = "profitOffsetLabel";
            profitOffsetLabel.Size = new Size(71, 15);
            profitOffsetLabel.TabIndex = 2;
            profitOffsetLabel.Text = "Profit Offset";
            // 
            // priceIncrementLabel
            // 
            priceIncrementLabel.AutoSize = true;
            priceIncrementLabel.Location = new Point(50, 104);
            priceIncrementLabel.Margin = new Padding(4, 0, 4, 0);
            priceIncrementLabel.Name = "priceIncrementLabel";
            priceIncrementLabel.Size = new Size(90, 15);
            priceIncrementLabel.TabIndex = 1;
            priceIncrementLabel.Text = "Price increment";
            // 
            // initialLevelSizeLabel
            // 
            initialLevelSizeLabel.AutoSize = true;
            initialLevelSizeLabel.Location = new Point(54, 22);
            initialLevelSizeLabel.Margin = new Padding(4, 0, 4, 0);
            initialLevelSizeLabel.Name = "initialLevelSizeLabel";
            initialLevelSizeLabel.Size = new Size(85, 15);
            initialLevelSizeLabel.TabIndex = 0;
            initialLevelSizeLabel.Text = "Initial level size";
            // 
            // algoTab
            // 
            algoTab.BackColor = Color.LightGray;
            algoTab.Controls.Add(useOddLots);
            algoTab.Controls.Add(noTradeAhead);
            algoTab.Controls.Add(getDone);
            algoTab.Controls.Add(displaySizeAlgo);
            algoTab.Controls.Add(forceCompletion);
            algoTab.Controls.Add(riskAversion);
            algoTab.Controls.Add(noTakeLiq);
            algoTab.Controls.Add(strategyType);
            algoTab.Controls.Add(pctVol);
            algoTab.Controls.Add(maxPctVol);
            algoTab.Controls.Add(allowPastEndTime);
            algoTab.Controls.Add(endTime);
            algoTab.Controls.Add(startTime);
            algoTab.Controls.Add(useOddLotsLabel);
            algoTab.Controls.Add(noTradeAheadLabel);
            algoTab.Controls.Add(getDoneLabel);
            algoTab.Controls.Add(displaySizeAlgoLabel);
            algoTab.Controls.Add(forceCompletionLabel);
            algoTab.Controls.Add(riskAversionLabel);
            algoTab.Controls.Add(noTakeLiqLabel);
            algoTab.Controls.Add(strategyTypeLabel);
            algoTab.Controls.Add(pctVolLabel);
            algoTab.Controls.Add(maxPctVolLabel);
            algoTab.Controls.Add(allowPastEndTimeLabel);
            algoTab.Controls.Add(endTimeLabel);
            algoTab.Controls.Add(startTimeLabel);
            algoTab.Controls.Add(algoStrategy);
            algoTab.Controls.Add(algoStrategyLabel);
            algoTab.Location = new Point(4, 24);
            algoTab.Margin = new Padding(4, 3, 4, 3);
            algoTab.Name = "algoTab";
            algoTab.Padding = new Padding(4, 3, 4, 3);
            algoTab.Size = new Size(865, 443);
            algoTab.TabIndex = 5;
            algoTab.Text = "IB Algo";
            // 
            // useOddLots
            // 
            useOddLots.Enabled = false;
            useOddLots.Location = new Point(376, 202);
            useOddLots.Margin = new Padding(4, 3, 4, 3);
            useOddLots.Name = "useOddLots";
            useOddLots.Size = new Size(81, 23);
            useOddLots.TabIndex = 27;
            // 
            // noTradeAhead
            // 
            noTradeAhead.Enabled = false;
            noTradeAhead.Location = new Point(376, 172);
            noTradeAhead.Margin = new Padding(4, 3, 4, 3);
            noTradeAhead.Name = "noTradeAhead";
            noTradeAhead.Size = new Size(81, 23);
            noTradeAhead.TabIndex = 26;
            // 
            // getDone
            // 
            getDone.Enabled = false;
            getDone.Location = new Point(376, 142);
            getDone.Margin = new Padding(4, 3, 4, 3);
            getDone.Name = "getDone";
            getDone.Size = new Size(81, 23);
            getDone.TabIndex = 25;
            // 
            // displaySizeAlgo
            // 
            displaySizeAlgo.Enabled = false;
            displaySizeAlgo.Location = new Point(376, 112);
            displaySizeAlgo.Margin = new Padding(4, 3, 4, 3);
            displaySizeAlgo.Name = "displaySizeAlgo";
            displaySizeAlgo.Size = new Size(81, 23);
            displaySizeAlgo.TabIndex = 24;
            // 
            // forceCompletion
            // 
            forceCompletion.Enabled = false;
            forceCompletion.Location = new Point(376, 82);
            forceCompletion.Margin = new Padding(4, 3, 4, 3);
            forceCompletion.Name = "forceCompletion";
            forceCompletion.Size = new Size(81, 23);
            forceCompletion.TabIndex = 23;
            // 
            // riskAversion
            // 
            riskAversion.Enabled = false;
            riskAversion.Location = new Point(376, 52);
            riskAversion.Margin = new Padding(4, 3, 4, 3);
            riskAversion.Name = "riskAversion";
            riskAversion.Size = new Size(81, 23);
            riskAversion.TabIndex = 22;
            // 
            // noTakeLiq
            // 
            noTakeLiq.Enabled = false;
            noTakeLiq.Location = new Point(376, 22);
            noTakeLiq.Margin = new Padding(4, 3, 4, 3);
            noTakeLiq.Name = "noTakeLiq";
            noTakeLiq.Size = new Size(81, 23);
            noTakeLiq.TabIndex = 21;
            // 
            // strategyType
            // 
            strategyType.Enabled = false;
            strategyType.Location = new Point(146, 202);
            strategyType.Margin = new Padding(4, 3, 4, 3);
            strategyType.Name = "strategyType";
            strategyType.Size = new Size(81, 23);
            strategyType.TabIndex = 20;
            // 
            // pctVol
            // 
            pctVol.Enabled = false;
            pctVol.Location = new Point(146, 172);
            pctVol.Margin = new Padding(4, 3, 4, 3);
            pctVol.Name = "pctVol";
            pctVol.Size = new Size(81, 23);
            pctVol.TabIndex = 19;
            // 
            // maxPctVol
            // 
            maxPctVol.Enabled = false;
            maxPctVol.Location = new Point(146, 142);
            maxPctVol.Margin = new Padding(4, 3, 4, 3);
            maxPctVol.Name = "maxPctVol";
            maxPctVol.Size = new Size(81, 23);
            maxPctVol.TabIndex = 18;
            // 
            // allowPastEndTime
            // 
            allowPastEndTime.Enabled = false;
            allowPastEndTime.Location = new Point(146, 112);
            allowPastEndTime.Margin = new Padding(4, 3, 4, 3);
            allowPastEndTime.Name = "allowPastEndTime";
            allowPastEndTime.Size = new Size(81, 23);
            allowPastEndTime.TabIndex = 17;
            // 
            // endTime
            // 
            endTime.Enabled = false;
            endTime.Location = new Point(146, 82);
            endTime.Margin = new Padding(4, 3, 4, 3);
            endTime.Name = "endTime";
            endTime.Size = new Size(81, 23);
            endTime.TabIndex = 16;
            // 
            // startTime
            // 
            startTime.Enabled = false;
            startTime.Location = new Point(146, 52);
            startTime.Margin = new Padding(4, 3, 4, 3);
            startTime.Name = "startTime";
            startTime.Size = new Size(81, 23);
            startTime.TabIndex = 15;
            // 
            // useOddLotsLabel
            // 
            useOddLotsLabel.AutoSize = true;
            useOddLotsLabel.Location = new Point(292, 202);
            useOddLotsLabel.Margin = new Padding(4, 0, 4, 0);
            useOddLotsLabel.Name = "useOddLotsLabel";
            useOddLotsLabel.Size = new Size(72, 15);
            useOddLotsLabel.TabIndex = 14;
            useOddLotsLabel.Text = "Use odd lots";
            // 
            // noTradeAheadLabel
            // 
            noTradeAheadLabel.AutoSize = true;
            noTradeAheadLabel.Location = new Point(274, 172);
            noTradeAheadLabel.Margin = new Padding(4, 0, 4, 0);
            noTradeAheadLabel.Name = "noTradeAheadLabel";
            noTradeAheadLabel.Size = new Size(88, 15);
            noTradeAheadLabel.TabIndex = 13;
            noTradeAheadLabel.Text = "No trade ahead";
            // 
            // getDoneLabel
            // 
            getDoneLabel.AutoSize = true;
            getDoneLabel.Location = new Point(309, 142);
            getDoneLabel.Margin = new Padding(4, 0, 4, 0);
            getDoneLabel.Name = "getDoneLabel";
            getDoneLabel.Size = new Size(55, 15);
            getDoneLabel.TabIndex = 12;
            getDoneLabel.Text = "Get done";
            // 
            // displaySizeAlgoLabel
            // 
            displaySizeAlgoLabel.AutoSize = true;
            displaySizeAlgoLabel.Location = new Point(296, 112);
            displaySizeAlgoLabel.Margin = new Padding(4, 0, 4, 0);
            displaySizeAlgoLabel.Name = "displaySizeAlgoLabel";
            displaySizeAlgoLabel.Size = new Size(67, 15);
            displaySizeAlgoLabel.TabIndex = 11;
            displaySizeAlgoLabel.Text = "Display size";
            // 
            // forceCompletionLabel
            // 
            forceCompletionLabel.AutoSize = true;
            forceCompletionLabel.Location = new Point(266, 82);
            forceCompletionLabel.Margin = new Padding(4, 0, 4, 0);
            forceCompletionLabel.Name = "forceCompletionLabel";
            forceCompletionLabel.Size = new Size(100, 15);
            forceCompletionLabel.TabIndex = 10;
            forceCompletionLabel.Text = "Force completion";
            // 
            // riskAversionLabel
            // 
            riskAversionLabel.AutoSize = true;
            riskAversionLabel.Location = new Point(286, 52);
            riskAversionLabel.Margin = new Padding(4, 0, 4, 0);
            riskAversionLabel.Name = "riskAversionLabel";
            riskAversionLabel.Size = new Size(75, 15);
            riskAversionLabel.TabIndex = 9;
            riskAversionLabel.Text = "Risk aversion";
            // 
            // noTakeLiqLabel
            // 
            noTakeLiqLabel.AutoSize = true;
            noTakeLiqLabel.Location = new Point(298, 21);
            noTakeLiqLabel.Margin = new Padding(4, 0, 4, 0);
            noTakeLiqLabel.Name = "noTakeLiqLabel";
            noTakeLiqLabel.Size = new Size(67, 15);
            noTakeLiqLabel.TabIndex = 8;
            noTakeLiqLabel.Text = "No take liq.";
            // 
            // strategyTypeLabel
            // 
            strategyTypeLabel.AutoSize = true;
            strategyTypeLabel.Location = new Point(42, 202);
            strategyTypeLabel.Margin = new Padding(4, 0, 4, 0);
            strategyTypeLabel.Name = "strategyTypeLabel";
            strategyTypeLabel.Size = new Size(76, 15);
            strategyTypeLabel.TabIndex = 7;
            strategyTypeLabel.Text = "Strategy type";
            // 
            // pctVolLabel
            // 
            pctVolLabel.AutoSize = true;
            pctVolLabel.Location = new Point(69, 172);
            pctVolLabel.Margin = new Padding(4, 0, 4, 0);
            pctVolLabel.Name = "pctVolLabel";
            pctVolLabel.Size = new Size(49, 15);
            pctVolLabel.TabIndex = 6;
            pctVolLabel.Text = "Pct. vol.";
            // 
            // maxPctVolLabel
            // 
            maxPctVolLabel.AutoSize = true;
            maxPctVolLabel.Location = new Point(41, 142);
            maxPctVolLabel.Margin = new Padding(4, 0, 4, 0);
            maxPctVolLabel.Name = "maxPctVolLabel";
            maxPctVolLabel.Size = new Size(75, 15);
            maxPctVolLabel.TabIndex = 5;
            maxPctVolLabel.Text = "Max Pct. Vol.";
            // 
            // allowPastEndTimeLabel
            // 
            allowPastEndTimeLabel.AutoSize = true;
            allowPastEndTimeLabel.Location = new Point(8, 112);
            allowPastEndTimeLabel.Margin = new Padding(4, 0, 4, 0);
            allowPastEndTimeLabel.Name = "allowPastEndTimeLabel";
            allowPastEndTimeLabel.Size = new Size(112, 15);
            allowPastEndTimeLabel.TabIndex = 4;
            allowPastEndTimeLabel.Text = "Allow past end time";
            // 
            // endTimeLabel
            // 
            endTimeLabel.AutoSize = true;
            endTimeLabel.Location = new Point(66, 82);
            endTimeLabel.Margin = new Padding(4, 0, 4, 0);
            endTimeLabel.Name = "endTimeLabel";
            endTimeLabel.Size = new Size(54, 15);
            endTimeLabel.TabIndex = 3;
            endTimeLabel.Text = "End time";
            // 
            // startTimeLabel
            // 
            startTimeLabel.AutoSize = true;
            startTimeLabel.Location = new Point(63, 52);
            startTimeLabel.Margin = new Padding(4, 0, 4, 0);
            startTimeLabel.Name = "startTimeLabel";
            startTimeLabel.Size = new Size(58, 15);
            startTimeLabel.TabIndex = 2;
            startTimeLabel.Text = "Start time";
            // 
            // algoStrategy
            // 
            algoStrategy.FormattingEnabled = true;
            algoStrategy.Items.AddRange(new object[] { "None", "Vwap", "Twap", "ArrivalPx", "DarkIce", "PctVol" });
            algoStrategy.Location = new Point(146, 21);
            algoStrategy.Margin = new Padding(4, 3, 4, 3);
            algoStrategy.Name = "algoStrategy";
            algoStrategy.Size = new Size(81, 23);
            algoStrategy.TabIndex = 1;
            algoStrategy.Text = "None";
            algoStrategy.SelectedIndexChanged += AlgoStrategy_SelectedIndexChanged;
            // 
            // algoStrategyLabel
            // 
            algoStrategyLabel.AutoSize = true;
            algoStrategyLabel.Location = new Point(43, 21);
            algoStrategyLabel.Margin = new Padding(4, 0, 4, 0);
            algoStrategyLabel.Name = "algoStrategyLabel";
            algoStrategyLabel.Size = new Size(77, 15);
            algoStrategyLabel.TabIndex = 0;
            algoStrategyLabel.Text = "Algo strategy";
            // 
            // peg2benchTab
            // 
            peg2benchTab.BackColor = Color.LightGray;
            peg2benchTab.Controls.Add(pgdStockRangeLower);
            peg2benchTab.Controls.Add(pgdStockRangeUpper);
            peg2benchTab.Controls.Add(label20);
            peg2benchTab.Controls.Add(label21);
            peg2benchTab.Controls.Add(cbPeggedChangeType);
            peg2benchTab.Controls.Add(tbReferenceChangeAmount);
            peg2benchTab.Controls.Add(tbPeggedChangeAmount);
            peg2benchTab.Controls.Add(tbStartingReferencePrice);
            peg2benchTab.Controls.Add(label10);
            peg2benchTab.Controls.Add(label9);
            peg2benchTab.Controls.Add(label8);
            peg2benchTab.Controls.Add(label7);
            peg2benchTab.Controls.Add(label6);
            peg2benchTab.Controls.Add(tbStartingPrice);
            peg2benchTab.Controls.Add(label4);
            peg2benchTab.Location = new Point(4, 24);
            peg2benchTab.Margin = new Padding(4, 3, 4, 3);
            peg2benchTab.Name = "peg2benchTab";
            peg2benchTab.Size = new Size(865, 443);
            peg2benchTab.TabIndex = 6;
            peg2benchTab.Text = "Pegged to Benchmark";
            // 
            // pgdStockRangeLower
            // 
            pgdStockRangeLower.Location = new Point(174, 213);
            pgdStockRangeLower.Margin = new Padding(4, 3, 4, 3);
            pgdStockRangeLower.Name = "pgdStockRangeLower";
            pgdStockRangeLower.Size = new Size(240, 23);
            pgdStockRangeLower.TabIndex = 20;
            // 
            // pgdStockRangeUpper
            // 
            pgdStockRangeUpper.Location = new Point(174, 183);
            pgdStockRangeUpper.Margin = new Padding(4, 3, 4, 3);
            pgdStockRangeUpper.Name = "pgdStockRangeUpper";
            pgdStockRangeUpper.Size = new Size(240, 23);
            pgdStockRangeUpper.TabIndex = 19;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(8, 217);
            label20.Margin = new Padding(4, 0, 4, 0);
            label20.Name = "label20";
            label20.Size = new Size(109, 15);
            label20.TabIndex = 18;
            label20.Text = "Stock range - lower";
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(8, 187);
            label21.Margin = new Padding(4, 0, 4, 0);
            label21.Name = "label21";
            label21.Size = new Size(111, 15);
            label21.TabIndex = 17;
            label21.Text = "Stock range - upper";
            // 
            // cbPeggedChangeType
            // 
            cbPeggedChangeType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbPeggedChangeType.FormattingEnabled = true;
            cbPeggedChangeType.Items.AddRange(new object[] { "Increase", "Decrease" });
            cbPeggedChangeType.Location = new Point(174, 123);
            cbPeggedChangeType.Margin = new Padding(4, 3, 4, 3);
            cbPeggedChangeType.Name = "cbPeggedChangeType";
            cbPeggedChangeType.Size = new Size(242, 23);
            cbPeggedChangeType.TabIndex = 10;
            // 
            // tbReferenceChangeAmount
            // 
            tbReferenceChangeAmount.Location = new Point(174, 153);
            tbReferenceChangeAmount.Margin = new Padding(4, 3, 4, 3);
            tbReferenceChangeAmount.Name = "tbReferenceChangeAmount";
            tbReferenceChangeAmount.Size = new Size(242, 23);
            tbReferenceChangeAmount.TabIndex = 9;
            // 
            // tbPeggedChangeAmount
            // 
            tbPeggedChangeAmount.Location = new Point(174, 93);
            tbPeggedChangeAmount.Margin = new Padding(4, 3, 4, 3);
            tbPeggedChangeAmount.Name = "tbPeggedChangeAmount";
            tbPeggedChangeAmount.Size = new Size(242, 23);
            tbPeggedChangeAmount.TabIndex = 8;
            // 
            // tbStartingReferencePrice
            // 
            tbStartingReferencePrice.Location = new Point(174, 63);
            tbStartingReferencePrice.Margin = new Padding(4, 3, 4, 3);
            tbStartingReferencePrice.Name = "tbStartingReferencePrice";
            tbStartingReferencePrice.Size = new Size(242, 23);
            tbStartingReferencePrice.TabIndex = 7;
            // 
            // label10
            // 
            label10.AccessibleRole = AccessibleRole.Grip;
            label10.AutoSize = true;
            label10.Location = new Point(8, 157);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(146, 15);
            label10.TabIndex = 6;
            label10.Text = "Reference change amount";
            // 
            // label9
            // 
            label9.AccessibleRole = AccessibleRole.Grip;
            label9.AutoSize = true;
            label9.Location = new Point(8, 127);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(115, 15);
            label9.TabIndex = 5;
            label9.Text = "Pegged change type";
            // 
            // label8
            // 
            label8.AccessibleRole = AccessibleRole.Grip;
            label8.AutoSize = true;
            label8.Location = new Point(8, 97);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(134, 15);
            label8.TabIndex = 4;
            label8.Text = "Pegged change amount";
            // 
            // label7
            // 
            label7.AccessibleRole = AccessibleRole.Grip;
            label7.AutoSize = true;
            label7.Location = new Point(8, 67);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(129, 15);
            label7.TabIndex = 3;
            label7.Text = "Starting reference price";
            // 
            // label6
            // 
            label6.AccessibleRole = AccessibleRole.Grip;
            label6.AutoSize = true;
            label6.Location = new Point(8, 37);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(106, 15);
            label6.TabIndex = 2;
            label6.Text = "Reference contract";
            // 
            // tbStartingPrice
            // 
            tbStartingPrice.Location = new Point(174, 3);
            tbStartingPrice.Margin = new Padding(4, 3, 4, 3);
            tbStartingPrice.Name = "tbStartingPrice";
            tbStartingPrice.Size = new Size(242, 23);
            tbStartingPrice.TabIndex = 1;
            // 
            // label4
            // 
            label4.AccessibleRole = AccessibleRole.Grip;
            label4.AutoSize = true;
            label4.Location = new Point(8, 7);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 0;
            label4.Text = "Starting price";
            // 
            // adjustStopTab
            // 
            adjustStopTab.BackColor = Color.LightGray;
            adjustStopTab.Controls.Add(label16);
            adjustStopTab.Controls.Add(cbAdjustedTrailingAmntUnit);
            adjustStopTab.Controls.Add(tbAdjustedTrailingAmnt);
            adjustStopTab.Controls.Add(label15);
            adjustStopTab.Controls.Add(tbAdjustedStopLimitPrice);
            adjustStopTab.Controls.Add(label14);
            adjustStopTab.Controls.Add(tbAdjustedStopPrice);
            adjustStopTab.Controls.Add(label13);
            adjustStopTab.Controls.Add(tbTriggerPrice);
            adjustStopTab.Controls.Add(label12);
            adjustStopTab.Controls.Add(cbAdjustedOrderType);
            adjustStopTab.Controls.Add(label11);
            adjustStopTab.Location = new Point(4, 24);
            adjustStopTab.Margin = new Padding(4, 3, 4, 3);
            adjustStopTab.Name = "adjustStopTab";
            adjustStopTab.Size = new Size(865, 443);
            adjustStopTab.TabIndex = 7;
            adjustStopTab.Text = "Adjustable stops";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(16, 158);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(163, 15);
            label16.TabIndex = 11;
            label16.Text = "Adjusted trailing amount unit";
            // 
            // cbAdjustedTrailingAmntUnit
            // 
            cbAdjustedTrailingAmntUnit.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAdjustedTrailingAmntUnit.FormattingEnabled = true;
            cbAdjustedTrailingAmntUnit.Items.AddRange(new object[] { "amonunt", "%" });
            cbAdjustedTrailingAmntUnit.Location = new Point(190, 155);
            cbAdjustedTrailingAmntUnit.Margin = new Padding(4, 3, 4, 3);
            cbAdjustedTrailingAmntUnit.Name = "cbAdjustedTrailingAmntUnit";
            cbAdjustedTrailingAmntUnit.Size = new Size(140, 23);
            cbAdjustedTrailingAmntUnit.TabIndex = 7;
            // 
            // tbAdjustedTrailingAmnt
            // 
            tbAdjustedTrailingAmnt.Location = new Point(190, 125);
            tbAdjustedTrailingAmnt.Margin = new Padding(4, 3, 4, 3);
            tbAdjustedTrailingAmnt.Name = "tbAdjustedTrailingAmnt";
            tbAdjustedTrailingAmnt.Size = new Size(140, 23);
            tbAdjustedTrailingAmnt.TabIndex = 6;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(16, 128);
            label15.Margin = new Padding(4, 0, 4, 0);
            label15.Name = "label15";
            label15.Size = new Size(139, 15);
            label15.TabIndex = 8;
            label15.Text = "Adjusted trailing amount";
            // 
            // tbAdjustedStopLimitPrice
            // 
            tbAdjustedStopLimitPrice.Location = new Point(190, 95);
            tbAdjustedStopLimitPrice.Margin = new Padding(4, 3, 4, 3);
            tbAdjustedStopLimitPrice.Name = "tbAdjustedStopLimitPrice";
            tbAdjustedStopLimitPrice.Size = new Size(140, 23);
            tbAdjustedStopLimitPrice.TabIndex = 5;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(16, 98);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(133, 15);
            label14.TabIndex = 6;
            label14.Text = "Adusted stop limit price";
            // 
            // tbAdjustedStopPrice
            // 
            tbAdjustedStopPrice.Location = new Point(190, 65);
            tbAdjustedStopPrice.Margin = new Padding(4, 3, 4, 3);
            tbAdjustedStopPrice.Name = "tbAdjustedStopPrice";
            tbAdjustedStopPrice.Size = new Size(140, 23);
            tbAdjustedStopPrice.TabIndex = 4;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(16, 68);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(109, 15);
            label13.TabIndex = 4;
            label13.Text = "Adjusted stop price";
            // 
            // tbTriggerPrice
            // 
            tbTriggerPrice.Location = new Point(190, 35);
            tbTriggerPrice.Margin = new Padding(4, 3, 4, 3);
            tbTriggerPrice.Name = "tbTriggerPrice";
            tbTriggerPrice.Size = new Size(140, 23);
            tbTriggerPrice.TabIndex = 3;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(16, 7);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(112, 15);
            label12.TabIndex = 2;
            label12.Text = "Adjust to order type";
            // 
            // cbAdjustedOrderType
            // 
            cbAdjustedOrderType.DropDownStyle = ComboBoxStyle.DropDownList;
            cbAdjustedOrderType.FormattingEnabled = true;
            cbAdjustedOrderType.Items.AddRange(new object[] { "", "STP", "STP LMT", "TRAIL", "TRAIL LIMIT" });
            cbAdjustedOrderType.Location = new Point(190, 3);
            cbAdjustedOrderType.Margin = new Padding(4, 3, 4, 3);
            cbAdjustedOrderType.Name = "cbAdjustedOrderType";
            cbAdjustedOrderType.Size = new Size(140, 23);
            cbAdjustedOrderType.TabIndex = 2;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(16, 38);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(72, 15);
            label11.TabIndex = 0;
            label11.Text = "Trigger price";
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightGray;
            tabPage1.Controls.Add(ignoreRth);
            tabPage1.Controls.Add(cancelOrder);
            tabPage1.Controls.Add(conditionList);
            tabPage1.Controls.Add(lbAddCondition);
            tabPage1.Controls.Add(lbRemoveCondition);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Size = new Size(865, 443);
            tabPage1.TabIndex = 8;
            tabPage1.Text = "Conditions";
            // 
            // ignoreRth
            // 
            ignoreRth.AutoSize = true;
            ignoreRth.Location = new Point(156, 338);
            ignoreRth.Margin = new Padding(4, 3, 4, 3);
            ignoreRth.Name = "ignoreRth";
            ignoreRth.Size = new Size(454, 19);
            ignoreRth.TabIndex = 13;
            ignoreRth.Text = "Allow condition to be satisfied and activate order outside of regular trading hours";
            ignoreRth.UseVisualStyleBackColor = true;
            // 
            // cancelOrder
            // 
            cancelOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            cancelOrder.FormattingEnabled = true;
            cancelOrder.Items.AddRange(new object[] { "Submit order", "Cancel order" });
            cancelOrder.Location = new Point(8, 333);
            cancelOrder.Margin = new Padding(4, 3, 4, 3);
            cancelOrder.Name = "cancelOrder";
            cancelOrder.Size = new Size(140, 23);
            cancelOrder.TabIndex = 4;
            // 
            // conditionList
            // 
            conditionList.AllowUserToAddRows = false;
            conditionList.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.DisplayedCells;
            conditionList.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            conditionList.Columns.AddRange(new DataGridViewColumn[] { Description, Logic });
            conditionList.Dock = DockStyle.Top;
            conditionList.Location = new Point(0, 0);
            conditionList.Margin = new Padding(4, 3, 4, 3);
            conditionList.Name = "conditionList";
            conditionList.Size = new Size(865, 327);
            conditionList.TabIndex = 3;
            conditionList.CellDoubleClick += conditionList_CellDoubleClick;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.Name = "Description";
            Description.ReadOnly = true;
            Description.Width = 92;
            // 
            // Logic
            // 
            Logic.HeaderText = "Logic";
            Logic.Items.AddRange(new object[] { "and", "or" });
            Logic.Name = "Logic";
            Logic.Width = 42;
            // 
            // lbAddCondition
            // 
            lbAddCondition.AutoSize = true;
            lbAddCondition.Location = new Point(632, 339);
            lbAddCondition.Margin = new Padding(4, 0, 4, 0);
            lbAddCondition.Name = "lbAddCondition";
            lbAddCondition.Size = new Size(27, 15);
            lbAddCondition.TabIndex = 1;
            lbAddCondition.TabStop = true;
            lbAddCondition.Text = "add";
            lbAddCondition.LinkClicked += lbAddCondition_LinkClicked;
            // 
            // lbRemoveCondition
            // 
            lbRemoveCondition.AutoSize = true;
            lbRemoveCondition.Location = new Point(668, 339);
            lbRemoveCondition.Margin = new Padding(4, 0, 4, 0);
            lbRemoveCondition.Name = "lbRemoveCondition";
            lbRemoveCondition.Size = new Size(47, 15);
            lbRemoveCondition.TabIndex = 2;
            lbRemoveCondition.TabStop = true;
            lbRemoveCondition.Text = "remove";
            lbRemoveCondition.LinkClicked += lbRemoveCondition_LinkClicked;
            // 
            // PegBestPegMidTab
            // 
            PegBestPegMidTab.BackColor = Color.LightGray;
            PegBestPegMidTab.Controls.Add(tbMidOffsetAtHalf);
            PegBestPegMidTab.Controls.Add(labelMidOffsetAtHalf);
            PegBestPegMidTab.Controls.Add(tbMidOffsetAtWhole);
            PegBestPegMidTab.Controls.Add(labelMidOffsetAtWhole);
            PegBestPegMidTab.Controls.Add(cbCompeteAgainstBestOffsetUpToMid);
            PegBestPegMidTab.Controls.Add(tbCompeteAgainstBestOffset);
            PegBestPegMidTab.Controls.Add(labelCompeteAgainstBestOffset);
            PegBestPegMidTab.Controls.Add(tbMinCompeteSize);
            PegBestPegMidTab.Controls.Add(labelMinCompeteSize);
            PegBestPegMidTab.Controls.Add(tbMinTradeQty);
            PegBestPegMidTab.Controls.Add(labelMinTradeQty);
            PegBestPegMidTab.Location = new Point(4, 24);
            PegBestPegMidTab.Margin = new Padding(4, 3, 4, 3);
            PegBestPegMidTab.Name = "PegBestPegMidTab";
            PegBestPegMidTab.Size = new Size(865, 443);
            PegBestPegMidTab.TabIndex = 9;
            PegBestPegMidTab.Text = "PegBest / PegMid";
            // 
            // tbMidOffsetAtHalf
            // 
            tbMidOffsetAtHalf.Location = new Point(174, 171);
            tbMidOffsetAtHalf.Margin = new Padding(4, 3, 4, 3);
            tbMidOffsetAtHalf.Name = "tbMidOffsetAtHalf";
            tbMidOffsetAtHalf.Size = new Size(242, 23);
            tbMidOffsetAtHalf.TabIndex = 14;
            // 
            // labelMidOffsetAtHalf
            // 
            labelMidOffsetAtHalf.AccessibleRole = AccessibleRole.Grip;
            labelMidOffsetAtHalf.AutoSize = true;
            labelMidOffsetAtHalf.Location = new Point(8, 174);
            labelMidOffsetAtHalf.Margin = new Padding(4, 0, 4, 0);
            labelMidOffsetAtHalf.Name = "labelMidOffsetAtHalf";
            labelMidOffsetAtHalf.Size = new Size(103, 15);
            labelMidOffsetAtHalf.TabIndex = 13;
            labelMidOffsetAtHalf.Text = "Mid Offset At Half";
            // 
            // tbMidOffsetAtWhole
            // 
            tbMidOffsetAtWhole.Location = new Point(174, 141);
            tbMidOffsetAtWhole.Margin = new Padding(4, 3, 4, 3);
            tbMidOffsetAtWhole.Name = "tbMidOffsetAtWhole";
            tbMidOffsetAtWhole.Size = new Size(242, 23);
            tbMidOffsetAtWhole.TabIndex = 12;
            // 
            // labelMidOffsetAtWhole
            // 
            labelMidOffsetAtWhole.AccessibleRole = AccessibleRole.Grip;
            labelMidOffsetAtWhole.AutoSize = true;
            labelMidOffsetAtWhole.Location = new Point(8, 144);
            labelMidOffsetAtWhole.Margin = new Padding(4, 0, 4, 0);
            labelMidOffsetAtWhole.Name = "labelMidOffsetAtWhole";
            labelMidOffsetAtWhole.Size = new Size(115, 15);
            labelMidOffsetAtWhole.TabIndex = 11;
            labelMidOffsetAtWhole.Text = "Mid Offset At Whole";
            // 
            // cbCompeteAgainstBestOffsetUpToMid
            // 
            cbCompeteAgainstBestOffsetUpToMid.AutoSize = true;
            cbCompeteAgainstBestOffsetUpToMid.CheckAlign = ContentAlignment.MiddleRight;
            cbCompeteAgainstBestOffsetUpToMid.Location = new Point(12, 114);
            cbCompeteAgainstBestOffsetUpToMid.Margin = new Padding(4, 3, 4, 3);
            cbCompeteAgainstBestOffsetUpToMid.Name = "cbCompeteAgainstBestOffsetUpToMid";
            cbCompeteAgainstBestOffsetUpToMid.Size = new Size(235, 19);
            cbCompeteAgainstBestOffsetUpToMid.TabIndex = 10;
            cbCompeteAgainstBestOffsetUpToMid.Text = "Compete Against Best Offset Up To Mid";
            cbCompeteAgainstBestOffsetUpToMid.UseVisualStyleBackColor = true;
            cbCompeteAgainstBestOffsetUpToMid.CheckedChanged += cbCompeteAgainstBestOffsetUpToMid_CheckedChanged;
            // 
            // tbCompeteAgainstBestOffset
            // 
            tbCompeteAgainstBestOffset.Location = new Point(174, 78);
            tbCompeteAgainstBestOffset.Margin = new Padding(4, 3, 4, 3);
            tbCompeteAgainstBestOffset.Name = "tbCompeteAgainstBestOffset";
            tbCompeteAgainstBestOffset.Size = new Size(242, 23);
            tbCompeteAgainstBestOffset.TabIndex = 7;
            // 
            // labelCompeteAgainstBestOffset
            // 
            labelCompeteAgainstBestOffset.AccessibleRole = AccessibleRole.Grip;
            labelCompeteAgainstBestOffset.AutoSize = true;
            labelCompeteAgainstBestOffset.Location = new Point(8, 82);
            labelCompeteAgainstBestOffset.Margin = new Padding(4, 0, 4, 0);
            labelCompeteAgainstBestOffset.Name = "labelCompeteAgainstBestOffset";
            labelCompeteAgainstBestOffset.Size = new Size(159, 15);
            labelCompeteAgainstBestOffset.TabIndex = 6;
            labelCompeteAgainstBestOffset.Text = "Compete Against Best Offset";
            // 
            // tbMinCompeteSize
            // 
            tbMinCompeteSize.Location = new Point(174, 48);
            tbMinCompeteSize.Margin = new Padding(4, 3, 4, 3);
            tbMinCompeteSize.Name = "tbMinCompeteSize";
            tbMinCompeteSize.Size = new Size(242, 23);
            tbMinCompeteSize.TabIndex = 5;
            // 
            // labelMinCompeteSize
            // 
            labelMinCompeteSize.AccessibleRole = AccessibleRole.Grip;
            labelMinCompeteSize.AutoSize = true;
            labelMinCompeteSize.Location = new Point(8, 52);
            labelMinCompeteSize.Margin = new Padding(4, 0, 4, 0);
            labelMinCompeteSize.Name = "labelMinCompeteSize";
            labelMinCompeteSize.Size = new Size(103, 15);
            labelMinCompeteSize.TabIndex = 4;
            labelMinCompeteSize.Text = "Min Compete Size";
            // 
            // tbMinTradeQty
            // 
            tbMinTradeQty.Location = new Point(174, 18);
            tbMinTradeQty.Margin = new Padding(4, 3, 4, 3);
            tbMinTradeQty.Name = "tbMinTradeQty";
            tbMinTradeQty.Size = new Size(242, 23);
            tbMinTradeQty.TabIndex = 3;
            // 
            // labelMinTradeQty
            // 
            labelMinTradeQty.AccessibleRole = AccessibleRole.Grip;
            labelMinTradeQty.AutoSize = true;
            labelMinTradeQty.Location = new Point(8, 22);
            labelMinTradeQty.Margin = new Padding(4, 0, 4, 0);
            labelMinTradeQty.Name = "labelMinTradeQty";
            labelMinTradeQty.Size = new Size(81, 15);
            labelMinTradeQty.TabIndex = 2;
            labelMinTradeQty.Text = "Min Trade Qty";
            // 
            // contractSearchControl1
            // 
            contractSearchControl1.Contract = null;
            contractSearchControl1.IBClient = null;
            contractSearchControl1.Location = new Point(149, 32);
            contractSearchControl1.Name = "contractSearchControl1";
            contractSearchControl1.Size = new Size(206, 13);
            contractSearchControl1.TabIndex = 0;
            // 
            // sendOrderButton
            // 
            sendOrderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            sendOrderButton.Location = new Point(154, 490);
            sendOrderButton.Margin = new Padding(4, 3, 4, 3);
            sendOrderButton.Name = "sendOrderButton";
            sendOrderButton.Size = new Size(97, 27);
            sendOrderButton.TabIndex = 0;
            sendOrderButton.Text = "Place/Modify";
            sendOrderButton.UseVisualStyleBackColor = true;
            sendOrderButton.Click += sendOrderButton_Click;
            // 
            // textBox6
            // 
            textBox6.Location = new Point(447, 217);
            textBox6.Margin = new Padding(4, 3, 4, 3);
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(81, 23);
            textBox6.TabIndex = 0;
            textBox6.Text = "WARNING!!!";
            // 
            // textBox7
            // 
            textBox7.Location = new Point(447, 247);
            textBox7.Margin = new Padding(4, 3, 4, 3);
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(81, 23);
            textBox7.TabIndex = 1;
            textBox7.Text = "WARNING!!!";
            // 
            // textBox8
            // 
            textBox8.Location = new Point(447, 277);
            textBox8.Margin = new Padding(4, 3, 4, 3);
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(81, 23);
            textBox8.TabIndex = 2;
            textBox8.Text = "WARNING!!!";
            // 
            // checkMarginButton
            // 
            checkMarginButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            checkMarginButton.Location = new Point(357, 490);
            checkMarginButton.Margin = new Padding(4, 3, 4, 3);
            checkMarginButton.Name = "checkMarginButton";
            checkMarginButton.Size = new Size(102, 27);
            checkMarginButton.TabIndex = 1;
            checkMarginButton.Text = "Check Margin";
            checkMarginButton.UseVisualStyleBackColor = true;
            checkMarginButton.Click += checkMarginButton_Click;
            // 
            // closeOrderDialogButton
            // 
            closeOrderDialogButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            closeOrderDialogButton.Location = new Point(786, 490);
            closeOrderDialogButton.Margin = new Padding(4, 3, 4, 3);
            closeOrderDialogButton.Name = "closeOrderDialogButton";
            closeOrderDialogButton.Size = new Size(88, 27);
            closeOrderDialogButton.TabIndex = 2;
            closeOrderDialogButton.Text = "Close";
            closeOrderDialogButton.UseVisualStyleBackColor = true;
            closeOrderDialogButton.Click += closeOrderDialogButton_Click;
            // 
            // cancelOrderButton
            // 
            cancelOrderButton.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            cancelOrderButton.Location = new Point(258, 490);
            cancelOrderButton.Margin = new Padding(4, 3, 4, 3);
            cancelOrderButton.Name = "cancelOrderButton";
            cancelOrderButton.Size = new Size(97, 27);
            cancelOrderButton.TabIndex = 3;
            cancelOrderButton.Text = "Cancel";
            cancelOrderButton.UseVisualStyleBackColor = true;
            cancelOrderButton.Click += cancelOrderButton_Click;
            // 
            // OrderDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(888, 523);
            ControlBox = false;
            Controls.Add(cancelOrderButton);
            Controls.Add(closeOrderDialogButton);
            Controls.Add(checkMarginButton);
            Controls.Add(sendOrderButton);
            Controls.Add(conditionsTab);
            Controls.Add(textBox6);
            Controls.Add(textBox8);
            Controls.Add(textBox7);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "OrderDialog";
            Text = "Order";
            conditionsTab.ResumeLayout(false);
            orderContractTab.ResumeLayout(false);
            baseGroup.ResumeLayout(false);
            baseGroup.PerformLayout();
            contractGroup.ResumeLayout(false);
            contractGroup.PerformLayout();
            extendedOrderTab.ResumeLayout(false);
            extendedOrderTab.PerformLayout();
            advisorTab.ResumeLayout(false);
            advisorTab.PerformLayout();
            volatilityTab.ResumeLayout(false);
            volatilityTab.PerformLayout();
            scaleTab.ResumeLayout(false);
            scaleTab.PerformLayout();
            algoTab.ResumeLayout(false);
            algoTab.PerformLayout();
            peg2benchTab.ResumeLayout(false);
            peg2benchTab.PerformLayout();
            adjustStopTab.ResumeLayout(false);
            adjustStopTab.PerformLayout();
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)conditionList).EndInit();
            PegBestPegMidTab.ResumeLayout(false);
            PegBestPegMidTab.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion


        private System.Windows.Forms.TabControl conditionsTab;
        private System.Windows.Forms.TabPage orderContractTab;
        private System.Windows.Forms.TabPage extendedOrderTab;
        private System.Windows.Forms.Button sendOrderButton;

        private System.Windows.Forms.ComboBox contractSecType;
        private System.Windows.Forms.TextBox contractLastTradeDateOrContractMonth;
        private System.Windows.Forms.TextBox contractStrike;
        private System.Windows.Forms.ComboBox contractRight;
        private System.Windows.Forms.TextBox contractMultiplier;
        private System.Windows.Forms.TextBox contractExchange;
        private System.Windows.Forms.TextBox contractCurrency;
        private System.Windows.Forms.TextBox contractLocalSymbol;        
        private System.Windows.Forms.GroupBox contractGroup;
        private System.Windows.Forms.GroupBox baseGroup;
        private System.Windows.Forms.TextBox contractSymbol;
        private System.Windows.Forms.TextBox orderReference;        
        private System.Windows.Forms.CheckBox overrideConstraints;
        private System.Windows.Forms.CheckBox allOrNone;
        private System.Windows.Forms.CheckBox outsideRTH;
        private System.Windows.Forms.CheckBox hidden;
        private System.Windows.Forms.CheckBox sweepToFill;
        private System.Windows.Forms.CheckBox block;
        private System.Windows.Forms.CheckBox notHeld;
        private System.Windows.Forms.TextBox hedgeParam;
        private System.Windows.Forms.TextBox trailStopPrice;
        private System.Windows.Forms.TextBox percentOffset;
        private System.Windows.Forms.ComboBox hedgeType;
        private System.Windows.Forms.ComboBox triggerMethod;
        private System.Windows.Forms.ComboBox rule80A;
        private System.Windows.Forms.ComboBox ocaType;
        private System.Windows.Forms.TextBox goodUntil;
        private System.Windows.Forms.TextBox ocaGroup;
        private System.Windows.Forms.TextBox goodAfter;
        private System.Windows.Forms.TextBox minQty;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.CheckBox transmit;
        private System.Windows.Forms.CheckBox optOutSmart;
        private System.Windows.Forms.TextBox discretionaryAmount;
        private System.Windows.Forms.TextBox trailingPercent;

        private System.Windows.Forms.Label orderSymbolLabel;
        private System.Windows.Forms.Label orderSecTypeLabel;
        private System.Windows.Forms.Label orderLastTradeDateOrContractMonthLabel;
        private System.Windows.Forms.Label orderStrikeLabel;
        private System.Windows.Forms.Label orderRightLabel;
        private System.Windows.Forms.Label orderMultiplierLabel;
        private System.Windows.Forms.Label orderExchangeLabel;
        private System.Windows.Forms.Label orderCurrencyLabel;
        private System.Windows.Forms.Label orderLocalSymbol;
        private System.Windows.Forms.Label tiggerMethodLabel;
        private System.Windows.Forms.Label rule80ALabel;
        private System.Windows.Forms.Label goodUntilLabel;
        private System.Windows.Forms.Label goodAfterLabel;
        private System.Windows.Forms.Label orderMinQtyLabel;
        private System.Windows.Forms.Label orderRefLabel;
        private System.Windows.Forms.Label percentOffsetLabel;        
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label trailingPercentLabel;
        private System.Windows.Forms.Label accountLabel;
        private System.Windows.Forms.Label limitPriceLabel;
        private System.Windows.Forms.Label orderTypeLabel;
        private System.Windows.Forms.Label displaySizeLabel;
        private System.Windows.Forms.Label quantityLabel;
        private System.Windows.Forms.Label actionLabel;
        private System.Windows.Forms.Label auxPriceLabel;
        private System.Windows.Forms.ComboBox account;
        private System.Windows.Forms.Label timeInForceLabel;
        private System.Windows.Forms.ComboBox orderType;
        private System.Windows.Forms.TextBox displaySize;
        private System.Windows.Forms.TextBox quantity;
        private System.Windows.Forms.ComboBox action;
        private System.Windows.Forms.ComboBox timeInForce;
        private System.Windows.Forms.TextBox auxPrice;
        private System.Windows.Forms.TextBox lmtPrice;
        private System.Windows.Forms.TabPage advisorTab;
        private System.Windows.Forms.Label groupLabel;
        private System.Windows.Forms.Label profileLabel;
        private System.Windows.Forms.Label orLabel;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.Label methodLabel;
        private System.Windows.Forms.TextBox faGroup;
        private System.Windows.Forms.ComboBox faMethod;
        private System.Windows.Forms.TextBox faProfile;
        private System.Windows.Forms.TextBox faPercentage;
        private System.Windows.Forms.TabPage volatilityTab;
        private System.Windows.Forms.TabPage scaleTab;
        private System.Windows.Forms.TabPage algoTab;
        private System.Windows.Forms.Label stockRangeLowerLabel;
        private System.Windows.Forms.Label sockRangeUpperLabel;
        private System.Windows.Forms.Label hedgeContractConIdLabel;
        private System.Windows.Forms.Label hedgeOrderAuxPriceLabel;
        private System.Windows.Forms.Label hedgeOrderTypeLabel;
        private System.Windows.Forms.Label optionReferencePriceLabel;
        private System.Windows.Forms.Label volatilityLabel;
        private System.Windows.Forms.CheckBox continuousUpdate;
        private System.Windows.Forms.TextBox stockRangeLower;
        private System.Windows.Forms.TextBox stockRangeUpper;
        private System.Windows.Forms.TextBox deltaNeutralConId;
        private System.Windows.Forms.TextBox deltaNeutralAuxPrice;
        private System.Windows.Forms.ComboBox deltaNeutralOrderType;
        private System.Windows.Forms.ComboBox optionReferencePrice;
        private System.Windows.Forms.ComboBox volatilityType;
        private System.Windows.Forms.TextBox volatility;
        private System.Windows.Forms.Label secondsLabel;
        private System.Windows.Forms.Label initialPositionLabel;
        private System.Windows.Forms.Label initialFillQuantityLabel;
        private System.Windows.Forms.Label everyLabel;
        private System.Windows.Forms.Label priceAdjustValueLabel;
        private System.Windows.Forms.Label subsequentLevelSizeLabel;
        private System.Windows.Forms.Label profitOffsetLabel;
        private System.Windows.Forms.Label priceIncrementLabel;
        private System.Windows.Forms.Label initialLevelSizeLabel;
        private System.Windows.Forms.CheckBox autoReset;
        private System.Windows.Forms.CheckBox randomiseSize;
        private System.Windows.Forms.TextBox initialLevelSize;
        private System.Windows.Forms.TextBox priceAdjustInterval;
        private System.Windows.Forms.TextBox priceAdjustValue;
        private System.Windows.Forms.TextBox initialFillQuantity;
        private System.Windows.Forms.TextBox initialPosition;
        private System.Windows.Forms.TextBox priceIncrement;
        private System.Windows.Forms.TextBox profitOffset;
        private System.Windows.Forms.TextBox subsequentLevelSize;
        private System.Windows.Forms.Label algoStrategyLabel;
        private System.Windows.Forms.ComboBox algoStrategy;
        private System.Windows.Forms.Label useOddLotsLabel;
        private System.Windows.Forms.Label noTradeAheadLabel;
        private System.Windows.Forms.Label getDoneLabel;
        private System.Windows.Forms.Label displaySizeAlgoLabel;
        private System.Windows.Forms.Label forceCompletionLabel;
        private System.Windows.Forms.Label riskAversionLabel;
        private System.Windows.Forms.Label noTakeLiqLabel;
        private System.Windows.Forms.Label strategyTypeLabel;
        private System.Windows.Forms.Label pctVolLabel;
        private System.Windows.Forms.Label maxPctVolLabel;
        private System.Windows.Forms.Label allowPastEndTimeLabel;
        private System.Windows.Forms.Label endTimeLabel;
        private System.Windows.Forms.Label startTimeLabel;
        private System.Windows.Forms.TextBox useOddLots;
        private System.Windows.Forms.TextBox noTradeAhead;
        private System.Windows.Forms.TextBox getDone;
        private System.Windows.Forms.TextBox displaySizeAlgo;
        private System.Windows.Forms.TextBox forceCompletion;
        private System.Windows.Forms.TextBox riskAversion;
        private System.Windows.Forms.TextBox noTakeLiq;
        private System.Windows.Forms.TextBox strategyType;
        private System.Windows.Forms.TextBox pctVol;
        private System.Windows.Forms.TextBox maxPctVol;
        private System.Windows.Forms.TextBox allowPastEndTime;
        private System.Windows.Forms.TextBox endTime;
        private System.Windows.Forms.TextBox startTime;
        private System.Windows.Forms.Button checkMarginButton;
        private System.Windows.Forms.Button closeOrderDialogButton;
        private System.Windows.Forms.Label orderPrimExchLabel;
        private System.Windows.Forms.TextBox contractPrimaryExch;
        private System.Windows.Forms.TabPage peg2benchTab;
        private System.Windows.Forms.TextBox tbReferenceChangeAmount;
        private System.Windows.Forms.TextBox tbPeggedChangeAmount;
        private System.Windows.Forms.TextBox tbStartingReferencePrice;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tbStartingPrice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbPeggedChangeType;
        private System.Windows.Forms.TabPage adjustStopTab;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.ComboBox cbAdjustedTrailingAmntUnit;
        private System.Windows.Forms.TextBox tbAdjustedTrailingAmnt;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox tbAdjustedStopLimitPrice;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox tbAdjustedStopPrice;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox tbTriggerPrice;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbAdjustedOrderType;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.LinkLabel lbAddCondition;
        private System.Windows.Forms.LinkLabel lbRemoveCondition;
        private ui.ContractSearchControl contractSearchControl1;
        private System.Windows.Forms.DataGridView conditionList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewComboBoxColumn Logic;
        private System.Windows.Forms.ComboBox cancelOrder;
        private System.Windows.Forms.CheckBox ignoreRth;
        private System.Windows.Forms.TextBox pgdStockRangeLower;
        private System.Windows.Forms.TextBox pgdStockRangeUpper;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox modelCode;
        private System.Windows.Forms.Label modelCodeLabel;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.ComboBox softDollarTier;
        private System.Windows.Forms.TextBox cashQty;
        private System.Windows.Forms.Label cashQtyLabel;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox mifid2DecisionAlgo;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox mifid2DecisionMaker;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.TextBox mifid2ExecutionAlgo;
        private System.Windows.Forms.Label label23;
        private System.Windows.Forms.TextBox mifid2ExecutionTrader;
        private System.Windows.Forms.CheckBox dontUseAutoPriceForHedge;
        private System.Windows.Forms.CheckBox omsContainer;
        private System.Windows.Forms.CheckBox relativeDiscretionary;
        private System.Windows.Forms.Label label24;
        private System.Windows.Forms.CheckBox usePriceMgmtAlgo;
        private System.Windows.Forms.TextBox duration;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.TextBox postToAts;
        private System.Windows.Forms.Label label26;
        private System.Windows.Forms.CheckBox autoCancelParent;
        private System.Windows.Forms.TextBox advancedErrorOverride;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.TextBox manualOrderCancelTime;
        private System.Windows.Forms.Label labelManualOrderCancelTime;
        private System.Windows.Forms.TextBox manualOrderTime;
        private System.Windows.Forms.Label labelManualOrderTime;
        private System.Windows.Forms.Button cancelOrderButton;
        private System.Windows.Forms.TabPage PegBestPegMidTab;
        private System.Windows.Forms.TextBox tbMinTradeQty;
        private System.Windows.Forms.Label labelMinTradeQty;
        private System.Windows.Forms.TextBox tbMinCompeteSize;
        private System.Windows.Forms.Label labelMinCompeteSize;
        private System.Windows.Forms.TextBox tbCompeteAgainstBestOffset;
        private System.Windows.Forms.Label labelCompeteAgainstBestOffset;
        private System.Windows.Forms.TextBox tbMidOffsetAtHalf;
        private System.Windows.Forms.Label labelMidOffsetAtHalf;
        private System.Windows.Forms.TextBox tbMidOffsetAtWhole;
        private System.Windows.Forms.Label labelMidOffsetAtWhole;
        private System.Windows.Forms.CheckBox cbCompeteAgainstBestOffsetUpToMid;
        private System.Windows.Forms.CheckBox solicited;
    }
}