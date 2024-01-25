/* Copyright (C) 2019 Interactive Brokers LLC. All rights reserved. This code is subject to the terms
 * and conditions of the IB API Non-Commercial License or the IB API Commercial License, as applicable. */

using IBApi.types;
using System.Data;
namespace IBSampleApp
{
    partial class IBSampleAppDialog
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
            ibClient.Client.ClientSocket.eDisconnect();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(IBSampleAppDialog));
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            connectButton = new Button();
            clientid_CT = new TextBox();
            cliet_label_CT = new Label();
            port_CT = new TextBox();
            port_label_CT = new Label();
            host_label_CT = new Label();
            host_CT = new TextBox();
            comboTab = new TabPage();
            button2 = new Button();
            comboDeltaNeutralBox = new GroupBox();
            comboDeltaNeutralSet = new Button();
            label2 = new Label();
            label5 = new Label();
            textBox1 = new TextBox();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox4 = new TextBox();
            textBox3 = new TextBox();
            comboBox1 = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            comboLegsBox = new GroupBox();
            dataGridView1 = new DataGridView();
            comboLegAction = new DataGridViewComboBoxColumn();
            comboLegRatio = new DataGridViewTextBoxColumn();
            comboLegDescription = new DataGridViewTextBoxColumn();
            comboLegPrice = new DataGridViewTextBoxColumn();
            comboContractBox = new GroupBox();
            findComboContract = new LinkLabel();
            comboSymbolLabel = new Label();
            comboSymbol = new TextBox();
            comboStrike = new TextBox();
            comboRightLabel = new Label();
            comboLastTradeDate = new TextBox();
            comboStrikeLabel = new Label();
            comboCurrency = new TextBox();
            comboRight = new ComboBox();
            comboCurrencyLabel = new Label();
            comboLastTradeDateLabel = new Label();
            comboMultiplier = new TextBox();
            comboSecType = new ComboBox();
            comboLocalSymbol = new TextBox();
            comboMultiplierLabel = new Label();
            comboExchange = new TextBox();
            comboSecTypeLabel = new Label();
            comboExchangeLabel = new Label();
            comboLocalSymbolLabel = new Label();
            status_CT = new Label();
            status_label_CT = new Label();
            tabControl2 = new TabControl();
            messagesTab = new TabPage();
            messageBoxClear_link = new LinkLabel();
            messageBox = new TextBox();
            informationTooltip = new ToolTip(components);
            buttonReqNewsProviders = new Button();
            buttonReqNewsTicks = new Button();
            buttonCancelNewsTicks = new Button();
            searchContractDetails = new Button();
            requestMatchingSymbolsCD = new Button();
            fundamentalsQueryButton = new Button();
            groupBox3 = new GroupBox();
            queryOptionChain = new Button();
            optionChainUseSnapshot = new CheckBox();
            optionChainOptionExchangeLabel = new Label();
            optionChainExchange = new TextBox();
            groupBox5 = new GroupBox();
            label14 = new Label();
            underlyingConId = new TextBox();
            queryOptionParams = new Button();
            groupBoxMarketRule = new GroupBox();
            comboBoxMarketRuleId = new ComboBox();
            labelMarketRuleId = new Label();
            buttonReqMarketRule = new Button();
            buttonAdditionalForm = new Button();
            ib_banner = new PictureBox();
            label7 = new Label();
            newsTab = new TabPage();
            tabControlNewsResults = new TabControl();
            tabPageTickNewsResults = new TabPage();
            dataGridViewNewsTicks = new DataGridView();
            dataGridViewNewsTicksTimeStamp = new DataGridViewTextBoxColumn();
            dataGridViewNewsTicksProviderCode = new DataGridViewTextBoxColumn();
            dataGridViewNewsTicksArticleId = new DataGridViewTextBoxColumn();
            dataGridViewHeadline = new DataGridViewTextBoxColumn();
            dataGridViewNewsTicksExtraData = new DataGridViewTextBoxColumn();
            linkLabelNewsTicksClear = new LinkLabel();
            tabPageNewsProvidersResults = new TabPage();
            dataGridViewNewsProviders = new DataGridView();
            dataGridViewTextBoxNewsProvidersProviderCode = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxNewsProvidersProviderName = new DataGridViewTextBoxColumn();
            linkLabelClearNewsProviders = new LinkLabel();
            tabPageNewsArticleResults = new TabPage();
            textBoxNewsArticle = new TextBox();
            linkLabelClearNewsArticle = new LinkLabel();
            tabPageHistoricalNewsResults = new TabPage();
            linkLabelClearHistoricalNews = new LinkLabel();
            dataGridViewHistoricalNews = new DataGridView();
            dataGridViewTextBoxTime = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxProviderCode = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxArticleId = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxHeadline = new DataGridViewTextBoxColumn();
            tabControlNews = new TabControl();
            tabPageTickNews = new TabPage();
            groupBoxNewsTicks = new GroupBox();
            textBoxNewsTicksPrimExchange = new TextBox();
            labelNewsTicksPrimExchange = new Label();
            labelNewsTicksSymbol = new Label();
            comboBoxNewsTicksSecType = new ComboBox();
            labelNewsTicksSecType = new Label();
            labelNewsTicksExchange = new Label();
            textBoxNewsTicksExchange = new TextBox();
            labelNewsTicksCurrency = new Label();
            textBoxNewsTicksCurrency = new TextBox();
            textBoxNewsTicksSymbol = new TextBox();
            tabPageNewsProviders = new TabPage();
            tabPageNewsArticle = new TabPage();
            groupBoxNewsArticle = new GroupBox();
            buttonPdfPathDialog = new Button();
            textBoxNewsArticlePath = new TextBox();
            labelNewsArticlePath = new Label();
            textBoxNewsArticleArticleId = new TextBox();
            buttonRequestNewsArticle = new Button();
            labelNewsArticleProviderCode = new Label();
            labelNewsArticleArticleId = new Label();
            textBoxNewsArticleProviderCode = new TextBox();
            tabPageHistoricalNews = new TabPage();
            groupBoxHistoricalNews = new GroupBox();
            textBoxHistoricalNewsProviderCodes = new TextBox();
            buttonRequestHistoricalNews = new Button();
            labelHistoricalNewsConId = new Label();
            labelHistoricalNewsProviderCodes = new Label();
            labelHistoricalNewsEndDateTime = new Label();
            textBoxHistoricalNewsTotalResults = new TextBox();
            labelHistoricalNewsStartDateTime = new Label();
            textBoxHistoricalNewsContractId = new TextBox();
            textBoxHistoricalNewsStartDateTime = new TextBox();
            textBoxHistoricalNewsEndDateTime = new TextBox();
            labelHistoricalNewsTotalResults = new Label();
            acctPosTab = new TabPage();
            acctPosMultiPanel = new TabControl();
            tabPositionsMulti = new TabPage();
            clearPositionsMulti = new LinkLabel();
            positionsMultiGrid = new DataGridView();
            accountPositionsMulti = new DataGridViewTextBoxColumn();
            modelCodePositionsMulti = new DataGridViewTextBoxColumn();
            contractPositionsMulti = new DataGridViewTextBoxColumn();
            positionPositionsMulti = new DataGridViewTextBoxColumn();
            avgCostPositionsMulti = new DataGridViewTextBoxColumn();
            tabAccountUpdatesMulti = new TabPage();
            clearAccountUpdatesMulti = new LinkLabel();
            accountUpdatesMultiGrid = new DataGridView();
            accountAccountUpdatesMulti = new DataGridViewTextBoxColumn();
            modelCodeAccountUpdatesMulti = new DataGridViewTextBoxColumn();
            keyAccountUpdatesMulti = new DataGridViewTextBoxColumn();
            valueAccountUpdatesMulti = new DataGridViewTextBoxColumn();
            currencyAccountUpdatesMulti = new DataGridViewTextBoxColumn();
            groupBoxRequestData = new GroupBox();
            buttonCancelAccountUpdatesMulti = new Button();
            buttonCancelPositionsMulti = new Button();
            buttonRequestAccountUpdatesMulti = new Button();
            cbLedgerAndNLV = new CheckBox();
            labelAccount = new Label();
            buttonRequestPositionsMulti = new Button();
            labelModelCode = new Label();
            textAccount = new TextBox();
            textModelCode = new TextBox();
            optionsTab = new TabPage();
            optionExchange = new TextBox();
            optionExerciseQuan = new TextBox();
            optionExchangeLabel = new Label();
            optionsQuantityLabel = new Label();
            optionsPositionsGroupBox = new GroupBox();
            optionPositionsGrid = new DataGridView();
            optionContract = new DataGridViewTextBoxColumn();
            optionAccount = new DataGridViewTextBoxColumn();
            optionPosition = new DataGridViewTextBoxColumn();
            optionMarketPrice = new DataGridViewTextBoxColumn();
            optionMarketValue = new DataGridViewTextBoxColumn();
            optionAverageCost = new DataGridViewTextBoxColumn();
            optionUnrealizedPnL = new DataGridViewTextBoxColumn();
            optionRealizedPnL = new DataGridViewTextBoxColumn();
            overrideOption = new CheckBox();
            lapseOption = new Button();
            exerciseOption = new Button();
            exerciseAccountLabel = new Label();
            exerciseAccount = new ComboBox();
            advisorTab = new TabPage();
            advisorProfilesBox = new GroupBox();
            saveProfiles = new Button();
            loadProfiles = new Button();
            advisorProfilesGrid = new DataGridView();
            profileName = new DataGridViewTextBoxColumn();
            profileType = new DataGridViewComboBoxColumn();
            profileAllocations = new DataGridViewTextBoxColumn();
            advisorGroupsBox = new GroupBox();
            saveGroups = new Button();
            loadGroups = new Button();
            advisorGroupsGrid = new DataGridView();
            groupName = new DataGridViewTextBoxColumn();
            groupMethod = new DataGridViewComboBoxColumn();
            groupAccounts = new DataGridViewTextBoxColumn();
            advisorAliasesBox = new GroupBox();
            loadAliases = new Button();
            advisorAliasesGrid = new DataGridView();
            advisorAccount = new DataGridViewTextBoxColumn();
            advisorAlias = new DataGridViewTextBoxColumn();
            tabPage1 = new TabPage();
            groupBoxMarketDataType_CDT = new GroupBox();
            comboBoxMarketDataType_CDT = new ComboBox();
            contractFundamentalsGroupBox = new GroupBox();
            fundamentalsReportTypeLabel = new Label();
            fundamentalsReportType = new ComboBox();
            contractDetailsGroupBox = new GroupBox();
            conDetIssuerIdLabel = new Label();
            conDetIssuerId = new TextBox();
            conDetSymbolLabel = new Label();
            conDetRightLabel = new Label();
            conDetStrikeLabel = new Label();
            conDetRight = new ComboBox();
            conDetLastTradeDateLabel = new Label();
            conDetSecType = new ComboBox();
            conDetMultiplierLabel = new Label();
            conDetSecTypeLabel = new Label();
            conDetLocalSymbolLabel = new Label();
            conDetExchangeLabel = new Label();
            conDetExchange = new TextBox();
            conDetLocalSymbol = new TextBox();
            conDetMultiplier = new TextBox();
            conDetCurrencyLabel = new Label();
            conDetCurrency = new TextBox();
            conDetLastTradeDateOrContractMonth = new TextBox();
            conDetStrike = new TextBox();
            conDetSymbol = new TextBox();
            contractInfoTab = new TabControl();
            contractDetailsPage = new TabPage();
            contractDetailsGrid = new DataGridView();
            conResSymbol = new DataGridViewTextBoxColumn();
            conResLocalSymbol = new DataGridViewTextBoxColumn();
            conResSecType = new DataGridViewTextBoxColumn();
            conResCurrency = new DataGridViewTextBoxColumn();
            conResExchange = new DataGridViewTextBoxColumn();
            conResPrimaryExch = new DataGridViewTextBoxColumn();
            conResLastTradeDate = new DataGridViewTextBoxColumn();
            conResMultiplier = new DataGridViewTextBoxColumn();
            conResStrike = new DataGridViewTextBoxColumn();
            conResRight = new DataGridViewTextBoxColumn();
            conResConId = new DataGridViewTextBoxColumn();
            conResAggGroup = new DataGridViewTextBoxColumn();
            conResUnderSymbol = new DataGridViewTextBoxColumn();
            conResUnderSecType = new DataGridViewTextBoxColumn();
            conResMarketRuleIds = new DataGridViewTextBoxColumn();
            conResRealExpirationDate = new DataGridViewTextBoxColumn();
            conResContractMonth = new DataGridViewTextBoxColumn();
            conResLastTradeTime = new DataGridViewTextBoxColumn();
            conResTimeZoneId = new DataGridViewTextBoxColumn();
            conResStockType = new DataGridViewTextBoxColumn();
            conResMinSize = new DataGridViewTextBoxColumn();
            conResSizeIncrement = new DataGridViewTextBoxColumn();
            conResSuggestedSizeIncrement = new DataGridViewTextBoxColumn();
            fundamentalsPage = new TabPage();
            fundamentalsOutput = new TextBox();
            optionChainPage = new TabPage();
            optionChainCallGroup = new GroupBox();
            optionChainCallGrid = new DataGridView();
            callLastTradeDate = new DataGridViewTextBoxColumn();
            callStrike = new DataGridViewTextBoxColumn();
            callBid = new DataGridViewTextBoxColumn();
            callAsk = new DataGridViewTextBoxColumn();
            callImpliedVolatility = new DataGridViewTextBoxColumn();
            callDelta = new DataGridViewTextBoxColumn();
            callGamma = new DataGridViewTextBoxColumn();
            callVega = new DataGridViewTextBoxColumn();
            callTheta = new DataGridViewTextBoxColumn();
            optionChainPutGroup = new GroupBox();
            optionChainPutGrid = new DataGridView();
            putLastTradeDate = new DataGridViewTextBoxColumn();
            putStrike = new DataGridViewTextBoxColumn();
            putBid = new DataGridViewTextBoxColumn();
            putAsk = new DataGridViewTextBoxColumn();
            putImpliedVolatility = new DataGridViewTextBoxColumn();
            putDelta = new DataGridViewTextBoxColumn();
            putGamma = new DataGridViewTextBoxColumn();
            putVega = new DataGridViewTextBoxColumn();
            putTheta = new DataGridViewTextBoxColumn();
            optionParametersPage = new TabPage();
            listViewOptionParams = new ListView();
            columnHeader1 = new ColumnHeader();
            columnHeader2 = new ColumnHeader();
            symbolSamplesTabContractInfo = new TabPage();
            clearSymbolSamplesContractInfo = new LinkLabel();
            symbolSamplesDataGridContractInfo = new DataGridView();
            symbolSamplesConId2 = new DataGridViewTextBoxColumn();
            symbolSamplesSymbol2 = new DataGridViewTextBoxColumn();
            symbolSamplesSecType2 = new DataGridViewTextBoxColumn();
            symbolSamplesPrimExch2 = new DataGridViewTextBoxColumn();
            symbolSamplesCurrency2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn14 = new DataGridViewTextBoxColumn();
            symbolSamplesDescription2 = new DataGridViewTextBoxColumn();
            symbolSamplesIssuerId2 = new DataGridViewTextBoxColumn();
            bondContractDetailsPage = new TabPage();
            bondContractDetailsGrid = new DataGridView();
            bondContractDetailsConId = new DataGridViewTextBoxColumn();
            bondContractDetailsSymbol = new DataGridViewTextBoxColumn();
            bondContractDetailsExchange = new DataGridViewTextBoxColumn();
            bondContractDetailsCurrency = new DataGridViewTextBoxColumn();
            bondContractDetailsTradingClass = new DataGridViewTextBoxColumn();
            bondContractDetailsMarketName = new DataGridViewTextBoxColumn();
            bondContractDetailsMinTick = new DataGridViewTextBoxColumn();
            bondContractDetailsOrderTypes = new DataGridViewTextBoxColumn();
            bondContractDetailsValidExchanges = new DataGridViewTextBoxColumn();
            bondContractDetailsLongName = new DataGridViewTextBoxColumn();
            bondContractDetailsAggGroup = new DataGridViewTextBoxColumn();
            bondContractDetailsMarketRuleIds = new DataGridViewTextBoxColumn();
            bondContractDetailsCusip = new DataGridViewTextBoxColumn();
            bondContractDetailsRatings = new DataGridViewTextBoxColumn();
            bondContractDetailsDescAppend = new DataGridViewTextBoxColumn();
            bondContractDetailsBondType = new DataGridViewTextBoxColumn();
            bondContractDetailsCouponType = new DataGridViewTextBoxColumn();
            bondContractDetailsCallable = new DataGridViewTextBoxColumn();
            bondContractDetailsPutable = new DataGridViewTextBoxColumn();
            bondContractDetailsCoupon = new DataGridViewTextBoxColumn();
            bondContractDetailsConvertible = new DataGridViewTextBoxColumn();
            bondContractDetailsMaturity = new DataGridViewTextBoxColumn();
            bondContractDetailsIssueDate = new DataGridViewTextBoxColumn();
            bondContractDetailsNextOptionDate = new DataGridViewTextBoxColumn();
            bondContractDetailsNextOptionType = new DataGridViewTextBoxColumn();
            bondContractDetailsNextOptionPartial = new DataGridViewTextBoxColumn();
            bondContractDetailsNotes = new DataGridViewTextBoxColumn();
            bondContractDetailsLastTradeTime = new DataGridViewTextBoxColumn();
            bondContractDetsilsTimeZoneId = new DataGridViewTextBoxColumn();
            bondContractDetailsMinSize = new DataGridViewTextBoxColumn();
            bondContractDetailsSizeIncrement = new DataGridViewTextBoxColumn();
            bondContractDetailsSuggestedSizeIncrement = new DataGridViewTextBoxColumn();
            marketRulePage = new TabPage();
            labelMarketRuleIdRes = new Label();
            dataGridViewMarketRule = new DataGridView();
            dataGridViewPriceIncrementLowEdge = new DataGridViewTextBoxColumn();
            dataGridViewPriceIncrementIncrement = new DataGridViewTextBoxColumn();
            accountInfoTab = new TabPage();
            reqUserInfo = new Button();
            tabControl1 = new TabControl();
            accSummaryTab = new TabPage();
            accSummaryRequest = new Button();
            accSummaryGrid = new DataGridView();
            tag = new DataGridViewTextBoxColumn();
            value = new DataGridViewTextBoxColumn();
            currency = new DataGridViewTextBoxColumn();
            accountSummaryAccount = new DataGridViewTextBoxColumn();
            accUpdatesTab = new TabPage();
            accUpdatesSubscribedAccount = new Label();
            accUpdatesAccountLabel = new Label();
            accUpdatesLastUpdateValue = new Label();
            accountPortfolioGrid = new DataGridView();
            updatePortfolioContract = new DataGridViewTextBoxColumn();
            updatePortfolioPosition = new DataGridViewTextBoxColumn();
            updatePortfolioMarketPrice = new DataGridViewTextBoxColumn();
            updatePortfolioMarketValue = new DataGridViewTextBoxColumn();
            updatePortfolioAvgCost = new DataGridViewTextBoxColumn();
            updatePortfolioUnrealizedPnL = new DataGridViewTextBoxColumn();
            updatePortfolioRealizedPnL = new DataGridViewTextBoxColumn();
            accountValuesGrid = new DataGridView();
            accUpdatesKey = new DataGridViewTextBoxColumn();
            accUpdatesValue = new DataGridViewTextBoxColumn();
            accUpdatesCurrency = new DataGridViewTextBoxColumn();
            accUpdatesSubscribe = new Button();
            lastUpdatedLabel = new Label();
            positionsTab = new TabPage();
            positionRequest = new Button();
            positionsGrid = new DataGridView();
            positionContract = new DataGridViewTextBoxColumn();
            positionAccount = new DataGridViewTextBoxColumn();
            positionPosition = new DataGridViewTextBoxColumn();
            positionAvgCost = new DataGridViewTextBoxColumn();
            familyCodesTab = new TabPage();
            clearFamilyCodes = new Button();
            requestFamilyCodes = new Button();
            familyCodesGrid = new DataGridView();
            familyCodesGridColumnAccountID = new DataGridViewTextBoxColumn();
            familyCodesGridColumnFamilyCode = new DataGridViewTextBoxColumn();
            pnlTab = new TabPage();
            btnCancelPnLSingle = new Button();
            btnCancelPnL = new Button();
            btnReqPnLSingle = new Button();
            tbConId = new TextBox();
            label13 = new Label();
            tbModelCode = new TextBox();
            label9 = new Label();
            btnReqPnL = new Button();
            dataGridViewPnL = new DataGridView();
            accountSelectorLabel = new Label();
            accountSelector = new ComboBox();
            tradingTab = new TabPage();
            completedOrdersButton = new Button();
            completedOrdersGroup = new GroupBox();
            completedOrdersGrid = new DataGridView();
            completedOrdersBoxColumn1 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn2 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn3 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn4 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn5 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn6 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn7 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn8 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn9 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn10 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn11 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn12 = new DataGridViewTextBoxColumn();
            completedOrdersBoxColumn13 = new DataGridViewTextBoxColumn();
            buttonAttachOrder = new Button();
            execFilterGroup = new GroupBox();
            execFilterExchange = new TextBox();
            execFilterSide = new TextBox();
            execFilterSideLabel = new Label();
            execFilterExchangeLabel = new Label();
            execFilterSecTypeLabel = new Label();
            execFilterSymbolLabel = new Label();
            execFilterTimeLabel = new Label();
            execFilterAcctLabel = new Label();
            execFilterClientLabel = new Label();
            execFilterSecType = new TextBox();
            execFilterSymbol = new TextBox();
            execFilterTime = new TextBox();
            execFilterAccount = new TextBox();
            execFilterClientId = new TextBox();
            refreshExecutionsButton = new Button();
            globalCancelButton = new Button();
            clientOrdersButton = new Button();
            refreshOrdersButton = new Button();
            cancelOrdersButton = new Button();
            button1 = new Button();
            newOrderLink = new LinkLabel();
            executionsGroup = new GroupBox();
            tradeLogGrid = new DataGridView();
            ExecutionId = new DataGridViewTextBoxColumn();
            dateTimeExecColumn = new DataGridViewTextBoxColumn();
            accountExecColumn = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn8 = new DataGridViewTextBoxColumn();
            actionExecColumn = new DataGridViewTextBoxColumn();
            quantityExecColumn = new DataGridViewTextBoxColumn();
            descriptionExecColumn = new DataGridViewTextBoxColumn();
            priceExecColumn = new DataGridViewTextBoxColumn();
            commissionExecColumn = new DataGridViewTextBoxColumn();
            RealizedPnL = new DataGridViewTextBoxColumn();
            LastLiquidity = new DataGridViewTextBoxColumn();
            liveOrdersGroup = new GroupBox();
            liveOrdersGrid = new DataGridView();
            permIdColumn = new DataGridViewTextBoxColumn();
            clientIdColumn = new DataGridViewTextBoxColumn();
            orderIdColumn = new DataGridViewTextBoxColumn();
            accountColumn = new DataGridViewTextBoxColumn();
            modelCodeColumn = new DataGridViewTextBoxColumn();
            actionColumn = new DataGridViewTextBoxColumn();
            quantityColumn = new DataGridViewTextBoxColumn();
            contractColumn = new DataGridViewTextBoxColumn();
            statusColumn = new DataGridViewTextBoxColumn();
            cashQtyColumn = new DataGridViewTextBoxColumn();
            marketDataTab = new TabPage();
            marketData_MDT = new TabControl();
            topMarketDataTab_MDT = new TabPage();
            closeMketDataTab = new LinkLabel();
            marketDataGrid_MDT = new DataGridView();
            marketDataContract = new DataGridViewTextBoxColumn();
            marketDataTypeTickerColumn = new DataGridViewTextBoxColumn();
            bidSize = new DataGridViewTextBoxColumn();
            bidPrice = new DataGridViewTextBoxColumn();
            preOpenBid = new DataGridViewTextBoxColumn();
            preOpenAsk = new DataGridViewTextBoxColumn();
            askPrice = new DataGridViewTextBoxColumn();
            askSize = new DataGridViewTextBoxColumn();
            lastTickerColumn = new DataGridViewTextBoxColumn();
            lastPrice = new DataGridViewTextBoxColumn();
            volume = new DataGridViewTextBoxColumn();
            closeTickerColumn = new DataGridViewTextBoxColumn();
            openTickerColumn = new DataGridViewTextBoxColumn();
            highTickerColumn = new DataGridViewTextBoxColumn();
            lowTickerColumn = new DataGridViewTextBoxColumn();
            futuresOpenInterestTickerColumn = new DataGridViewTextBoxColumn();
            avgOptVolumeTickerColumn = new DataGridViewTextBoxColumn();
            shortableSharesTickerColumn = new DataGridViewTextBoxColumn();
            estimatedIPOMidpointTickerColumn = new DataGridViewTextBoxColumn();
            finalIPOLastTickerColumn = new DataGridViewTextBoxColumn();
            deepBookTab_MDT = new TabPage();
            closeDeepBookLink = new LinkLabel();
            deepBookGrid = new DataGridView();
            bidBookMaker = new DataGridViewTextBoxColumn();
            bidBookSize = new DataGridViewTextBoxColumn();
            bidBookPrice = new DataGridViewTextBoxColumn();
            askBookPrice = new DataGridViewTextBoxColumn();
            askBookSize = new DataGridViewTextBoxColumn();
            askBookMaker = new DataGridViewTextBoxColumn();
            historicalDataTab = new TabPage();
            histDataTabClose_MDT = new LinkLabel();
            barsGrid = new DataGridView();
            hdDate = new DataGridViewTextBoxColumn();
            hdOpen = new DataGridViewTextBoxColumn();
            hdHigh = new DataGridViewTextBoxColumn();
            hdLow = new DataGridViewTextBoxColumn();
            hdClose = new DataGridViewTextBoxColumn();
            hdVolume = new DataGridViewTextBoxColumn();
            hdWap = new DataGridViewTextBoxColumn();
            historicalChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            rtBarsTab_MDT = new TabPage();
            rtBarsCloseLink = new LinkLabel();
            rtBarsGrid = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn7 = new DataGridViewTextBoxColumn();
            rtBarsChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            scannerTab = new TabPage();
            scannerTab_link = new LinkLabel();
            scannerGrid = new DataGridView();
            scanRank = new DataGridViewTextBoxColumn();
            scanContract = new DataGridViewTextBoxColumn();
            scanDistance = new DataGridViewTextBoxColumn();
            scanBenchmark = new DataGridViewTextBoxColumn();
            scanProjection = new DataGridViewTextBoxColumn();
            scanLegStr = new DataGridViewTextBoxColumn();
            scannerParamsTab = new TabPage();
            scannerParamsOutput = new TextBox();
            mktDepthExchanges_MDT = new TabPage();
            mktDepthExchangesGrid_MDT = new DataGridView();
            mktDepthExchangesColumn_Exchange = new DataGridViewTextBoxColumn();
            mktDepthExchangesColumn_SecType = new DataGridViewTextBoxColumn();
            mktDepthExchangesColumn_ListingExch = new DataGridViewTextBoxColumn();
            mktDepthExchangesColumn_ServiceDataType = new DataGridViewTextBoxColumn();
            mktDepthExchangesColumn_AggGroup = new DataGridViewTextBoxColumn();
            clearMktDepthExchanges_Button = new LinkLabel();
            symbolSamplesTabData = new TabPage();
            clearSymbolSamplesMarketData = new LinkLabel();
            symbolSamplesDataGridData = new DataGridView();
            symbolSamplesConId = new DataGridViewTextBoxColumn();
            symbolSamplesSymbol = new DataGridViewTextBoxColumn();
            symbolSamplesSecType = new DataGridViewTextBoxColumn();
            symbolSamplesPrimExch = new DataGridViewTextBoxColumn();
            symbolSamplesCurrency = new DataGridViewTextBoxColumn();
            symbolSamplesDerivativeSecTypes = new DataGridViewTextBoxColumn();
            symbolSamplesDescription = new DataGridViewTextBoxColumn();
            symbolSamplesIssuerId = new DataGridViewTextBoxColumn();
            smartComponentsTabPage = new TabPage();
            linkLabel1 = new LinkLabel();
            dataGridViewSmartComponents = new DataGridView();
            dataGridViewTextBoxColumn25 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn26 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn27 = new DataGridViewTextBoxColumn();
            headTimestampTabPage = new TabPage();
            clearHeadTimestampGridViewlinkLabel = new LinkLabel();
            headTimestampDataGridView = new DataGridView();
            reqIdColumn = new DataGridViewTextBoxColumn();
            headTimestampColumn = new DataGridViewTextBoxColumn();
            conIdColumn = new DataGridViewTextBoxColumn();
            symbolColumn = new DataGridViewTextBoxColumn();
            secTypeColumn = new DataGridViewTextBoxColumn();
            lastTradeDateorContractMonthColumn = new DataGridViewTextBoxColumn();
            strikeColumn = new DataGridViewTextBoxColumn();
            rightColumn = new DataGridViewTextBoxColumn();
            multiplierColumn = new DataGridViewTextBoxColumn();
            exchangeColumn = new DataGridViewTextBoxColumn();
            primaryExchColumn = new DataGridViewTextBoxColumn();
            currencyColumn = new DataGridViewTextBoxColumn();
            localSymbolColumn = new DataGridViewTextBoxColumn();
            tradingClassColumn = new DataGridViewTextBoxColumn();
            includeExpiredColumn = new DataGridViewCheckBoxColumn();
            whatToShowColumn = new DataGridViewTextBoxColumn();
            histogramTabPage = new TabPage();
            histogramClearLinkLabel = new LinkLabel();
            histogramDataGridView = new DataGridView();
            Column1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn16 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn17 = new DataGridViewTextBoxColumn();
            historicalTicksTabPage = new TabPage();
            label15 = new Label();
            linkLabel2 = new LinkLabel();
            dataGridViewHistoricalTicks = new DataGridView();
            tabPageTickByTick = new TabPage();
            linkLabelClearTickByTick = new LinkLabel();
            labelTickByTick = new Label();
            dataGridViewTickByTick = new DataGridView();
            tabHistoricalSchedule = new TabPage();
            historicalScheduleGrid = new DataGridView();
            historicalSchduleGridStartDateTime = new DataGridViewTextBoxColumn();
            historicalSchduleGridEndDateTime = new DataGridViewTextBoxColumn();
            historicalSchduleGridRefDate = new DataGridViewTextBoxColumn();
            linkLabelClearHistoricalSchedule = new LinkLabel();
            labelHistoricalSchedule = new Label();
            historicalScheduleOutput = new TextBox();
            dataResults_MDT = new TabControl();
            topMktData_MDT = new TabPage();
            requestMatchingSymbolsMD = new Button();
            cancelMarketDataRequests = new Button();
            marketData_Button = new Button();
            histogram_button = new Button();
            ReqSmartComponents_Button = new Button();
            groupBox6 = new GroupBox();
            label8 = new Label();
            bboExchange_comboBox = new ComboBox();
            groupBoxMarketDataType_MDT = new GroupBox();
            comboBoxMarketDataType_MDT = new ComboBox();
            deepBookGroupBox = new GroupBox();
            cbSmartDepth = new CheckBox();
            ReqMktDepthExchanges_Button = new Button();
            deepBookEntries = new TextBox();
            deepBookEntriesLabel = new Label();
            deepBook_Button = new Button();
            groupBox2 = new GroupBox();
            primaryExchange = new TextBox();
            primaryExchLabel = new Label();
            genericTickList = new TextBox();
            genericTickListLabel = new Label();
            mdRightLabel = new Label();
            mdContractRight = new ComboBox();
            putcall_label_TMD_MDT = new Label();
            multiplier_TMD_MDT = new TextBox();
            symbol_label_TMD_MDT = new Label();
            secType_TMD_MDT = new ComboBox();
            label1 = new Label();
            exchange_label_TMD_MDT = new Label();
            localSymbol_TMD_MDT = new TextBox();
            currency_label_TMD_MDT = new Label();
            lastTradeDateOrContractMonth_TMD_MDT = new TextBox();
            symbol_TMD_MDT = new TextBox();
            strike_TMD_MDT = new TextBox();
            currency_TMD_MDT = new TextBox();
            exchange_TMD_MDT = new TextBox();
            localSymbol_label_TMD_MDT = new Label();
            lastTradeDate_label_TMD_MDT = new Label();
            strike_label_TMD_MDT = new Label();
            groupBox1 = new GroupBox();
            histScheduleButton = new Button();
            cbKeepUpToDate = new CheckBox();
            headTimestamp_button = new Button();
            contractMDRTH = new CheckBox();
            realTime_Button = new Button();
            histData_Button = new Button();
            hdEndDate_label_HDT = new Label();
            label12 = new Label();
            hdRequest_EndTime = new TextBox();
            hdRequest_WhatToShow = new ComboBox();
            hdRequest_Duration = new TextBox();
            includeExpired = new CheckBox();
            hdRequest_BarSize = new ComboBox();
            label10 = new Label();
            label11 = new Label();
            hdRequest_TimeUnit = new ComboBox();
            marketScanner_MDT = new TabPage();
            groupBox8 = new GroupBox();
            FilterOptionRemove_button = new Button();
            FilterOptionAdd_button = new Button();
            label17 = new Label();
            textBoxFilterValue = new TextBox();
            label16 = new Label();
            comboBoxFilterName = new ComboBox();
            listViewFilterOptions = new ListView();
            columnHeader3 = new ColumnHeader();
            columnHeader4 = new ColumnHeader();
            groupBox4 = new GroupBox();
            scanCode = new ComboBox();
            scanInstrument = new ComboBox();
            scannerRequest_Button = new Button();
            scanLocation = new ComboBox();
            scanStockType = new ComboBox();
            scanNumRows = new TextBox();
            scanNumRows_label = new Label();
            scanCode_label = new Label();
            scanStockType_label = new Label();
            scanInstrument_label = new Label();
            scanLocation_label = new Label();
            scannerParamsRequest_button = new Button();
            historicalTicks_MDT = new TabPage();
            groupBoxTickByTickType = new GroupBox();
            buttonCancelTickByTick = new Button();
            buttonRequestTickByTick = new Button();
            comboBoxTickByTickType = new ComboBox();
            groupBox7 = new GroupBox();
            btnRequestHistoricalTicks = new Button();
            label21 = new Label();
            label20 = new Label();
            label19 = new Label();
            label18 = new Label();
            cbWhatToShow = new ComboBox();
            cbRthOnly = new CheckBox();
            cbIgnoreSize = new CheckBox();
            tbEndDate = new TextBox();
            tbNumOfTicks = new TextBox();
            tbStartDate = new TextBox();
            TabControl = new TabControl();
            wshTab = new TabPage();
            textBoxWshTotalLimit = new TextBox();
            labelWshTotalLimit = new Label();
            textBoxWshEndDate = new TextBox();
            labelWshEndDate = new Label();
            textBoxWshStartDate = new TextBox();
            labelWshStartDate = new Label();
            checkBoxWshFillCompetitors = new CheckBox();
            checkBoxWshFillPortfolio = new CheckBox();
            checkBoxWshFillWatchlist = new CheckBox();
            textBoxWshFilter = new TextBox();
            labelWshFilter = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            textBoxWshConId = new TextBox();
            labelWshConId = new Label();
            button6 = new Button();
            dataGridViewWsh = new DataGridView();
            comboTab.SuspendLayout();
            comboDeltaNeutralBox.SuspendLayout();
            comboLegsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            comboContractBox.SuspendLayout();
            tabControl2.SuspendLayout();
            messagesTab.SuspendLayout();
            groupBox3.SuspendLayout();
            groupBox5.SuspendLayout();
            groupBoxMarketRule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ib_banner).BeginInit();
            newsTab.SuspendLayout();
            tabControlNewsResults.SuspendLayout();
            tabPageTickNewsResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNewsTicks).BeginInit();
            tabPageNewsProvidersResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNewsProviders).BeginInit();
            tabPageNewsArticleResults.SuspendLayout();
            tabPageHistoricalNewsResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricalNews).BeginInit();
            tabControlNews.SuspendLayout();
            tabPageTickNews.SuspendLayout();
            groupBoxNewsTicks.SuspendLayout();
            tabPageNewsProviders.SuspendLayout();
            tabPageNewsArticle.SuspendLayout();
            groupBoxNewsArticle.SuspendLayout();
            tabPageHistoricalNews.SuspendLayout();
            groupBoxHistoricalNews.SuspendLayout();
            acctPosTab.SuspendLayout();
            acctPosMultiPanel.SuspendLayout();
            tabPositionsMulti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)positionsMultiGrid).BeginInit();
            tabAccountUpdatesMulti.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accountUpdatesMultiGrid).BeginInit();
            groupBoxRequestData.SuspendLayout();
            optionsTab.SuspendLayout();
            optionsPositionsGroupBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)optionPositionsGrid).BeginInit();
            advisorTab.SuspendLayout();
            advisorProfilesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advisorProfilesGrid).BeginInit();
            advisorGroupsBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advisorGroupsGrid).BeginInit();
            advisorAliasesBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)advisorAliasesGrid).BeginInit();
            tabPage1.SuspendLayout();
            groupBoxMarketDataType_CDT.SuspendLayout();
            contractFundamentalsGroupBox.SuspendLayout();
            contractDetailsGroupBox.SuspendLayout();
            contractInfoTab.SuspendLayout();
            contractDetailsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)contractDetailsGrid).BeginInit();
            fundamentalsPage.SuspendLayout();
            optionChainPage.SuspendLayout();
            optionChainCallGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)optionChainCallGrid).BeginInit();
            optionChainPutGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)optionChainPutGrid).BeginInit();
            optionParametersPage.SuspendLayout();
            symbolSamplesTabContractInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)symbolSamplesDataGridContractInfo).BeginInit();
            bondContractDetailsPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)bondContractDetailsGrid).BeginInit();
            marketRulePage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarketRule).BeginInit();
            accountInfoTab.SuspendLayout();
            tabControl1.SuspendLayout();
            accSummaryTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accSummaryGrid).BeginInit();
            accUpdatesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)accountPortfolioGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)accountValuesGrid).BeginInit();
            positionsTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)positionsGrid).BeginInit();
            familyCodesTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)familyCodesGrid).BeginInit();
            pnlTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPnL).BeginInit();
            tradingTab.SuspendLayout();
            completedOrdersGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)completedOrdersGrid).BeginInit();
            execFilterGroup.SuspendLayout();
            executionsGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)tradeLogGrid).BeginInit();
            liveOrdersGroup.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)liveOrdersGrid).BeginInit();
            marketDataTab.SuspendLayout();
            marketData_MDT.SuspendLayout();
            topMarketDataTab_MDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)marketDataGrid_MDT).BeginInit();
            deepBookTab_MDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)deepBookGrid).BeginInit();
            historicalDataTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)barsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)historicalChart).BeginInit();
            rtBarsTab_MDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)rtBarsGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)rtBarsChart).BeginInit();
            scannerTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)scannerGrid).BeginInit();
            scannerParamsTab.SuspendLayout();
            mktDepthExchanges_MDT.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)mktDepthExchangesGrid_MDT).BeginInit();
            symbolSamplesTabData.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)symbolSamplesDataGridData).BeginInit();
            smartComponentsTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSmartComponents).BeginInit();
            headTimestampTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)headTimestampDataGridView).BeginInit();
            histogramTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)histogramDataGridView).BeginInit();
            historicalTicksTabPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricalTicks).BeginInit();
            tabPageTickByTick.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTickByTick).BeginInit();
            tabHistoricalSchedule.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)historicalScheduleGrid).BeginInit();
            dataResults_MDT.SuspendLayout();
            topMktData_MDT.SuspendLayout();
            groupBox6.SuspendLayout();
            groupBoxMarketDataType_MDT.SuspendLayout();
            deepBookGroupBox.SuspendLayout();
            groupBox2.SuspendLayout();
            groupBox1.SuspendLayout();
            marketScanner_MDT.SuspendLayout();
            groupBox8.SuspendLayout();
            groupBox4.SuspendLayout();
            historicalTicks_MDT.SuspendLayout();
            groupBoxTickByTickType.SuspendLayout();
            groupBox7.SuspendLayout();
            TabControl.SuspendLayout();
            wshTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWsh).BeginInit();
            SuspendLayout();
            // 
            // connectButton
            // 
            connectButton.Location = new Point(1378, 14);
            connectButton.Margin = new Padding(4, 3, 4, 3);
            connectButton.Name = "connectButton";
            connectButton.Size = new Size(88, 27);
            connectButton.TabIndex = 6;
            connectButton.Text = "Connect";
            informationTooltip.SetToolTip(connectButton, "Connects to TWS or IB Gateway.");
            connectButton.UseVisualStyleBackColor = true;
            connectButton.Click += connectButton_Click;
            // 
            // clientid_CT
            // 
            clientid_CT.Location = new Point(1274, 17);
            clientid_CT.Margin = new Padding(4, 3, 4, 3);
            clientid_CT.Name = "clientid_CT";
            clientid_CT.Size = new Size(96, 23);
            clientid_CT.TabIndex = 5;
            clientid_CT.Text = "1";
            informationTooltip.SetToolTip(clientid_CT, "Each TWS can handle up to 8 simultaneous clients identifed by a unique Id.");
            // 
            // cliet_label_CT
            // 
            cliet_label_CT.AutoSize = true;
            cliet_label_CT.Location = new Point(1214, 25);
            cliet_label_CT.Margin = new Padding(4, 0, 4, 0);
            cliet_label_CT.Name = "cliet_label_CT";
            cliet_label_CT.Size = new Size(51, 15);
            cliet_label_CT.TabIndex = 4;
            cliet_label_CT.Text = "Client Id";
            // 
            // port_CT
            // 
            port_CT.Location = new Point(1111, 18);
            port_CT.Margin = new Padding(4, 3, 4, 3);
            port_CT.Name = "port_CT";
            port_CT.Size = new Size(96, 23);
            port_CT.TabIndex = 3;
            port_CT.Text = "7497";
            informationTooltip.SetToolTip(port_CT, "TWS' listening port.");
            // 
            // port_label_CT
            // 
            port_label_CT.AutoSize = true;
            port_label_CT.Location = new Point(1073, 25);
            port_label_CT.Margin = new Padding(4, 0, 4, 0);
            port_label_CT.Name = "port_label_CT";
            port_label_CT.Size = new Size(29, 15);
            port_label_CT.TabIndex = 2;
            port_label_CT.Text = "Port";
            // 
            // host_label_CT
            // 
            host_label_CT.AutoSize = true;
            host_label_CT.Location = new Point(929, 25);
            host_label_CT.Margin = new Padding(4, 0, 4, 0);
            host_label_CT.Name = "host_label_CT";
            host_label_CT.Size = new Size(32, 15);
            host_label_CT.TabIndex = 0;
            host_label_CT.Text = "Host";
            // 
            // host_CT
            // 
            host_CT.Location = new Point(969, 18);
            host_CT.Margin = new Padding(4, 3, 4, 3);
            host_CT.Name = "host_CT";
            host_CT.Size = new Size(96, 23);
            host_CT.TabIndex = 1;
            host_CT.Text = "127.0.0.1";
            informationTooltip.SetToolTip(host_CT, "TWS host's IP address (leave blank if TWS is running on the same machine).");
            // 
            // comboTab
            // 
            comboTab.BackColor = Color.LightGray;
            comboTab.Controls.Add(button2);
            comboTab.Controls.Add(comboDeltaNeutralBox);
            comboTab.Controls.Add(comboLegsBox);
            comboTab.Controls.Add(comboContractBox);
            comboTab.Location = new Point(4, 22);
            comboTab.Name = "comboTab";
            comboTab.Padding = new Padding(3);
            comboTab.Size = new Size(1248, 430);
            comboTab.TabIndex = 6;
            comboTab.Text = "Combo Trading (in progress)";
            // 
            // button2
            // 
            button2.Location = new Point(792, 28);
            button2.Name = "button2";
            button2.Size = new Size(75, 23);
            button2.TabIndex = 84;
            button2.Text = "button2";
            button2.UseVisualStyleBackColor = true;
            // 
            // comboDeltaNeutralBox
            // 
            comboDeltaNeutralBox.Controls.Add(comboDeltaNeutralSet);
            comboDeltaNeutralBox.Controls.Add(label2);
            comboDeltaNeutralBox.Controls.Add(label5);
            comboDeltaNeutralBox.Controls.Add(textBox1);
            comboDeltaNeutralBox.Controls.Add(label6);
            comboDeltaNeutralBox.Controls.Add(textBox2);
            comboDeltaNeutralBox.Controls.Add(textBox4);
            comboDeltaNeutralBox.Controls.Add(textBox3);
            comboDeltaNeutralBox.Controls.Add(comboBox1);
            comboDeltaNeutralBox.Controls.Add(label3);
            comboDeltaNeutralBox.Controls.Add(label4);
            comboDeltaNeutralBox.Location = new Point(890, 6);
            comboDeltaNeutralBox.Name = "comboDeltaNeutralBox";
            comboDeltaNeutralBox.Size = new Size(190, 155);
            comboDeltaNeutralBox.TabIndex = 83;
            comboDeltaNeutralBox.TabStop = false;
            comboDeltaNeutralBox.Text = "Delta Neutral";
            // 
            // comboDeltaNeutralSet
            // 
            comboDeltaNeutralSet.Location = new Point(145, 17);
            comboDeltaNeutralSet.Name = "comboDeltaNeutralSet";
            comboDeltaNeutralSet.Size = new Size(37, 23);
            comboDeltaNeutralSet.TabIndex = 84;
            comboDeltaNeutralSet.Text = "Set";
            comboDeltaNeutralSet.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(24, 23);
            label2.Name = "label2";
            label2.Size = new Size(47, 15);
            label2.TabIndex = 85;
            label2.Text = "Symbol";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(15, 45);
            label5.Name = "label5";
            label5.Size = new Size(49, 15);
            label5.TabIndex = 87;
            label5.Text = "SecType";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(71, 20);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(68, 23);
            textBox1.TabIndex = 84;
            textBox1.Text = "SPY";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(10, 98);
            label6.Name = "label6";
            label6.Size = new Size(58, 15);
            label6.TabIndex = 89;
            label6.Text = "Exchange";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(71, 124);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(67, 23);
            textBox2.TabIndex = 93;
            textBox2.Text = "20130908";
            // 
            // textBox4
            // 
            textBox4.Location = new Point(71, 98);
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(68, 23);
            textBox4.TabIndex = 92;
            textBox4.Text = "ARCA";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(71, 72);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(68, 23);
            textBox3.TabIndex = 91;
            textBox3.Text = "USD";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "STK", "OPT", "FUT", "CASH", "BOND", "CFD", "FOP", "WAR", "IOPT", "FWD", "BAG", "IND", "BILL", "FUND", "FIXED", "SLB", "NEWS", "CMDTY", "BSK", "ICU", "ICS", "CRYPTO" });
            comboBox1.Location = new Point(71, 45);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(68, 23);
            comboBox1.TabIndex = 86;
            comboBox1.Text = "STK";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(16, 72);
            label3.Name = "label3";
            label3.Size = new Size(55, 15);
            label3.TabIndex = 90;
            label3.Text = "Currency";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(30, 123);
            label4.Name = "label4";
            label4.Size = new Size(77, 15);
            label4.TabIndex = 88;
            label4.Text = "lastTradeDate";
            // 
            // comboLegsBox
            // 
            comboLegsBox.Controls.Add(dataGridView1);
            comboLegsBox.Location = new Point(317, 6);
            comboLegsBox.Name = "comboLegsBox";
            comboLegsBox.Size = new Size(469, 155);
            comboLegsBox.TabIndex = 80;
            comboLegsBox.TabStop = false;
            comboLegsBox.Text = "Combo legs";
            // 
            // dataGridView1
            // 
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { comboLegAction, comboLegRatio, comboLegDescription, comboLegPrice });
            dataGridView1.Location = new Point(6, 19);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.Size = new Size(453, 130);
            dataGridView1.TabIndex = 0;
            // 
            // comboLegAction
            // 
            comboLegAction.HeaderText = "Action";
            comboLegAction.Name = "comboLegAction";
            comboLegAction.Resizable = DataGridViewTriState.True;
            comboLegAction.SortMode = DataGridViewColumnSortMode.Automatic;
            comboLegAction.Width = 50;
            // 
            // comboLegRatio
            // 
            comboLegRatio.HeaderText = "Ratio";
            comboLegRatio.Name = "comboLegRatio";
            comboLegRatio.Width = 50;
            // 
            // comboLegDescription
            // 
            comboLegDescription.HeaderText = "Description";
            comboLegDescription.Name = "comboLegDescription";
            comboLegDescription.Width = 200;
            // 
            // comboLegPrice
            // 
            comboLegPrice.HeaderText = "Price";
            comboLegPrice.Name = "comboLegPrice";
            // 
            // comboContractBox
            // 
            comboContractBox.Controls.Add(findComboContract);
            comboContractBox.Controls.Add(comboSymbolLabel);
            comboContractBox.Controls.Add(comboSymbol);
            comboContractBox.Controls.Add(comboStrike);
            comboContractBox.Controls.Add(comboRightLabel);
            comboContractBox.Controls.Add(comboLastTradeDate);
            comboContractBox.Controls.Add(comboStrikeLabel);
            comboContractBox.Controls.Add(comboCurrency);
            comboContractBox.Controls.Add(comboRight);
            comboContractBox.Controls.Add(comboCurrencyLabel);
            comboContractBox.Controls.Add(comboLastTradeDateLabel);
            comboContractBox.Controls.Add(comboMultiplier);
            comboContractBox.Controls.Add(comboSecType);
            comboContractBox.Controls.Add(comboLocalSymbol);
            comboContractBox.Controls.Add(comboMultiplierLabel);
            comboContractBox.Controls.Add(comboExchange);
            comboContractBox.Controls.Add(comboSecTypeLabel);
            comboContractBox.Controls.Add(comboExchangeLabel);
            comboContractBox.Controls.Add(comboLocalSymbolLabel);
            comboContractBox.Location = new Point(9, 6);
            comboContractBox.Name = "comboContractBox";
            comboContractBox.Size = new Size(293, 155);
            comboContractBox.TabIndex = 79;
            comboContractBox.TabStop = false;
            comboContractBox.Text = "Contract";
            // 
            // findComboContract
            // 
            findComboContract.AutoSize = true;
            findComboContract.Location = new Point(253, 131);
            findComboContract.Name = "findComboContract";
            findComboContract.Size = new Size(30, 15);
            findComboContract.TabIndex = 84;
            findComboContract.TabStop = true;
            findComboContract.Text = "Find";
            findComboContract.LinkClicked += findComboContract_LinkClicked;
            // 
            // comboSymbolLabel
            // 
            comboSymbolLabel.AutoSize = true;
            comboSymbolLabel.Location = new Point(16, 22);
            comboSymbolLabel.Name = "comboSymbolLabel";
            comboSymbolLabel.Size = new Size(47, 15);
            comboSymbolLabel.TabIndex = 61;
            comboSymbolLabel.Text = "Symbol";
            // 
            // comboSymbol
            // 
            comboSymbol.Location = new Point(63, 19);
            comboSymbol.Name = "comboSymbol";
            comboSymbol.Size = new Size(68, 23);
            comboSymbol.TabIndex = 60;
            comboSymbol.Text = "SPY";
            // 
            // comboStrike
            // 
            comboStrike.Location = new Point(213, 71);
            comboStrike.Name = "comboStrike";
            comboStrike.Size = new Size(67, 23);
            comboStrike.TabIndex = 73;
            // 
            // comboRightLabel
            // 
            comboRightLabel.AutoSize = true;
            comboRightLabel.Location = new Point(12, 123);
            comboRightLabel.Name = "comboRightLabel";
            comboRightLabel.Size = new Size(50, 15);
            comboRightLabel.TabIndex = 78;
            comboRightLabel.Text = "Put/Call";
            // 
            // comboLastTradeDate
            // 
            comboLastTradeDate.Location = new Point(213, 45);
            comboLastTradeDate.Name = "comboLastTradeDate";
            comboLastTradeDate.Size = new Size(67, 23);
            comboLastTradeDate.TabIndex = 74;
            comboLastTradeDate.Text = "20130908";
            // 
            // comboStrikeLabel
            // 
            comboStrikeLabel.AutoSize = true;
            comboStrikeLabel.Location = new Point(173, 71);
            comboStrikeLabel.Name = "comboStrikeLabel";
            comboStrikeLabel.Size = new Size(36, 15);
            comboStrikeLabel.TabIndex = 65;
            comboStrikeLabel.Text = "Strike";
            // 
            // comboCurrency
            // 
            comboCurrency.Location = new Point(63, 71);
            comboCurrency.Name = "comboCurrency";
            comboCurrency.Size = new Size(68, 23);
            comboCurrency.TabIndex = 70;
            comboCurrency.Text = "USD";
            // 
            // comboRight
            // 
            comboRight.FormattingEnabled = true;
            comboRight.Location = new Point(63, 123);
            comboRight.Name = "comboRight";
            comboRight.Size = new Size(68, 23);
            comboRight.TabIndex = 77;
            // 
            // comboCurrencyLabel
            // 
            comboCurrencyLabel.AutoSize = true;
            comboCurrencyLabel.Location = new Point(8, 71);
            comboCurrencyLabel.Name = "comboCurrencyLabel";
            comboCurrencyLabel.Size = new Size(55, 15);
            comboCurrencyLabel.TabIndex = 68;
            comboCurrencyLabel.Text = "Currency";
            // 
            // comboLastTradeDateLabel
            // 
            comboLastTradeDateLabel.AutoSize = true;
            comboLastTradeDateLabel.Location = new Point(172, 44);
            comboLastTradeDateLabel.Name = "comboLastTradeDateLabel";
            comboLastTradeDateLabel.Size = new Size(77, 15);
            comboLastTradeDateLabel.TabIndex = 64;
            comboLastTradeDateLabel.Text = "lastTradeDate";
            // 
            // comboMultiplier
            // 
            comboMultiplier.Location = new Point(213, 22);
            comboMultiplier.Name = "comboMultiplier";
            comboMultiplier.Size = new Size(67, 23);
            comboMultiplier.TabIndex = 72;
            // 
            // comboSecType
            // 
            comboSecType.FormattingEnabled = true;
            comboSecType.Items.AddRange(new object[] { "STK", "OPT", "FUT", "CASH", "BOND", "CFD", "FOP", "WAR", "IOPT", "FWD", "BAG", "IND", "BILL", "FUND", "FIXED", "SLB", "NEWS", "CMDTY", "BSK", "ICU", "ICS", "CRYPTO" });
            comboSecType.Location = new Point(63, 44);
            comboSecType.Name = "comboSecType";
            comboSecType.Size = new Size(68, 23);
            comboSecType.TabIndex = 62;
            comboSecType.Text = "STK";
            // 
            // comboLocalSymbol
            // 
            comboLocalSymbol.Location = new Point(213, 97);
            comboLocalSymbol.Name = "comboLocalSymbol";
            comboLocalSymbol.Size = new Size(67, 23);
            comboLocalSymbol.TabIndex = 75;
            // 
            // comboMultiplierLabel
            // 
            comboMultiplierLabel.AutoSize = true;
            comboMultiplierLabel.Location = new Point(159, 22);
            comboMultiplierLabel.Name = "comboMultiplierLabel";
            comboMultiplierLabel.Size = new Size(58, 15);
            comboMultiplierLabel.TabIndex = 66;
            comboMultiplierLabel.Text = "Multiplier";
            // 
            // comboExchange
            // 
            comboExchange.Location = new Point(63, 97);
            comboExchange.Name = "comboExchange";
            comboExchange.Size = new Size(68, 23);
            comboExchange.TabIndex = 71;
            comboExchange.Text = "ARCA";
            // 
            // comboSecTypeLabel
            // 
            comboSecTypeLabel.AutoSize = true;
            comboSecTypeLabel.Location = new Point(7, 44);
            comboSecTypeLabel.Name = "comboSecTypeLabel";
            comboSecTypeLabel.Size = new Size(49, 15);
            comboSecTypeLabel.TabIndex = 63;
            comboSecTypeLabel.Text = "SecType";
            // 
            // comboExchangeLabel
            // 
            comboExchangeLabel.AutoSize = true;
            comboExchangeLabel.Location = new Point(2, 97);
            comboExchangeLabel.Name = "comboExchangeLabel";
            comboExchangeLabel.Size = new Size(58, 15);
            comboExchangeLabel.TabIndex = 67;
            comboExchangeLabel.Text = "Exchange";
            // 
            // comboLocalSymbolLabel
            // 
            comboLocalSymbolLabel.AutoSize = true;
            comboLocalSymbolLabel.Location = new Point(137, 97);
            comboLocalSymbolLabel.Name = "comboLocalSymbolLabel";
            comboLocalSymbolLabel.Size = new Size(78, 15);
            comboLocalSymbolLabel.TabIndex = 69;
            comboLocalSymbolLabel.Text = "Local Symbol";
            // 
            // status_CT
            // 
            status_CT.AutoSize = true;
            status_CT.Location = new Point(55, 166);
            status_CT.Margin = new Padding(4, 0, 4, 0);
            status_CT.Name = "status_CT";
            status_CT.Size = new Size(88, 15);
            status_CT.TabIndex = 9;
            status_CT.Text = "Disconnected...";
            // 
            // status_label_CT
            // 
            status_label_CT.AutoSize = true;
            status_label_CT.Location = new Point(7, 166);
            status_label_CT.Margin = new Padding(4, 0, 4, 0);
            status_label_CT.Name = "status_label_CT";
            status_label_CT.Size = new Size(42, 15);
            status_label_CT.TabIndex = 8;
            status_label_CT.Text = "Status:";
            // 
            // tabControl2
            // 
            tabControl2.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl2.Controls.Add(messagesTab);
            tabControl2.Location = new Point(0, 629);
            tabControl2.Margin = new Padding(0);
            tabControl2.Name = "tabControl2";
            tabControl2.SelectedIndex = 0;
            tabControl2.Size = new Size(1465, 215);
            tabControl2.TabIndex = 8;
            // 
            // messagesTab
            // 
            messagesTab.BackColor = Color.LightGray;
            messagesTab.Controls.Add(messageBoxClear_link);
            messagesTab.Controls.Add(messageBox);
            messagesTab.Controls.Add(status_CT);
            messagesTab.Controls.Add(status_label_CT);
            messagesTab.Location = new Point(4, 24);
            messagesTab.Margin = new Padding(4, 3, 4, 3);
            messagesTab.Name = "messagesTab";
            messagesTab.Padding = new Padding(4, 3, 4, 3);
            messagesTab.Size = new Size(1457, 187);
            messagesTab.TabIndex = 0;
            messagesTab.Text = "Messages";
            // 
            // messageBoxClear_link
            // 
            messageBoxClear_link.AutoSize = true;
            messageBoxClear_link.Location = new Point(7, 2);
            messageBoxClear_link.Margin = new Padding(4, 0, 4, 0);
            messageBoxClear_link.Name = "messageBoxClear_link";
            messageBoxClear_link.Size = new Size(34, 15);
            messageBoxClear_link.TabIndex = 11;
            messageBoxClear_link.TabStop = true;
            messageBoxClear_link.Text = "Clear";
            messageBoxClear_link.LinkClicked += messageBoxClear_link_LinkClicked;
            // 
            // messageBox
            // 
            messageBox.AcceptsReturn = true;
            messageBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            messageBox.Location = new Point(7, 21);
            messageBox.Margin = new Padding(4, 3, 4, 3);
            messageBox.Multiline = true;
            messageBox.Name = "messageBox";
            messageBox.ReadOnly = true;
            messageBox.ScrollBars = ScrollBars.Vertical;
            messageBox.Size = new Size(1441, 141);
            messageBox.TabIndex = 10;
            // 
            // informationTooltip
            // 
            informationTooltip.ToolTipIcon = ToolTipIcon.Info;
            // 
            // buttonReqNewsProviders
            // 
            buttonReqNewsProviders.Location = new Point(10, 14);
            buttonReqNewsProviders.Margin = new Padding(4, 3, 4, 3);
            buttonReqNewsProviders.Name = "buttonReqNewsProviders";
            buttonReqNewsProviders.Size = new Size(150, 27);
            buttonReqNewsProviders.TabIndex = 35;
            buttonReqNewsProviders.Text = "Req News Providers";
            informationTooltip.SetToolTip(buttonReqNewsProviders, "Looks for all contracts matching the description provided.");
            buttonReqNewsProviders.UseMnemonic = false;
            buttonReqNewsProviders.UseVisualStyleBackColor = true;
            buttonReqNewsProviders.Click += buttonReqNewsProviders_Click;
            // 
            // buttonReqNewsTicks
            // 
            buttonReqNewsTicks.Location = new Point(224, 81);
            buttonReqNewsTicks.Margin = new Padding(4, 3, 4, 3);
            buttonReqNewsTicks.Name = "buttonReqNewsTicks";
            buttonReqNewsTicks.Size = new Size(133, 27);
            buttonReqNewsTicks.TabIndex = 34;
            buttonReqNewsTicks.Text = "Req News Ticks";
            informationTooltip.SetToolTip(buttonReqNewsTicks, "Looks for all contracts matching the description provided.");
            buttonReqNewsTicks.UseMnemonic = false;
            buttonReqNewsTicks.UseVisualStyleBackColor = true;
            buttonReqNewsTicks.Click += buttonReqNewsTicks_Click;
            // 
            // buttonCancelNewsTicks
            // 
            buttonCancelNewsTicks.Location = new Point(224, 114);
            buttonCancelNewsTicks.Margin = new Padding(4, 3, 4, 3);
            buttonCancelNewsTicks.Name = "buttonCancelNewsTicks";
            buttonCancelNewsTicks.Size = new Size(133, 27);
            buttonCancelNewsTicks.TabIndex = 37;
            buttonCancelNewsTicks.Text = "Cancel News Ticks";
            informationTooltip.SetToolTip(buttonCancelNewsTicks, "Looks for all contracts matching the description provided.");
            buttonCancelNewsTicks.UseMnemonic = false;
            buttonCancelNewsTicks.UseVisualStyleBackColor = true;
            buttonCancelNewsTicks.Click += buttonCancelNewsTicks_Click;
            // 
            // searchContractDetails
            // 
            searchContractDetails.Location = new Point(360, 166);
            searchContractDetails.Margin = new Padding(4, 3, 4, 3);
            searchContractDetails.Name = "searchContractDetails";
            searchContractDetails.Size = new Size(88, 27);
            searchContractDetails.TabIndex = 21;
            searchContractDetails.Text = "Search";
            informationTooltip.SetToolTip(searchContractDetails, "Looks for all contracts matching the description provided.");
            searchContractDetails.UseMnemonic = false;
            searchContractDetails.UseVisualStyleBackColor = true;
            searchContractDetails.Click += searchContractDetails_Click;
            // 
            // requestMatchingSymbolsCD
            // 
            requestMatchingSymbolsCD.Location = new Point(246, 166);
            requestMatchingSymbolsCD.Margin = new Padding(4, 3, 4, 3);
            requestMatchingSymbolsCD.Name = "requestMatchingSymbolsCD";
            requestMatchingSymbolsCD.Size = new Size(88, 27);
            requestMatchingSymbolsCD.TabIndex = 20;
            requestMatchingSymbolsCD.Text = "Match Symb";
            informationTooltip.SetToolTip(requestMatchingSymbolsCD, "Looks for all contracts matching the description provided.");
            requestMatchingSymbolsCD.UseVisualStyleBackColor = true;
            requestMatchingSymbolsCD.Click += requestMatchingSymbolsContractInfo_Click;
            // 
            // fundamentalsQueryButton
            // 
            fundamentalsQueryButton.Location = new Point(140, 50);
            fundamentalsQueryButton.Margin = new Padding(4, 3, 4, 3);
            fundamentalsQueryButton.Name = "fundamentalsQueryButton";
            fundamentalsQueryButton.Size = new Size(88, 27);
            fundamentalsQueryButton.TabIndex = 2;
            fundamentalsQueryButton.Text = "Query";
            informationTooltip.SetToolTip(fundamentalsQueryButton, "Requests Reuter's Fundamentals selected report for the given contract.");
            fundamentalsQueryButton.UseVisualStyleBackColor = true;
            fundamentalsQueryButton.Click += fundamentalsQueryButton_Click;
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(queryOptionChain);
            groupBox3.Controls.Add(optionChainUseSnapshot);
            groupBox3.Controls.Add(optionChainOptionExchangeLabel);
            groupBox3.Controls.Add(optionChainExchange);
            groupBox3.Location = new Point(496, 7);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(238, 110);
            groupBox3.TabIndex = 1;
            groupBox3.TabStop = false;
            groupBox3.Text = "Options chain";
            informationTooltip.SetToolTip(groupBox3, "Requests all options available for the description provided on the Contract's details section.");
            // 
            // queryOptionChain
            // 
            queryOptionChain.Location = new Point(140, 76);
            queryOptionChain.Margin = new Padding(4, 3, 4, 3);
            queryOptionChain.Name = "queryOptionChain";
            queryOptionChain.Size = new Size(88, 27);
            queryOptionChain.TabIndex = 3;
            queryOptionChain.Text = "Request";
            informationTooltip.SetToolTip(queryOptionChain, "Requests all options available for the underlying provided on the Contract's details section.");
            queryOptionChain.UseVisualStyleBackColor = true;
            queryOptionChain.Click += queryOptionChain_Click;
            // 
            // optionChainUseSnapshot
            // 
            optionChainUseSnapshot.AutoSize = true;
            optionChainUseSnapshot.CheckAlign = ContentAlignment.MiddleRight;
            optionChainUseSnapshot.Location = new Point(43, 48);
            optionChainUseSnapshot.Margin = new Padding(4, 3, 4, 3);
            optionChainUseSnapshot.Name = "optionChainUseSnapshot";
            optionChainUseSnapshot.Size = new Size(122, 19);
            optionChainUseSnapshot.TabIndex = 2;
            optionChainUseSnapshot.Text = "Use snapshot data";
            optionChainUseSnapshot.UseVisualStyleBackColor = true;
            // 
            // optionChainOptionExchangeLabel
            // 
            optionChainOptionExchangeLabel.AutoSize = true;
            optionChainOptionExchangeLabel.Location = new Point(40, 22);
            optionChainOptionExchangeLabel.Margin = new Padding(4, 0, 4, 0);
            optionChainOptionExchangeLabel.Name = "optionChainOptionExchangeLabel";
            optionChainOptionExchangeLabel.Size = new Size(58, 15);
            optionChainOptionExchangeLabel.TabIndex = 0;
            optionChainOptionExchangeLabel.Text = "Exchange";
            // 
            // optionChainExchange
            // 
            optionChainExchange.Location = new Point(111, 18);
            optionChainExchange.Margin = new Padding(4, 3, 4, 3);
            optionChainExchange.Name = "optionChainExchange";
            optionChainExchange.Size = new Size(116, 23);
            optionChainExchange.TabIndex = 1;
            optionChainExchange.Text = "SMART";
            // 
            // groupBox5
            // 
            groupBox5.Controls.Add(label14);
            groupBox5.Controls.Add(underlyingConId);
            groupBox5.Controls.Add(queryOptionParams);
            groupBox5.Location = new Point(741, 7);
            groupBox5.Margin = new Padding(4, 3, 4, 3);
            groupBox5.Name = "groupBox5";
            groupBox5.Padding = new Padding(4, 3, 4, 3);
            groupBox5.Size = new Size(217, 110);
            groupBox5.TabIndex = 3;
            groupBox5.TabStop = false;
            groupBox5.Text = "Option parameters";
            informationTooltip.SetToolTip(groupBox5, "Requests all options available for the description provided on the Contract's details section.");
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(12, 25);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(39, 15);
            label14.TabIndex = 0;
            label14.Text = "ConId";
            // 
            // underlyingConId
            // 
            underlyingConId.Location = new Point(83, 22);
            underlyingConId.Margin = new Padding(4, 3, 4, 3);
            underlyingConId.Name = "underlyingConId";
            underlyingConId.Size = new Size(116, 23);
            underlyingConId.TabIndex = 1;
            // 
            // queryOptionParams
            // 
            queryOptionParams.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            queryOptionParams.Location = new Point(119, 76);
            queryOptionParams.Margin = new Padding(4, 3, 4, 3);
            queryOptionParams.Name = "queryOptionParams";
            queryOptionParams.Size = new Size(88, 27);
            queryOptionParams.TabIndex = 2;
            queryOptionParams.Text = "Request";
            informationTooltip.SetToolTip(queryOptionParams, "Requests security definition option parameters");
            queryOptionParams.UseVisualStyleBackColor = true;
            queryOptionParams.Click += queryOptionParams_Click;
            // 
            // groupBoxMarketRule
            // 
            groupBoxMarketRule.Controls.Add(comboBoxMarketRuleId);
            groupBoxMarketRule.Controls.Add(labelMarketRuleId);
            groupBoxMarketRule.Controls.Add(buttonReqMarketRule);
            groupBoxMarketRule.Location = new Point(965, 7);
            groupBoxMarketRule.Margin = new Padding(4, 3, 4, 3);
            groupBoxMarketRule.Name = "groupBoxMarketRule";
            groupBoxMarketRule.Padding = new Padding(4, 3, 4, 3);
            groupBoxMarketRule.Size = new Size(217, 110);
            groupBoxMarketRule.TabIndex = 5;
            groupBoxMarketRule.TabStop = false;
            groupBoxMarketRule.Text = "Market Rule";
            informationTooltip.SetToolTip(groupBoxMarketRule, "Requests all options available for the description provided on the Contract's details section.");
            // 
            // comboBoxMarketRuleId
            // 
            comboBoxMarketRuleId.FormattingEnabled = true;
            comboBoxMarketRuleId.Location = new Point(115, 21);
            comboBoxMarketRuleId.Margin = new Padding(4, 3, 4, 3);
            comboBoxMarketRuleId.Name = "comboBoxMarketRuleId";
            comboBoxMarketRuleId.Size = new Size(90, 23);
            comboBoxMarketRuleId.TabIndex = 1;
            // 
            // labelMarketRuleId
            // 
            labelMarketRuleId.AutoSize = true;
            labelMarketRuleId.Location = new Point(12, 25);
            labelMarketRuleId.Margin = new Padding(4, 0, 4, 0);
            labelMarketRuleId.Name = "labelMarketRuleId";
            labelMarketRuleId.Size = new Size(83, 15);
            labelMarketRuleId.TabIndex = 0;
            labelMarketRuleId.Text = "Market Rule Id";
            // 
            // buttonReqMarketRule
            // 
            buttonReqMarketRule.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonReqMarketRule.Location = new Point(20, 76);
            buttonReqMarketRule.Margin = new Padding(4, 3, 4, 3);
            buttonReqMarketRule.Name = "buttonReqMarketRule";
            buttonReqMarketRule.Size = new Size(187, 27);
            buttonReqMarketRule.TabIndex = 2;
            buttonReqMarketRule.Text = "Request Market Rule";
            informationTooltip.SetToolTip(buttonReqMarketRule, "Request market rule");
            buttonReqMarketRule.UseVisualStyleBackColor = true;
            buttonReqMarketRule.Click += buttonReqMarketRule_Click;
            // 
            // buttonAdditionalForm
            // 
            buttonAdditionalForm.Location = new Point(597, 11);
            buttonAdditionalForm.Margin = new Padding(4, 3, 4, 3);
            buttonAdditionalForm.Name = "buttonAdditionalForm";
            buttonAdditionalForm.Size = new Size(161, 27);
            buttonAdditionalForm.TabIndex = 12;
            buttonAdditionalForm.Text = "Additional options";
            informationTooltip.SetToolTip(buttonAdditionalForm, "Connects to TWS or IB Gateway.");
            buttonAdditionalForm.UseVisualStyleBackColor = true;
            buttonAdditionalForm.Click += buttonAdditionalForm_Click;
            // 
            // ib_banner
            // 
            ib_banner.Image = (Image)resources.GetObject("ib_banner.Image");
            ib_banner.Location = new Point(5, 5);
            ib_banner.Margin = new Padding(4, 3, 4, 3);
            ib_banner.Name = "ib_banner";
            ib_banner.Size = new Size(278, 37);
            ib_banner.TabIndex = 9;
            ib_banner.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(597, 50);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(783, 15);
            label7.TabIndex = 10;
            label7.Text = "Live Trading ports: TWS: 7496; IB Gateway: 4001. Simulated Trading ports for new installations of version 954.1 or newer:  TWS: 7497; IB Gateway: 4002";
            // 
            // newsTab
            // 
            newsTab.BackColor = Color.LightGray;
            newsTab.Controls.Add(tabControlNewsResults);
            newsTab.Controls.Add(tabControlNews);
            newsTab.Location = new Point(4, 24);
            newsTab.Margin = new Padding(4, 3, 4, 3);
            newsTab.Name = "newsTab";
            newsTab.Padding = new Padding(4, 3, 4, 3);
            newsTab.Size = new Size(1457, 519);
            newsTab.TabIndex = 9;
            newsTab.Text = "News";
            // 
            // tabControlNewsResults
            // 
            tabControlNewsResults.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControlNewsResults.Controls.Add(tabPageTickNewsResults);
            tabControlNewsResults.Controls.Add(tabPageNewsProvidersResults);
            tabControlNewsResults.Controls.Add(tabPageNewsArticleResults);
            tabControlNewsResults.Controls.Add(tabPageHistoricalNewsResults);
            tabControlNewsResults.Location = new Point(0, 239);
            tabControlNewsResults.Margin = new Padding(0);
            tabControlNewsResults.Name = "tabControlNewsResults";
            tabControlNewsResults.SelectedIndex = 0;
            tabControlNewsResults.Size = new Size(1449, 271);
            tabControlNewsResults.TabIndex = 2;
            // 
            // tabPageTickNewsResults
            // 
            tabPageTickNewsResults.BackColor = Color.LightGray;
            tabPageTickNewsResults.Controls.Add(dataGridViewNewsTicks);
            tabPageTickNewsResults.Controls.Add(linkLabelNewsTicksClear);
            tabPageTickNewsResults.Location = new Point(4, 24);
            tabPageTickNewsResults.Margin = new Padding(4, 3, 4, 3);
            tabPageTickNewsResults.Name = "tabPageTickNewsResults";
            tabPageTickNewsResults.Size = new Size(1441, 243);
            tabPageTickNewsResults.TabIndex = 2;
            tabPageTickNewsResults.Text = "News Ticks";
            // 
            // dataGridViewNewsTicks
            // 
            dataGridViewNewsTicks.AllowUserToAddRows = false;
            dataGridViewNewsTicks.AllowUserToDeleteRows = false;
            dataGridViewNewsTicks.AllowUserToOrderColumns = true;
            dataGridViewNewsTicks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewNewsTicks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNewsTicks.Columns.AddRange(new DataGridViewColumn[] { dataGridViewNewsTicksTimeStamp, dataGridViewNewsTicksProviderCode, dataGridViewNewsTicksArticleId, dataGridViewHeadline, dataGridViewNewsTicksExtraData });
            dataGridViewNewsTicks.Location = new Point(5, 23);
            dataGridViewNewsTicks.Margin = new Padding(4, 3, 4, 3);
            dataGridViewNewsTicks.Name = "dataGridViewNewsTicks";
            dataGridViewNewsTicks.ReadOnly = true;
            dataGridViewNewsTicks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNewsTicks.Size = new Size(1429, 210);
            dataGridViewNewsTicks.TabIndex = 3;
            dataGridViewNewsTicks.Visible = false;
            dataGridViewNewsTicks.CellClick += dataGridViewNewsTicks_CellClick;
            // 
            // dataGridViewNewsTicksTimeStamp
            // 
            dataGridViewNewsTicksTimeStamp.HeaderText = "Time Stamp";
            dataGridViewNewsTicksTimeStamp.Name = "dataGridViewNewsTicksTimeStamp";
            dataGridViewNewsTicksTimeStamp.ReadOnly = true;
            dataGridViewNewsTicksTimeStamp.Width = 150;
            // 
            // dataGridViewNewsTicksProviderCode
            // 
            dataGridViewNewsTicksProviderCode.HeaderText = "Provider Code";
            dataGridViewNewsTicksProviderCode.Name = "dataGridViewNewsTicksProviderCode";
            dataGridViewNewsTicksProviderCode.ReadOnly = true;
            // 
            // dataGridViewNewsTicksArticleId
            // 
            dataGridViewNewsTicksArticleId.HeaderText = "Article Id";
            dataGridViewNewsTicksArticleId.Name = "dataGridViewNewsTicksArticleId";
            dataGridViewNewsTicksArticleId.ReadOnly = true;
            dataGridViewNewsTicksArticleId.Width = 120;
            // 
            // dataGridViewHeadline
            // 
            dataGridViewHeadline.HeaderText = "Headline";
            dataGridViewHeadline.Name = "dataGridViewHeadline";
            dataGridViewHeadline.ReadOnly = true;
            dataGridViewHeadline.Width = 700;
            // 
            // dataGridViewNewsTicksExtraData
            // 
            dataGridViewNewsTicksExtraData.HeaderText = "Extra Data";
            dataGridViewNewsTicksExtraData.Name = "dataGridViewNewsTicksExtraData";
            dataGridViewNewsTicksExtraData.ReadOnly = true;
            // 
            // linkLabelNewsTicksClear
            // 
            linkLabelNewsTicksClear.AutoSize = true;
            linkLabelNewsTicksClear.Location = new Point(4, 5);
            linkLabelNewsTicksClear.Margin = new Padding(4, 0, 4, 0);
            linkLabelNewsTicksClear.Name = "linkLabelNewsTicksClear";
            linkLabelNewsTicksClear.Size = new Size(34, 15);
            linkLabelNewsTicksClear.TabIndex = 2;
            linkLabelNewsTicksClear.TabStop = true;
            linkLabelNewsTicksClear.Text = "Clear";
            linkLabelNewsTicksClear.LinkClicked += linkLabelNewsTicksClear_LinkClicked;
            // 
            // tabPageNewsProvidersResults
            // 
            tabPageNewsProvidersResults.BackColor = Color.LightGray;
            tabPageNewsProvidersResults.Controls.Add(dataGridViewNewsProviders);
            tabPageNewsProvidersResults.Controls.Add(linkLabelClearNewsProviders);
            tabPageNewsProvidersResults.Location = new Point(4, 24);
            tabPageNewsProvidersResults.Margin = new Padding(4, 3, 4, 3);
            tabPageNewsProvidersResults.Name = "tabPageNewsProvidersResults";
            tabPageNewsProvidersResults.Size = new Size(1441, 243);
            tabPageNewsProvidersResults.TabIndex = 3;
            tabPageNewsProvidersResults.Text = "News Providers";
            // 
            // dataGridViewNewsProviders
            // 
            dataGridViewNewsProviders.AllowUserToAddRows = false;
            dataGridViewNewsProviders.AllowUserToDeleteRows = false;
            dataGridViewNewsProviders.AllowUserToOrderColumns = true;
            dataGridViewNewsProviders.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewNewsProviders.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewNewsProviders.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxNewsProvidersProviderCode, dataGridViewTextBoxNewsProvidersProviderName });
            dataGridViewNewsProviders.Location = new Point(6, 25);
            dataGridViewNewsProviders.Margin = new Padding(4, 3, 4, 3);
            dataGridViewNewsProviders.Name = "dataGridViewNewsProviders";
            dataGridViewNewsProviders.ReadOnly = true;
            dataGridViewNewsProviders.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewNewsProviders.Size = new Size(1429, 210);
            dataGridViewNewsProviders.TabIndex = 3;
            dataGridViewNewsProviders.Visible = false;
            // 
            // dataGridViewTextBoxNewsProvidersProviderCode
            // 
            dataGridViewTextBoxNewsProvidersProviderCode.HeaderText = "Provider Code";
            dataGridViewTextBoxNewsProvidersProviderCode.Name = "dataGridViewTextBoxNewsProvidersProviderCode";
            dataGridViewTextBoxNewsProvidersProviderCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxNewsProvidersProviderName
            // 
            dataGridViewTextBoxNewsProvidersProviderName.HeaderText = "Provider Name";
            dataGridViewTextBoxNewsProvidersProviderName.Name = "dataGridViewTextBoxNewsProvidersProviderName";
            dataGridViewTextBoxNewsProvidersProviderName.ReadOnly = true;
            dataGridViewTextBoxNewsProvidersProviderName.Width = 500;
            // 
            // linkLabelClearNewsProviders
            // 
            linkLabelClearNewsProviders.AutoSize = true;
            linkLabelClearNewsProviders.Location = new Point(8, 3);
            linkLabelClearNewsProviders.Margin = new Padding(4, 0, 4, 0);
            linkLabelClearNewsProviders.Name = "linkLabelClearNewsProviders";
            linkLabelClearNewsProviders.Size = new Size(34, 15);
            linkLabelClearNewsProviders.TabIndex = 2;
            linkLabelClearNewsProviders.TabStop = true;
            linkLabelClearNewsProviders.Text = "Clear";
            linkLabelClearNewsProviders.LinkClicked += linkLabelClearNewsProviders_LinkClicked;
            // 
            // tabPageNewsArticleResults
            // 
            tabPageNewsArticleResults.BackColor = Color.LightGray;
            tabPageNewsArticleResults.Controls.Add(textBoxNewsArticle);
            tabPageNewsArticleResults.Controls.Add(linkLabelClearNewsArticle);
            tabPageNewsArticleResults.Location = new Point(4, 24);
            tabPageNewsArticleResults.Margin = new Padding(4, 3, 4, 3);
            tabPageNewsArticleResults.Name = "tabPageNewsArticleResults";
            tabPageNewsArticleResults.Size = new Size(1441, 243);
            tabPageNewsArticleResults.TabIndex = 1;
            tabPageNewsArticleResults.Text = "News Article";
            // 
            // textBoxNewsArticle
            // 
            textBoxNewsArticle.BackColor = SystemColors.Control;
            textBoxNewsArticle.Location = new Point(6, 23);
            textBoxNewsArticle.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsArticle.Multiline = true;
            textBoxNewsArticle.Name = "textBoxNewsArticle";
            textBoxNewsArticle.ReadOnly = true;
            textBoxNewsArticle.ScrollBars = ScrollBars.Vertical;
            textBoxNewsArticle.Size = new Size(1427, 214);
            textBoxNewsArticle.TabIndex = 3;
            // 
            // linkLabelClearNewsArticle
            // 
            linkLabelClearNewsArticle.AutoSize = true;
            linkLabelClearNewsArticle.Location = new Point(8, 5);
            linkLabelClearNewsArticle.Margin = new Padding(4, 0, 4, 0);
            linkLabelClearNewsArticle.Name = "linkLabelClearNewsArticle";
            linkLabelClearNewsArticle.Size = new Size(34, 15);
            linkLabelClearNewsArticle.TabIndex = 2;
            linkLabelClearNewsArticle.TabStop = true;
            linkLabelClearNewsArticle.Text = "Clear";
            linkLabelClearNewsArticle.LinkClicked += linkLabelClearNewsArticle_LinkClicked_1;
            // 
            // tabPageHistoricalNewsResults
            // 
            tabPageHistoricalNewsResults.BackColor = Color.LightGray;
            tabPageHistoricalNewsResults.Controls.Add(linkLabelClearHistoricalNews);
            tabPageHistoricalNewsResults.Controls.Add(dataGridViewHistoricalNews);
            tabPageHistoricalNewsResults.Location = new Point(4, 24);
            tabPageHistoricalNewsResults.Margin = new Padding(4, 3, 4, 3);
            tabPageHistoricalNewsResults.Name = "tabPageHistoricalNewsResults";
            tabPageHistoricalNewsResults.Padding = new Padding(4, 3, 4, 3);
            tabPageHistoricalNewsResults.Size = new Size(1441, 243);
            tabPageHistoricalNewsResults.TabIndex = 0;
            tabPageHistoricalNewsResults.Text = "Historical News";
            // 
            // linkLabelClearHistoricalNews
            // 
            linkLabelClearHistoricalNews.AutoSize = true;
            linkLabelClearHistoricalNews.Location = new Point(7, 3);
            linkLabelClearHistoricalNews.Margin = new Padding(4, 0, 4, 0);
            linkLabelClearHistoricalNews.Name = "linkLabelClearHistoricalNews";
            linkLabelClearHistoricalNews.Size = new Size(34, 15);
            linkLabelClearHistoricalNews.TabIndex = 1;
            linkLabelClearHistoricalNews.TabStop = true;
            linkLabelClearHistoricalNews.Text = "Clear";
            linkLabelClearHistoricalNews.LinkClicked += linkLabelClearHistoricalNews_LinkClicked;
            // 
            // dataGridViewHistoricalNews
            // 
            dataGridViewHistoricalNews.AllowUserToAddRows = false;
            dataGridViewHistoricalNews.AllowUserToDeleteRows = false;
            dataGridViewHistoricalNews.AllowUserToOrderColumns = true;
            dataGridViewHistoricalNews.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewHistoricalNews.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistoricalNews.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxTime, dataGridViewTextBoxProviderCode, dataGridViewTextBoxArticleId, dataGridViewTextBoxHeadline });
            dataGridViewHistoricalNews.Location = new Point(4, 22);
            dataGridViewHistoricalNews.Margin = new Padding(4, 3, 4, 3);
            dataGridViewHistoricalNews.Name = "dataGridViewHistoricalNews";
            dataGridViewHistoricalNews.ReadOnly = true;
            dataGridViewHistoricalNews.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHistoricalNews.Size = new Size(1429, 210);
            dataGridViewHistoricalNews.TabIndex = 0;
            dataGridViewHistoricalNews.Visible = false;
            dataGridViewHistoricalNews.CellClick += dataGridViewHistoricalNews_CellClick;
            // 
            // dataGridViewTextBoxTime
            // 
            dataGridViewTextBoxTime.HeaderText = "Time";
            dataGridViewTextBoxTime.Name = "dataGridViewTextBoxTime";
            dataGridViewTextBoxTime.ReadOnly = true;
            dataGridViewTextBoxTime.Width = 150;
            // 
            // dataGridViewTextBoxProviderCode
            // 
            dataGridViewTextBoxProviderCode.HeaderText = "Provider Code";
            dataGridViewTextBoxProviderCode.Name = "dataGridViewTextBoxProviderCode";
            dataGridViewTextBoxProviderCode.ReadOnly = true;
            // 
            // dataGridViewTextBoxArticleId
            // 
            dataGridViewTextBoxArticleId.HeaderText = "Article Id";
            dataGridViewTextBoxArticleId.Name = "dataGridViewTextBoxArticleId";
            dataGridViewTextBoxArticleId.ReadOnly = true;
            dataGridViewTextBoxArticleId.Width = 120;
            // 
            // dataGridViewTextBoxHeadline
            // 
            dataGridViewTextBoxHeadline.HeaderText = "Headline";
            dataGridViewTextBoxHeadline.Name = "dataGridViewTextBoxHeadline";
            dataGridViewTextBoxHeadline.ReadOnly = true;
            dataGridViewTextBoxHeadline.Width = 700;
            // 
            // tabControlNews
            // 
            tabControlNews.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            tabControlNews.Controls.Add(tabPageTickNews);
            tabControlNews.Controls.Add(tabPageNewsProviders);
            tabControlNews.Controls.Add(tabPageNewsArticle);
            tabControlNews.Controls.Add(tabPageHistoricalNews);
            tabControlNews.Location = new Point(0, 0);
            tabControlNews.Margin = new Padding(4, 3, 4, 3);
            tabControlNews.Name = "tabControlNews";
            tabControlNews.SelectedIndex = 0;
            tabControlNews.Size = new Size(1444, 240);
            tabControlNews.TabIndex = 1;
            // 
            // tabPageTickNews
            // 
            tabPageTickNews.BackColor = Color.LightGray;
            tabPageTickNews.Controls.Add(groupBoxNewsTicks);
            tabPageTickNews.Location = new Point(4, 24);
            tabPageTickNews.Margin = new Padding(4, 3, 4, 3);
            tabPageTickNews.Name = "tabPageTickNews";
            tabPageTickNews.Size = new Size(1436, 212);
            tabPageTickNews.TabIndex = 2;
            tabPageTickNews.Text = "News Ticks";
            // 
            // groupBoxNewsTicks
            // 
            groupBoxNewsTicks.Controls.Add(buttonCancelNewsTicks);
            groupBoxNewsTicks.Controls.Add(textBoxNewsTicksPrimExchange);
            groupBoxNewsTicks.Controls.Add(labelNewsTicksPrimExchange);
            groupBoxNewsTicks.Controls.Add(buttonReqNewsTicks);
            groupBoxNewsTicks.Controls.Add(labelNewsTicksSymbol);
            groupBoxNewsTicks.Controls.Add(comboBoxNewsTicksSecType);
            groupBoxNewsTicks.Controls.Add(labelNewsTicksSecType);
            groupBoxNewsTicks.Controls.Add(labelNewsTicksExchange);
            groupBoxNewsTicks.Controls.Add(textBoxNewsTicksExchange);
            groupBoxNewsTicks.Controls.Add(labelNewsTicksCurrency);
            groupBoxNewsTicks.Controls.Add(textBoxNewsTicksCurrency);
            groupBoxNewsTicks.Controls.Add(textBoxNewsTicksSymbol);
            groupBoxNewsTicks.Location = new Point(0, 3);
            groupBoxNewsTicks.Margin = new Padding(4, 3, 4, 3);
            groupBoxNewsTicks.Name = "groupBoxNewsTicks";
            groupBoxNewsTicks.Padding = new Padding(4, 3, 4, 3);
            groupBoxNewsTicks.Size = new Size(370, 180);
            groupBoxNewsTicks.TabIndex = 34;
            groupBoxNewsTicks.TabStop = false;
            groupBoxNewsTicks.Text = "Contract Details";
            // 
            // textBoxNewsTicksPrimExchange
            // 
            textBoxNewsTicksPrimExchange.Location = new Point(100, 138);
            textBoxNewsTicksPrimExchange.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsTicksPrimExchange.Name = "textBoxNewsTicksPrimExchange";
            textBoxNewsTicksPrimExchange.Size = new Size(116, 23);
            textBoxNewsTicksPrimExchange.TabIndex = 36;
            // 
            // labelNewsTicksPrimExchange
            // 
            labelNewsTicksPrimExchange.AutoSize = true;
            labelNewsTicksPrimExchange.Location = new Point(26, 147);
            labelNewsTicksPrimExchange.Margin = new Padding(4, 0, 4, 0);
            labelNewsTicksPrimExchange.Name = "labelNewsTicksPrimExchange";
            labelNewsTicksPrimExchange.Size = new Size(60, 15);
            labelNewsTicksPrimExchange.TabIndex = 35;
            labelNewsTicksPrimExchange.Text = "Prim Exch";
            // 
            // labelNewsTicksSymbol
            // 
            labelNewsTicksSymbol.AutoSize = true;
            labelNewsTicksSymbol.Location = new Point(26, 27);
            labelNewsTicksSymbol.Margin = new Padding(4, 0, 4, 0);
            labelNewsTicksSymbol.Name = "labelNewsTicksSymbol";
            labelNewsTicksSymbol.Size = new Size(47, 15);
            labelNewsTicksSymbol.TabIndex = 17;
            labelNewsTicksSymbol.Text = "Symbol";
            // 
            // comboBoxNewsTicksSecType
            // 
            comboBoxNewsTicksSecType.FormattingEnabled = true;
            comboBoxNewsTicksSecType.Items.AddRange(new object[] { "STK", "CASH", "IND", "NEWS" });
            comboBoxNewsTicksSecType.Location = new Point(100, 51);
            comboBoxNewsTicksSecType.Margin = new Padding(4, 3, 4, 3);
            comboBoxNewsTicksSecType.Name = "comboBoxNewsTicksSecType";
            comboBoxNewsTicksSecType.Size = new Size(116, 23);
            comboBoxNewsTicksSecType.TabIndex = 18;
            comboBoxNewsTicksSecType.Text = "STK";
            // 
            // labelNewsTicksSecType
            // 
            labelNewsTicksSecType.AutoSize = true;
            labelNewsTicksSecType.Location = new Point(26, 57);
            labelNewsTicksSecType.Margin = new Padding(4, 0, 4, 0);
            labelNewsTicksSecType.Name = "labelNewsTicksSecType";
            labelNewsTicksSecType.Size = new Size(49, 15);
            labelNewsTicksSecType.TabIndex = 19;
            labelNewsTicksSecType.Text = "SecType";
            // 
            // labelNewsTicksExchange
            // 
            labelNewsTicksExchange.AutoSize = true;
            labelNewsTicksExchange.Location = new Point(26, 117);
            labelNewsTicksExchange.Margin = new Padding(4, 0, 4, 0);
            labelNewsTicksExchange.Name = "labelNewsTicksExchange";
            labelNewsTicksExchange.Size = new Size(58, 15);
            labelNewsTicksExchange.TabIndex = 23;
            labelNewsTicksExchange.Text = "Exchange";
            // 
            // textBoxNewsTicksExchange
            // 
            textBoxNewsTicksExchange.Location = new Point(100, 110);
            textBoxNewsTicksExchange.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsTicksExchange.Name = "textBoxNewsTicksExchange";
            textBoxNewsTicksExchange.Size = new Size(116, 23);
            textBoxNewsTicksExchange.TabIndex = 27;
            textBoxNewsTicksExchange.Text = "SMART";
            // 
            // labelNewsTicksCurrency
            // 
            labelNewsTicksCurrency.AutoSize = true;
            labelNewsTicksCurrency.Location = new Point(26, 87);
            labelNewsTicksCurrency.Margin = new Padding(4, 0, 4, 0);
            labelNewsTicksCurrency.Name = "labelNewsTicksCurrency";
            labelNewsTicksCurrency.Size = new Size(55, 15);
            labelNewsTicksCurrency.TabIndex = 24;
            labelNewsTicksCurrency.Text = "Currency";
            // 
            // textBoxNewsTicksCurrency
            // 
            textBoxNewsTicksCurrency.Location = new Point(100, 81);
            textBoxNewsTicksCurrency.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsTicksCurrency.Name = "textBoxNewsTicksCurrency";
            textBoxNewsTicksCurrency.Size = new Size(116, 23);
            textBoxNewsTicksCurrency.TabIndex = 26;
            textBoxNewsTicksCurrency.Text = "USD";
            // 
            // textBoxNewsTicksSymbol
            // 
            textBoxNewsTicksSymbol.Location = new Point(100, 22);
            textBoxNewsTicksSymbol.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsTicksSymbol.Name = "textBoxNewsTicksSymbol";
            textBoxNewsTicksSymbol.Size = new Size(116, 23);
            textBoxNewsTicksSymbol.TabIndex = 16;
            textBoxNewsTicksSymbol.Text = "IBKR";
            // 
            // tabPageNewsProviders
            // 
            tabPageNewsProviders.BackColor = Color.LightGray;
            tabPageNewsProviders.Controls.Add(buttonReqNewsProviders);
            tabPageNewsProviders.Location = new Point(4, 24);
            tabPageNewsProviders.Margin = new Padding(4, 3, 4, 3);
            tabPageNewsProviders.Name = "tabPageNewsProviders";
            tabPageNewsProviders.Size = new Size(1436, 212);
            tabPageNewsProviders.TabIndex = 3;
            tabPageNewsProviders.Text = "News Providers";
            // 
            // tabPageNewsArticle
            // 
            tabPageNewsArticle.BackColor = Color.LightGray;
            tabPageNewsArticle.Controls.Add(groupBoxNewsArticle);
            tabPageNewsArticle.Location = new Point(4, 24);
            tabPageNewsArticle.Margin = new Padding(4, 3, 4, 3);
            tabPageNewsArticle.Name = "tabPageNewsArticle";
            tabPageNewsArticle.Size = new Size(1436, 212);
            tabPageNewsArticle.TabIndex = 1;
            tabPageNewsArticle.Text = "News Article";
            // 
            // groupBoxNewsArticle
            // 
            groupBoxNewsArticle.Controls.Add(buttonPdfPathDialog);
            groupBoxNewsArticle.Controls.Add(textBoxNewsArticlePath);
            groupBoxNewsArticle.Controls.Add(labelNewsArticlePath);
            groupBoxNewsArticle.Controls.Add(textBoxNewsArticleArticleId);
            groupBoxNewsArticle.Controls.Add(buttonRequestNewsArticle);
            groupBoxNewsArticle.Controls.Add(labelNewsArticleProviderCode);
            groupBoxNewsArticle.Controls.Add(labelNewsArticleArticleId);
            groupBoxNewsArticle.Controls.Add(textBoxNewsArticleProviderCode);
            groupBoxNewsArticle.Location = new Point(5, 3);
            groupBoxNewsArticle.Margin = new Padding(4, 3, 4, 3);
            groupBoxNewsArticle.Name = "groupBoxNewsArticle";
            groupBoxNewsArticle.Padding = new Padding(4, 3, 4, 3);
            groupBoxNewsArticle.Size = new Size(313, 155);
            groupBoxNewsArticle.TabIndex = 1;
            groupBoxNewsArticle.TabStop = false;
            groupBoxNewsArticle.Text = "News Article";
            // 
            // buttonPdfPathDialog
            // 
            buttonPdfPathDialog.Location = new Point(273, 67);
            buttonPdfPathDialog.Margin = new Padding(4, 3, 4, 3);
            buttonPdfPathDialog.Name = "buttonPdfPathDialog";
            buttonPdfPathDialog.Size = new Size(30, 23);
            buttonPdfPathDialog.TabIndex = 65;
            buttonPdfPathDialog.Text = "...";
            buttonPdfPathDialog.UseVisualStyleBackColor = true;
            buttonPdfPathDialog.Click += buttonPdfPathDialog_Click;
            // 
            // textBoxNewsArticlePath
            // 
            textBoxNewsArticlePath.Location = new Point(128, 67);
            textBoxNewsArticlePath.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsArticlePath.Name = "textBoxNewsArticlePath";
            textBoxNewsArticlePath.Size = new Size(139, 23);
            textBoxNewsArticlePath.TabIndex = 64;
            // 
            // labelNewsArticlePath
            // 
            labelNewsArticlePath.AutoSize = true;
            labelNewsArticlePath.Location = new Point(15, 70);
            labelNewsArticlePath.Margin = new Padding(4, 0, 4, 0);
            labelNewsArticlePath.Name = "labelNewsArticlePath";
            labelNewsArticlePath.Size = new Size(90, 15);
            labelNewsArticlePath.TabIndex = 63;
            labelNewsArticlePath.Text = "Binary/pdf path";
            // 
            // textBoxNewsArticleArticleId
            // 
            textBoxNewsArticleArticleId.Location = new Point(128, 40);
            textBoxNewsArticleArticleId.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsArticleArticleId.Name = "textBoxNewsArticleArticleId";
            textBoxNewsArticleArticleId.Size = new Size(177, 23);
            textBoxNewsArticleArticleId.TabIndex = 3;
            // 
            // buttonRequestNewsArticle
            // 
            buttonRequestNewsArticle.Location = new Point(144, 121);
            buttonRequestNewsArticle.Margin = new Padding(4, 3, 4, 3);
            buttonRequestNewsArticle.Name = "buttonRequestNewsArticle";
            buttonRequestNewsArticle.Size = new Size(162, 27);
            buttonRequestNewsArticle.TabIndex = 62;
            buttonRequestNewsArticle.Text = "Request News Article";
            buttonRequestNewsArticle.UseVisualStyleBackColor = true;
            buttonRequestNewsArticle.Click += buttonRequestNewsArticle_Click;
            // 
            // labelNewsArticleProviderCode
            // 
            labelNewsArticleProviderCode.AutoSize = true;
            labelNewsArticleProviderCode.Location = new Point(15, 17);
            labelNewsArticleProviderCode.Margin = new Padding(4, 0, 4, 0);
            labelNewsArticleProviderCode.Name = "labelNewsArticleProviderCode";
            labelNewsArticleProviderCode.Size = new Size(82, 15);
            labelNewsArticleProviderCode.TabIndex = 0;
            labelNewsArticleProviderCode.Text = "Provider Code";
            // 
            // labelNewsArticleArticleId
            // 
            labelNewsArticleArticleId.AutoSize = true;
            labelNewsArticleArticleId.Location = new Point(15, 44);
            labelNewsArticleArticleId.Margin = new Padding(4, 0, 4, 0);
            labelNewsArticleArticleId.Name = "labelNewsArticleArticleId";
            labelNewsArticleArticleId.Size = new Size(54, 15);
            labelNewsArticleArticleId.TabIndex = 2;
            labelNewsArticleArticleId.Text = "Article Id";
            // 
            // textBoxNewsArticleProviderCode
            // 
            textBoxNewsArticleProviderCode.Location = new Point(128, 14);
            textBoxNewsArticleProviderCode.Margin = new Padding(4, 3, 4, 3);
            textBoxNewsArticleProviderCode.Name = "textBoxNewsArticleProviderCode";
            textBoxNewsArticleProviderCode.Size = new Size(177, 23);
            textBoxNewsArticleProviderCode.TabIndex = 1;
            // 
            // tabPageHistoricalNews
            // 
            tabPageHistoricalNews.BackColor = Color.LightGray;
            tabPageHistoricalNews.Controls.Add(groupBoxHistoricalNews);
            tabPageHistoricalNews.Location = new Point(4, 24);
            tabPageHistoricalNews.Margin = new Padding(4, 3, 4, 3);
            tabPageHistoricalNews.Name = "tabPageHistoricalNews";
            tabPageHistoricalNews.Padding = new Padding(4, 3, 4, 3);
            tabPageHistoricalNews.Size = new Size(1436, 212);
            tabPageHistoricalNews.TabIndex = 0;
            tabPageHistoricalNews.Text = "Historical News";
            // 
            // groupBoxHistoricalNews
            // 
            groupBoxHistoricalNews.Controls.Add(textBoxHistoricalNewsProviderCodes);
            groupBoxHistoricalNews.Controls.Add(buttonRequestHistoricalNews);
            groupBoxHistoricalNews.Controls.Add(labelHistoricalNewsConId);
            groupBoxHistoricalNews.Controls.Add(labelHistoricalNewsProviderCodes);
            groupBoxHistoricalNews.Controls.Add(labelHistoricalNewsEndDateTime);
            groupBoxHistoricalNews.Controls.Add(textBoxHistoricalNewsTotalResults);
            groupBoxHistoricalNews.Controls.Add(labelHistoricalNewsStartDateTime);
            groupBoxHistoricalNews.Controls.Add(textBoxHistoricalNewsContractId);
            groupBoxHistoricalNews.Controls.Add(textBoxHistoricalNewsStartDateTime);
            groupBoxHistoricalNews.Controls.Add(textBoxHistoricalNewsEndDateTime);
            groupBoxHistoricalNews.Controls.Add(labelHistoricalNewsTotalResults);
            groupBoxHistoricalNews.Location = new Point(7, 7);
            groupBoxHistoricalNews.Margin = new Padding(4, 3, 4, 3);
            groupBoxHistoricalNews.Name = "groupBoxHistoricalNews";
            groupBoxHistoricalNews.Padding = new Padding(4, 3, 4, 3);
            groupBoxHistoricalNews.Size = new Size(313, 194);
            groupBoxHistoricalNews.TabIndex = 0;
            groupBoxHistoricalNews.TabStop = false;
            groupBoxHistoricalNews.Text = "Historical News";
            // 
            // textBoxHistoricalNewsProviderCodes
            // 
            textBoxHistoricalNewsProviderCodes.Location = new Point(128, 42);
            textBoxHistoricalNewsProviderCodes.Margin = new Padding(4, 3, 4, 3);
            textBoxHistoricalNewsProviderCodes.Name = "textBoxHistoricalNewsProviderCodes";
            textBoxHistoricalNewsProviderCodes.Size = new Size(143, 23);
            textBoxHistoricalNewsProviderCodes.TabIndex = 3;
            textBoxHistoricalNewsProviderCodes.Text = "BZ+FLY";
            // 
            // buttonRequestHistoricalNews
            // 
            buttonRequestHistoricalNews.Location = new Point(83, 158);
            buttonRequestHistoricalNews.Margin = new Padding(4, 3, 4, 3);
            buttonRequestHistoricalNews.Name = "buttonRequestHistoricalNews";
            buttonRequestHistoricalNews.Size = new Size(162, 27);
            buttonRequestHistoricalNews.TabIndex = 62;
            buttonRequestHistoricalNews.Text = "Request Historical News";
            buttonRequestHistoricalNews.UseVisualStyleBackColor = true;
            buttonRequestHistoricalNews.Click += buttonRequestHistoricalNews_Click;
            // 
            // labelHistoricalNewsConId
            // 
            labelHistoricalNewsConId.AutoSize = true;
            labelHistoricalNewsConId.Location = new Point(15, 21);
            labelHistoricalNewsConId.Margin = new Padding(4, 0, 4, 0);
            labelHistoricalNewsConId.Name = "labelHistoricalNewsConId";
            labelHistoricalNewsConId.Size = new Size(66, 15);
            labelHistoricalNewsConId.TabIndex = 0;
            labelHistoricalNewsConId.Text = "Contract Id";
            // 
            // labelHistoricalNewsProviderCodes
            // 
            labelHistoricalNewsProviderCodes.AutoSize = true;
            labelHistoricalNewsProviderCodes.Location = new Point(15, 50);
            labelHistoricalNewsProviderCodes.Margin = new Padding(4, 0, 4, 0);
            labelHistoricalNewsProviderCodes.Name = "labelHistoricalNewsProviderCodes";
            labelHistoricalNewsProviderCodes.Size = new Size(87, 15);
            labelHistoricalNewsProviderCodes.TabIndex = 2;
            labelHistoricalNewsProviderCodes.Text = "Provider Codes";
            // 
            // labelHistoricalNewsEndDateTime
            // 
            labelHistoricalNewsEndDateTime.AutoSize = true;
            labelHistoricalNewsEndDateTime.Location = new Point(15, 107);
            labelHistoricalNewsEndDateTime.Margin = new Padding(4, 0, 4, 0);
            labelHistoricalNewsEndDateTime.Name = "labelHistoricalNewsEndDateTime";
            labelHistoricalNewsEndDateTime.Size = new Size(85, 15);
            labelHistoricalNewsEndDateTime.TabIndex = 6;
            labelHistoricalNewsEndDateTime.Text = "End Date/Time";
            // 
            // textBoxHistoricalNewsTotalResults
            // 
            textBoxHistoricalNewsTotalResults.Location = new Point(128, 128);
            textBoxHistoricalNewsTotalResults.Margin = new Padding(4, 3, 4, 3);
            textBoxHistoricalNewsTotalResults.Name = "textBoxHistoricalNewsTotalResults";
            textBoxHistoricalNewsTotalResults.Size = new Size(143, 23);
            textBoxHistoricalNewsTotalResults.TabIndex = 9;
            textBoxHistoricalNewsTotalResults.Text = "5";
            // 
            // labelHistoricalNewsStartDateTime
            // 
            labelHistoricalNewsStartDateTime.AutoSize = true;
            labelHistoricalNewsStartDateTime.Location = new Point(15, 78);
            labelHistoricalNewsStartDateTime.Margin = new Padding(4, 0, 4, 0);
            labelHistoricalNewsStartDateTime.Name = "labelHistoricalNewsStartDateTime";
            labelHistoricalNewsStartDateTime.Size = new Size(89, 15);
            labelHistoricalNewsStartDateTime.TabIndex = 4;
            labelHistoricalNewsStartDateTime.Text = "Start Date/Time";
            // 
            // textBoxHistoricalNewsContractId
            // 
            textBoxHistoricalNewsContractId.Location = new Point(128, 13);
            textBoxHistoricalNewsContractId.Margin = new Padding(4, 3, 4, 3);
            textBoxHistoricalNewsContractId.Name = "textBoxHistoricalNewsContractId";
            textBoxHistoricalNewsContractId.Size = new Size(143, 23);
            textBoxHistoricalNewsContractId.TabIndex = 1;
            textBoxHistoricalNewsContractId.Text = "8314";
            // 
            // textBoxHistoricalNewsStartDateTime
            // 
            textBoxHistoricalNewsStartDateTime.Location = new Point(128, 70);
            textBoxHistoricalNewsStartDateTime.Margin = new Padding(4, 3, 4, 3);
            textBoxHistoricalNewsStartDateTime.Name = "textBoxHistoricalNewsStartDateTime";
            textBoxHistoricalNewsStartDateTime.Size = new Size(143, 23);
            textBoxHistoricalNewsStartDateTime.TabIndex = 5;
            // 
            // textBoxHistoricalNewsEndDateTime
            // 
            textBoxHistoricalNewsEndDateTime.Location = new Point(128, 99);
            textBoxHistoricalNewsEndDateTime.Margin = new Padding(4, 3, 4, 3);
            textBoxHistoricalNewsEndDateTime.Name = "textBoxHistoricalNewsEndDateTime";
            textBoxHistoricalNewsEndDateTime.Size = new Size(143, 23);
            textBoxHistoricalNewsEndDateTime.TabIndex = 7;
            // 
            // labelHistoricalNewsTotalResults
            // 
            labelHistoricalNewsTotalResults.AutoSize = true;
            labelHistoricalNewsTotalResults.Location = new Point(15, 136);
            labelHistoricalNewsTotalResults.Margin = new Padding(4, 0, 4, 0);
            labelHistoricalNewsTotalResults.Name = "labelHistoricalNewsTotalResults";
            labelHistoricalNewsTotalResults.Size = new Size(72, 15);
            labelHistoricalNewsTotalResults.TabIndex = 8;
            labelHistoricalNewsTotalResults.Text = "Total Results";
            // 
            // acctPosTab
            // 
            acctPosTab.BackColor = Color.LightGray;
            acctPosTab.Controls.Add(acctPosMultiPanel);
            acctPosTab.Controls.Add(groupBoxRequestData);
            acctPosTab.Location = new Point(4, 24);
            acctPosTab.Margin = new Padding(4, 3, 4, 3);
            acctPosTab.Name = "acctPosTab";
            acctPosTab.Padding = new Padding(4, 3, 4, 3);
            acctPosTab.Size = new Size(1457, 519);
            acctPosTab.TabIndex = 8;
            acctPosTab.Text = "Acct/Pos Multi";
            // 
            // acctPosMultiPanel
            // 
            acctPosMultiPanel.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            acctPosMultiPanel.Controls.Add(tabPositionsMulti);
            acctPosMultiPanel.Controls.Add(tabAccountUpdatesMulti);
            acctPosMultiPanel.Location = new Point(6, 143);
            acctPosMultiPanel.Margin = new Padding(0);
            acctPosMultiPanel.Name = "acctPosMultiPanel";
            acctPosMultiPanel.SelectedIndex = 0;
            acctPosMultiPanel.Size = new Size(1449, 250);
            acctPosMultiPanel.TabIndex = 1;
            // 
            // tabPositionsMulti
            // 
            tabPositionsMulti.BackColor = Color.LightGray;
            tabPositionsMulti.Controls.Add(clearPositionsMulti);
            tabPositionsMulti.Controls.Add(positionsMultiGrid);
            tabPositionsMulti.Location = new Point(4, 24);
            tabPositionsMulti.Margin = new Padding(4, 3, 4, 3);
            tabPositionsMulti.Name = "tabPositionsMulti";
            tabPositionsMulti.Padding = new Padding(4, 3, 4, 3);
            tabPositionsMulti.Size = new Size(1441, 222);
            tabPositionsMulti.TabIndex = 0;
            tabPositionsMulti.Text = "Positions Multi";
            // 
            // clearPositionsMulti
            // 
            clearPositionsMulti.AutoSize = true;
            clearPositionsMulti.Location = new Point(7, 3);
            clearPositionsMulti.Margin = new Padding(4, 0, 4, 0);
            clearPositionsMulti.Name = "clearPositionsMulti";
            clearPositionsMulti.Size = new Size(34, 15);
            clearPositionsMulti.TabIndex = 6;
            clearPositionsMulti.TabStop = true;
            clearPositionsMulti.Text = "Clear";
            clearPositionsMulti.LinkClicked += clearPositionsMulti_LinkClicked;
            // 
            // positionsMultiGrid
            // 
            positionsMultiGrid.AllowUserToAddRows = false;
            positionsMultiGrid.AllowUserToDeleteRows = false;
            positionsMultiGrid.AllowUserToOrderColumns = true;
            positionsMultiGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            positionsMultiGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            positionsMultiGrid.Columns.AddRange(new DataGridViewColumn[] { accountPositionsMulti, modelCodePositionsMulti, contractPositionsMulti, positionPositionsMulti, avgCostPositionsMulti });
            positionsMultiGrid.Location = new Point(4, 22);
            positionsMultiGrid.Margin = new Padding(4, 3, 4, 3);
            positionsMultiGrid.Name = "positionsMultiGrid";
            positionsMultiGrid.ReadOnly = true;
            positionsMultiGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            positionsMultiGrid.Size = new Size(1429, 189);
            positionsMultiGrid.TabIndex = 0;
            // 
            // accountPositionsMulti
            // 
            accountPositionsMulti.HeaderText = "Account";
            accountPositionsMulti.Name = "accountPositionsMulti";
            accountPositionsMulti.ReadOnly = true;
            // 
            // modelCodePositionsMulti
            // 
            modelCodePositionsMulti.HeaderText = "Model Code";
            modelCodePositionsMulti.Name = "modelCodePositionsMulti";
            modelCodePositionsMulti.ReadOnly = true;
            // 
            // contractPositionsMulti
            // 
            contractPositionsMulti.HeaderText = "Contract";
            contractPositionsMulti.Name = "contractPositionsMulti";
            contractPositionsMulti.ReadOnly = true;
            contractPositionsMulti.Width = 300;
            // 
            // positionPositionsMulti
            // 
            positionPositionsMulti.HeaderText = "Position";
            positionPositionsMulti.Name = "positionPositionsMulti";
            positionPositionsMulti.ReadOnly = true;
            // 
            // avgCostPositionsMulti
            // 
            avgCostPositionsMulti.HeaderText = "Avg Cost";
            avgCostPositionsMulti.Name = "avgCostPositionsMulti";
            avgCostPositionsMulti.ReadOnly = true;
            // 
            // tabAccountUpdatesMulti
            // 
            tabAccountUpdatesMulti.BackColor = Color.LightGray;
            tabAccountUpdatesMulti.Controls.Add(clearAccountUpdatesMulti);
            tabAccountUpdatesMulti.Controls.Add(accountUpdatesMultiGrid);
            tabAccountUpdatesMulti.Location = new Point(4, 24);
            tabAccountUpdatesMulti.Margin = new Padding(4, 3, 4, 3);
            tabAccountUpdatesMulti.Name = "tabAccountUpdatesMulti";
            tabAccountUpdatesMulti.Padding = new Padding(4, 3, 4, 3);
            tabAccountUpdatesMulti.Size = new Size(1441, 222);
            tabAccountUpdatesMulti.TabIndex = 1;
            tabAccountUpdatesMulti.Text = "Account Updates Multi";
            // 
            // clearAccountUpdatesMulti
            // 
            clearAccountUpdatesMulti.AutoSize = true;
            clearAccountUpdatesMulti.Location = new Point(7, 3);
            clearAccountUpdatesMulti.Margin = new Padding(4, 0, 4, 0);
            clearAccountUpdatesMulti.Name = "clearAccountUpdatesMulti";
            clearAccountUpdatesMulti.Size = new Size(34, 15);
            clearAccountUpdatesMulti.TabIndex = 0;
            clearAccountUpdatesMulti.TabStop = true;
            clearAccountUpdatesMulti.Text = "Clear";
            clearAccountUpdatesMulti.LinkClicked += clearAccountUpdatesMulti_LinkClicked;
            // 
            // accountUpdatesMultiGrid
            // 
            accountUpdatesMultiGrid.AllowUserToAddRows = false;
            accountUpdatesMultiGrid.AllowUserToDeleteRows = false;
            accountUpdatesMultiGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            accountUpdatesMultiGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountUpdatesMultiGrid.Columns.AddRange(new DataGridViewColumn[] { accountAccountUpdatesMulti, modelCodeAccountUpdatesMulti, keyAccountUpdatesMulti, valueAccountUpdatesMulti, currencyAccountUpdatesMulti });
            accountUpdatesMultiGrid.Location = new Point(5, 22);
            accountUpdatesMultiGrid.Margin = new Padding(4, 3, 4, 3);
            accountUpdatesMultiGrid.Name = "accountUpdatesMultiGrid";
            accountUpdatesMultiGrid.ReadOnly = true;
            accountUpdatesMultiGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            accountUpdatesMultiGrid.Size = new Size(1428, 189);
            accountUpdatesMultiGrid.TabIndex = 1;
            // 
            // accountAccountUpdatesMulti
            // 
            accountAccountUpdatesMulti.HeaderText = "Account";
            accountAccountUpdatesMulti.Name = "accountAccountUpdatesMulti";
            accountAccountUpdatesMulti.ReadOnly = true;
            // 
            // modelCodeAccountUpdatesMulti
            // 
            modelCodeAccountUpdatesMulti.HeaderText = "Model Code";
            modelCodeAccountUpdatesMulti.Name = "modelCodeAccountUpdatesMulti";
            modelCodeAccountUpdatesMulti.ReadOnly = true;
            // 
            // keyAccountUpdatesMulti
            // 
            keyAccountUpdatesMulti.HeaderText = "Key";
            keyAccountUpdatesMulti.Name = "keyAccountUpdatesMulti";
            keyAccountUpdatesMulti.ReadOnly = true;
            // 
            // valueAccountUpdatesMulti
            // 
            valueAccountUpdatesMulti.HeaderText = "Value";
            valueAccountUpdatesMulti.Name = "valueAccountUpdatesMulti";
            valueAccountUpdatesMulti.ReadOnly = true;
            // 
            // currencyAccountUpdatesMulti
            // 
            currencyAccountUpdatesMulti.HeaderText = "Currency";
            currencyAccountUpdatesMulti.Name = "currencyAccountUpdatesMulti";
            currencyAccountUpdatesMulti.ReadOnly = true;
            currencyAccountUpdatesMulti.Width = 50;
            // 
            // groupBoxRequestData
            // 
            groupBoxRequestData.Controls.Add(buttonCancelAccountUpdatesMulti);
            groupBoxRequestData.Controls.Add(buttonCancelPositionsMulti);
            groupBoxRequestData.Controls.Add(buttonRequestAccountUpdatesMulti);
            groupBoxRequestData.Controls.Add(cbLedgerAndNLV);
            groupBoxRequestData.Controls.Add(labelAccount);
            groupBoxRequestData.Controls.Add(buttonRequestPositionsMulti);
            groupBoxRequestData.Controls.Add(labelModelCode);
            groupBoxRequestData.Controls.Add(textAccount);
            groupBoxRequestData.Controls.Add(textModelCode);
            groupBoxRequestData.Location = new Point(7, 7);
            groupBoxRequestData.Margin = new Padding(4, 3, 4, 3);
            groupBoxRequestData.Name = "groupBoxRequestData";
            groupBoxRequestData.Padding = new Padding(4, 3, 4, 3);
            groupBoxRequestData.Size = new Size(601, 106);
            groupBoxRequestData.TabIndex = 0;
            groupBoxRequestData.TabStop = false;
            groupBoxRequestData.Text = "Request Data";
            // 
            // buttonCancelAccountUpdatesMulti
            // 
            buttonCancelAccountUpdatesMulti.Location = new Point(408, 55);
            buttonCancelAccountUpdatesMulti.Margin = new Padding(4, 3, 4, 3);
            buttonCancelAccountUpdatesMulti.Name = "buttonCancelAccountUpdatesMulti";
            buttonCancelAccountUpdatesMulti.Size = new Size(178, 27);
            buttonCancelAccountUpdatesMulti.TabIndex = 9;
            buttonCancelAccountUpdatesMulti.Text = "Cancel Acct Updates Multi";
            buttonCancelAccountUpdatesMulti.UseVisualStyleBackColor = true;
            buttonCancelAccountUpdatesMulti.Click += buttonCancelAccountUpdatesMulti_Click;
            // 
            // buttonCancelPositionsMulti
            // 
            buttonCancelPositionsMulti.Location = new Point(408, 22);
            buttonCancelPositionsMulti.Margin = new Padding(4, 3, 4, 3);
            buttonCancelPositionsMulti.Name = "buttonCancelPositionsMulti";
            buttonCancelPositionsMulti.Size = new Size(178, 27);
            buttonCancelPositionsMulti.TabIndex = 8;
            buttonCancelPositionsMulti.Text = "Cancel Positions Multi";
            buttonCancelPositionsMulti.UseVisualStyleBackColor = true;
            buttonCancelPositionsMulti.Click += buttonCancelPositionsMulti_Click;
            // 
            // buttonRequestAccountUpdatesMulti
            // 
            buttonRequestAccountUpdatesMulti.Location = new Point(223, 55);
            buttonRequestAccountUpdatesMulti.Margin = new Padding(4, 3, 4, 3);
            buttonRequestAccountUpdatesMulti.Name = "buttonRequestAccountUpdatesMulti";
            buttonRequestAccountUpdatesMulti.Size = new Size(178, 27);
            buttonRequestAccountUpdatesMulti.TabIndex = 7;
            buttonRequestAccountUpdatesMulti.Text = "Req Account Updates Multi";
            buttonRequestAccountUpdatesMulti.UseVisualStyleBackColor = true;
            buttonRequestAccountUpdatesMulti.Click += buttonRequestAccountUpdatesMulti_Click;
            // 
            // cbLedgerAndNLV
            // 
            cbLedgerAndNLV.AutoSize = true;
            cbLedgerAndNLV.Location = new Point(99, 77);
            cbLedgerAndNLV.Margin = new Padding(4, 3, 4, 3);
            cbLedgerAndNLV.Name = "cbLedgerAndNLV";
            cbLedgerAndNLV.Size = new Size(105, 19);
            cbLedgerAndNLV.TabIndex = 4;
            cbLedgerAndNLV.Text = "LedgerAndNLV";
            cbLedgerAndNLV.UseVisualStyleBackColor = true;
            // 
            // labelAccount
            // 
            labelAccount.AutoSize = true;
            labelAccount.Location = new Point(37, 25);
            labelAccount.Margin = new Padding(4, 0, 4, 0);
            labelAccount.Name = "labelAccount";
            labelAccount.Size = new Size(52, 15);
            labelAccount.TabIndex = 0;
            labelAccount.Text = "Account";
            // 
            // buttonRequestPositionsMulti
            // 
            buttonRequestPositionsMulti.Location = new Point(223, 22);
            buttonRequestPositionsMulti.Margin = new Padding(4, 3, 4, 3);
            buttonRequestPositionsMulti.Name = "buttonRequestPositionsMulti";
            buttonRequestPositionsMulti.Size = new Size(178, 27);
            buttonRequestPositionsMulti.TabIndex = 5;
            buttonRequestPositionsMulti.Text = "Request Positions Multi";
            buttonRequestPositionsMulti.UseVisualStyleBackColor = true;
            buttonRequestPositionsMulti.Click += buttonRequestPositionsMulti_Click;
            // 
            // labelModelCode
            // 
            labelModelCode.AutoSize = true;
            labelModelCode.Location = new Point(18, 55);
            labelModelCode.Margin = new Padding(4, 0, 4, 0);
            labelModelCode.Name = "labelModelCode";
            labelModelCode.Size = new Size(72, 15);
            labelModelCode.TabIndex = 1;
            labelModelCode.Text = "Model Code";
            // 
            // textAccount
            // 
            textAccount.Location = new Point(99, 17);
            textAccount.Margin = new Padding(4, 3, 4, 3);
            textAccount.Name = "textAccount";
            textAccount.Size = new Size(116, 23);
            textAccount.TabIndex = 2;
            // 
            // textModelCode
            // 
            textModelCode.Location = new Point(99, 47);
            textModelCode.Margin = new Padding(4, 3, 4, 3);
            textModelCode.Name = "textModelCode";
            textModelCode.Size = new Size(116, 23);
            textModelCode.TabIndex = 3;
            // 
            // optionsTab
            // 
            optionsTab.BackColor = Color.LightGray;
            optionsTab.Controls.Add(optionExchange);
            optionsTab.Controls.Add(optionExerciseQuan);
            optionsTab.Controls.Add(optionExchangeLabel);
            optionsTab.Controls.Add(optionsQuantityLabel);
            optionsTab.Controls.Add(optionsPositionsGroupBox);
            optionsTab.Controls.Add(overrideOption);
            optionsTab.Controls.Add(lapseOption);
            optionsTab.Controls.Add(exerciseOption);
            optionsTab.Controls.Add(exerciseAccountLabel);
            optionsTab.Controls.Add(exerciseAccount);
            optionsTab.Location = new Point(4, 24);
            optionsTab.Margin = new Padding(4, 3, 4, 3);
            optionsTab.Name = "optionsTab";
            optionsTab.Padding = new Padding(4, 3, 4, 3);
            optionsTab.Size = new Size(1457, 519);
            optionsTab.TabIndex = 7;
            optionsTab.Text = "Option exercising";
            optionsTab.Click += optionsTab_Click;
            // 
            // optionExchange
            // 
            optionExchange.Location = new Point(1214, 89);
            optionExchange.Margin = new Padding(4, 3, 4, 3);
            optionExchange.Name = "optionExchange";
            optionExchange.Size = new Size(116, 23);
            optionExchange.TabIndex = 12;
            // 
            // optionExerciseQuan
            // 
            optionExerciseQuan.Location = new Point(1214, 60);
            optionExerciseQuan.Margin = new Padding(4, 3, 4, 3);
            optionExerciseQuan.Name = "optionExerciseQuan";
            optionExerciseQuan.Size = new Size(116, 23);
            optionExerciseQuan.TabIndex = 8;
            optionExerciseQuan.Text = "0";
            // 
            // optionExchangeLabel
            // 
            optionExchangeLabel.AutoSize = true;
            optionExchangeLabel.Location = new Point(1143, 92);
            optionExchangeLabel.Margin = new Padding(4, 0, 4, 0);
            optionExchangeLabel.Name = "optionExchangeLabel";
            optionExchangeLabel.Size = new Size(58, 15);
            optionExchangeLabel.TabIndex = 11;
            optionExchangeLabel.Text = "Exchange";
            // 
            // optionsQuantityLabel
            // 
            optionsQuantityLabel.AutoSize = true;
            optionsQuantityLabel.Location = new Point(1143, 60);
            optionsQuantityLabel.Margin = new Padding(4, 0, 4, 0);
            optionsQuantityLabel.Name = "optionsQuantityLabel";
            optionsQuantityLabel.Size = new Size(53, 15);
            optionsQuantityLabel.TabIndex = 10;
            optionsQuantityLabel.Text = "Quantity";
            // 
            // optionsPositionsGroupBox
            // 
            optionsPositionsGroupBox.Controls.Add(optionPositionsGrid);
            optionsPositionsGroupBox.Location = new Point(14, 38);
            optionsPositionsGroupBox.Margin = new Padding(4, 3, 4, 3);
            optionsPositionsGroupBox.Name = "optionsPositionsGroupBox";
            optionsPositionsGroupBox.Padding = new Padding(4, 3, 4, 3);
            optionsPositionsGroupBox.Size = new Size(1122, 273);
            optionsPositionsGroupBox.TabIndex = 9;
            optionsPositionsGroupBox.TabStop = false;
            optionsPositionsGroupBox.Text = "Option long positions";
            // 
            // optionPositionsGrid
            // 
            optionPositionsGrid.AllowUserToAddRows = false;
            optionPositionsGrid.AllowUserToDeleteRows = false;
            optionPositionsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            optionPositionsGrid.Columns.AddRange(new DataGridViewColumn[] { optionContract, optionAccount, optionPosition, optionMarketPrice, optionMarketValue, optionAverageCost, optionUnrealizedPnL, optionRealizedPnL });
            optionPositionsGrid.Location = new Point(12, 22);
            optionPositionsGrid.Margin = new Padding(4, 3, 4, 3);
            optionPositionsGrid.Name = "optionPositionsGrid";
            optionPositionsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            optionPositionsGrid.Size = new Size(1104, 239);
            optionPositionsGrid.TabIndex = 4;
            // 
            // optionContract
            // 
            optionContract.HeaderText = "Contract";
            optionContract.Name = "optionContract";
            optionContract.ReadOnly = true;
            optionContract.Width = 140;
            // 
            // optionAccount
            // 
            optionAccount.HeaderText = "Account";
            optionAccount.Name = "optionAccount";
            optionAccount.ReadOnly = true;
            // 
            // optionPosition
            // 
            optionPosition.HeaderText = "Position";
            optionPosition.Name = "optionPosition";
            optionPosition.ReadOnly = true;
            // 
            // optionMarketPrice
            // 
            optionMarketPrice.HeaderText = "Market Price";
            optionMarketPrice.Name = "optionMarketPrice";
            optionMarketPrice.ReadOnly = true;
            // 
            // optionMarketValue
            // 
            optionMarketValue.HeaderText = "Market Value";
            optionMarketValue.Name = "optionMarketValue";
            optionMarketValue.ReadOnly = true;
            // 
            // optionAverageCost
            // 
            optionAverageCost.HeaderText = "Average Cost";
            optionAverageCost.Name = "optionAverageCost";
            optionAverageCost.ReadOnly = true;
            // 
            // optionUnrealizedPnL
            // 
            optionUnrealizedPnL.HeaderText = "Unrealized P&L";
            optionUnrealizedPnL.Name = "optionUnrealizedPnL";
            optionUnrealizedPnL.ReadOnly = true;
            optionUnrealizedPnL.Width = 120;
            // 
            // optionRealizedPnL
            // 
            optionRealizedPnL.HeaderText = "Realized P&L";
            optionRealizedPnL.Name = "optionRealizedPnL";
            optionRealizedPnL.ReadOnly = true;
            optionRealizedPnL.Width = 120;
            // 
            // overrideOption
            // 
            overrideOption.AutoSize = true;
            overrideOption.CheckAlign = ContentAlignment.MiddleRight;
            overrideOption.Location = new Point(1254, 119);
            overrideOption.Margin = new Padding(4, 3, 4, 3);
            overrideOption.Name = "overrideOption";
            overrideOption.Size = new Size(71, 19);
            overrideOption.TabIndex = 7;
            overrideOption.Text = "Override";
            overrideOption.UseVisualStyleBackColor = true;
            // 
            // lapseOption
            // 
            lapseOption.Location = new Point(1143, 179);
            lapseOption.Margin = new Padding(4, 3, 4, 3);
            lapseOption.Name = "lapseOption";
            lapseOption.Size = new Size(88, 27);
            lapseOption.TabIndex = 6;
            lapseOption.Text = "Lapse";
            lapseOption.UseVisualStyleBackColor = true;
            lapseOption.Click += lapseOption_Click;
            // 
            // exerciseOption
            // 
            exerciseOption.Location = new Point(1143, 145);
            exerciseOption.Margin = new Padding(4, 3, 4, 3);
            exerciseOption.Name = "exerciseOption";
            exerciseOption.Size = new Size(88, 27);
            exerciseOption.TabIndex = 5;
            exerciseOption.Text = "Exercise";
            exerciseOption.UseVisualStyleBackColor = true;
            exerciseOption.Click += exerciseOption_Click;
            // 
            // exerciseAccountLabel
            // 
            exerciseAccountLabel.AutoSize = true;
            exerciseAccountLabel.Location = new Point(22, 20);
            exerciseAccountLabel.Margin = new Padding(4, 0, 4, 0);
            exerciseAccountLabel.Name = "exerciseAccountLabel";
            exerciseAccountLabel.Size = new Size(93, 15);
            exerciseAccountLabel.TabIndex = 3;
            exerciseAccountLabel.Text = "Choose account";
            // 
            // exerciseAccount
            // 
            exerciseAccount.FormattingEnabled = true;
            exerciseAccount.Location = new Point(128, 16);
            exerciseAccount.Margin = new Padding(4, 3, 4, 3);
            exerciseAccount.Name = "exerciseAccount";
            exerciseAccount.Size = new Size(140, 23);
            exerciseAccount.TabIndex = 2;
            exerciseAccount.SelectedIndexChanged += exerciseAccount_SelectedIndexChanged;
            // 
            // advisorTab
            // 
            advisorTab.BackColor = Color.LightGray;
            advisorTab.Controls.Add(advisorProfilesBox);
            advisorTab.Controls.Add(advisorGroupsBox);
            advisorTab.Controls.Add(advisorAliasesBox);
            advisorTab.Location = new Point(4, 24);
            advisorTab.Margin = new Padding(4, 3, 4, 3);
            advisorTab.Name = "advisorTab";
            advisorTab.Padding = new Padding(4, 3, 4, 3);
            advisorTab.Size = new Size(1457, 519);
            advisorTab.TabIndex = 5;
            advisorTab.Text = "Financial Advisor";
            // 
            // advisorProfilesBox
            // 
            advisorProfilesBox.Controls.Add(saveProfiles);
            advisorProfilesBox.Controls.Add(loadProfiles);
            advisorProfilesBox.Controls.Add(advisorProfilesGrid);
            advisorProfilesBox.Location = new Point(427, 264);
            advisorProfilesBox.Margin = new Padding(4, 3, 4, 3);
            advisorProfilesBox.Name = "advisorProfilesBox";
            advisorProfilesBox.Padding = new Padding(4, 3, 4, 3);
            advisorProfilesBox.Size = new Size(903, 272);
            advisorProfilesBox.TabIndex = 2;
            advisorProfilesBox.TabStop = false;
            advisorProfilesBox.Text = "Profiles";
            // 
            // saveProfiles
            // 
            saveProfiles.Location = new Point(102, 22);
            saveProfiles.Margin = new Padding(4, 3, 4, 3);
            saveProfiles.Name = "saveProfiles";
            saveProfiles.Size = new Size(88, 27);
            saveProfiles.TabIndex = 3;
            saveProfiles.Text = "Save";
            saveProfiles.UseVisualStyleBackColor = true;
            saveProfiles.Click += saveProfiles_Click;
            // 
            // loadProfiles
            // 
            loadProfiles.Location = new Point(7, 22);
            loadProfiles.Margin = new Padding(4, 3, 4, 3);
            loadProfiles.Name = "loadProfiles";
            loadProfiles.Size = new Size(88, 27);
            loadProfiles.TabIndex = 2;
            loadProfiles.Text = "Load";
            loadProfiles.UseVisualStyleBackColor = true;
            loadProfiles.Click += loadProfiles_Click;
            // 
            // advisorProfilesGrid
            // 
            advisorProfilesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            advisorProfilesGrid.Columns.AddRange(new DataGridViewColumn[] { profileName, profileType, profileAllocations });
            advisorProfilesGrid.Location = new Point(7, 55);
            advisorProfilesGrid.Margin = new Padding(4, 3, 4, 3);
            advisorProfilesGrid.Name = "advisorProfilesGrid";
            advisorProfilesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advisorProfilesGrid.Size = new Size(886, 210);
            advisorProfilesGrid.TabIndex = 1;
            // 
            // profileName
            // 
            profileName.HeaderText = "Name";
            profileName.Name = "profileName";
            profileName.Width = 150;
            // 
            // profileType
            // 
            profileType.HeaderText = "Type";
            profileType.Name = "profileType";
            profileType.Width = 150;
            // 
            // profileAllocations
            // 
            profileAllocations.HeaderText = "Allocations";
            profileAllocations.Name = "profileAllocations";
            profileAllocations.Width = 400;
            // 
            // advisorGroupsBox
            // 
            advisorGroupsBox.Controls.Add(saveGroups);
            advisorGroupsBox.Controls.Add(loadGroups);
            advisorGroupsBox.Controls.Add(advisorGroupsGrid);
            advisorGroupsBox.Location = new Point(427, 7);
            advisorGroupsBox.Margin = new Padding(4, 3, 4, 3);
            advisorGroupsBox.Name = "advisorGroupsBox";
            advisorGroupsBox.Padding = new Padding(4, 3, 4, 3);
            advisorGroupsBox.Size = new Size(903, 250);
            advisorGroupsBox.TabIndex = 1;
            advisorGroupsBox.TabStop = false;
            advisorGroupsBox.Text = "Groups";
            // 
            // saveGroups
            // 
            saveGroups.Location = new Point(102, 22);
            saveGroups.Margin = new Padding(4, 3, 4, 3);
            saveGroups.Name = "saveGroups";
            saveGroups.Size = new Size(88, 27);
            saveGroups.TabIndex = 2;
            saveGroups.Text = "Save";
            saveGroups.UseVisualStyleBackColor = true;
            saveGroups.Click += saveGroups_Click;
            // 
            // loadGroups
            // 
            loadGroups.Location = new Point(7, 22);
            loadGroups.Margin = new Padding(4, 3, 4, 3);
            loadGroups.Name = "loadGroups";
            loadGroups.Size = new Size(88, 27);
            loadGroups.TabIndex = 1;
            loadGroups.Text = "Load";
            loadGroups.UseVisualStyleBackColor = true;
            loadGroups.Click += loadGroups_Click;
            // 
            // advisorGroupsGrid
            // 
            advisorGroupsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            advisorGroupsGrid.Columns.AddRange(new DataGridViewColumn[] { groupName, groupMethod, groupAccounts });
            advisorGroupsGrid.Location = new Point(7, 55);
            advisorGroupsGrid.Margin = new Padding(4, 3, 4, 3);
            advisorGroupsGrid.Name = "advisorGroupsGrid";
            advisorGroupsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advisorGroupsGrid.Size = new Size(886, 188);
            advisorGroupsGrid.TabIndex = 0;
            // 
            // groupName
            // 
            groupName.HeaderText = "Name";
            groupName.Name = "groupName";
            groupName.Width = 150;
            // 
            // groupMethod
            // 
            groupMethod.HeaderText = "Default Method";
            groupMethod.Name = "groupMethod";
            groupMethod.Resizable = DataGridViewTriState.True;
            groupMethod.SortMode = DataGridViewColumnSortMode.Automatic;
            groupMethod.Width = 150;
            // 
            // groupAccounts
            // 
            groupAccounts.HeaderText = "Accounts";
            groupAccounts.Name = "groupAccounts";
            groupAccounts.Width = 400;
            // 
            // advisorAliasesBox
            // 
            advisorAliasesBox.Controls.Add(loadAliases);
            advisorAliasesBox.Controls.Add(advisorAliasesGrid);
            advisorAliasesBox.Location = new Point(7, 7);
            advisorAliasesBox.Margin = new Padding(4, 3, 4, 3);
            advisorAliasesBox.Name = "advisorAliasesBox";
            advisorAliasesBox.Padding = new Padding(4, 3, 4, 3);
            advisorAliasesBox.Size = new Size(413, 530);
            advisorAliasesBox.TabIndex = 0;
            advisorAliasesBox.TabStop = false;
            advisorAliasesBox.Text = "Aliases";
            // 
            // loadAliases
            // 
            loadAliases.Location = new Point(7, 22);
            loadAliases.Margin = new Padding(4, 3, 4, 3);
            loadAliases.Name = "loadAliases";
            loadAliases.Size = new Size(88, 27);
            loadAliases.TabIndex = 1;
            loadAliases.Text = "Load";
            loadAliases.UseVisualStyleBackColor = true;
            loadAliases.Click += loadAliases_Click;
            // 
            // advisorAliasesGrid
            // 
            advisorAliasesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            advisorAliasesGrid.Columns.AddRange(new DataGridViewColumn[] { advisorAccount, advisorAlias });
            advisorAliasesGrid.Location = new Point(7, 55);
            advisorAliasesGrid.Margin = new Padding(4, 3, 4, 3);
            advisorAliasesGrid.Name = "advisorAliasesGrid";
            advisorAliasesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            advisorAliasesGrid.Size = new Size(399, 467);
            advisorAliasesGrid.TabIndex = 0;
            // 
            // advisorAccount
            // 
            advisorAccount.HeaderText = "Account";
            advisorAccount.Name = "advisorAccount";
            advisorAccount.Resizable = DataGridViewTriState.True;
            advisorAccount.Width = 130;
            // 
            // advisorAlias
            // 
            advisorAlias.HeaderText = "Alias";
            advisorAlias.Name = "advisorAlias";
            advisorAlias.Width = 150;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.LightGray;
            tabPage1.Controls.Add(groupBoxMarketRule);
            tabPage1.Controls.Add(groupBoxMarketDataType_CDT);
            tabPage1.Controls.Add(groupBox5);
            tabPage1.Controls.Add(groupBox3);
            tabPage1.Controls.Add(contractFundamentalsGroupBox);
            tabPage1.Controls.Add(contractDetailsGroupBox);
            tabPage1.Controls.Add(contractInfoTab);
            tabPage1.Location = new Point(4, 24);
            tabPage1.Margin = new Padding(4, 3, 4, 3);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(4, 3, 4, 3);
            tabPage1.Size = new Size(1457, 519);
            tabPage1.TabIndex = 4;
            tabPage1.Text = "Contract Information";
            // 
            // groupBoxMarketDataType_CDT
            // 
            groupBoxMarketDataType_CDT.Controls.Add(comboBoxMarketDataType_CDT);
            groupBoxMarketDataType_CDT.Location = new Point(741, 123);
            groupBoxMarketDataType_CDT.Margin = new Padding(4, 3, 4, 3);
            groupBoxMarketDataType_CDT.Name = "groupBoxMarketDataType_CDT";
            groupBoxMarketDataType_CDT.Padding = new Padding(4, 3, 4, 3);
            groupBoxMarketDataType_CDT.Size = new Size(217, 54);
            groupBoxMarketDataType_CDT.TabIndex = 4;
            groupBoxMarketDataType_CDT.TabStop = false;
            groupBoxMarketDataType_CDT.Text = "Market Data Type";
            // 
            // comboBoxMarketDataType_CDT
            // 
            comboBoxMarketDataType_CDT.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMarketDataType_CDT.FormattingEnabled = true;
            comboBoxMarketDataType_CDT.Location = new Point(15, 18);
            comboBoxMarketDataType_CDT.Margin = new Padding(4, 3, 4, 3);
            comboBoxMarketDataType_CDT.Name = "comboBoxMarketDataType_CDT";
            comboBoxMarketDataType_CDT.Size = new Size(184, 23);
            comboBoxMarketDataType_CDT.TabIndex = 0;
            comboBoxMarketDataType_CDT.SelectedIndexChanged += comboBoxMarketDataType_CDT_SelectedIndexChanged;
            // 
            // contractFundamentalsGroupBox
            // 
            contractFundamentalsGroupBox.Controls.Add(fundamentalsQueryButton);
            contractFundamentalsGroupBox.Controls.Add(fundamentalsReportTypeLabel);
            contractFundamentalsGroupBox.Controls.Add(fundamentalsReportType);
            contractFundamentalsGroupBox.Location = new Point(496, 123);
            contractFundamentalsGroupBox.Margin = new Padding(4, 3, 4, 3);
            contractFundamentalsGroupBox.Name = "contractFundamentalsGroupBox";
            contractFundamentalsGroupBox.Padding = new Padding(4, 3, 4, 3);
            contractFundamentalsGroupBox.Size = new Size(238, 83);
            contractFundamentalsGroupBox.TabIndex = 2;
            contractFundamentalsGroupBox.TabStop = false;
            contractFundamentalsGroupBox.Text = "Fundamentals";
            // 
            // fundamentalsReportTypeLabel
            // 
            fundamentalsReportTypeLabel.AutoSize = true;
            fundamentalsReportTypeLabel.Location = new Point(7, 22);
            fundamentalsReportTypeLabel.Margin = new Padding(4, 0, 4, 0);
            fundamentalsReportTypeLabel.Name = "fundamentalsReportTypeLabel";
            fundamentalsReportTypeLabel.Size = new Size(68, 15);
            fundamentalsReportTypeLabel.TabIndex = 0;
            fundamentalsReportTypeLabel.Text = "Report type";
            // 
            // fundamentalsReportType
            // 
            fundamentalsReportType.FormattingEnabled = true;
            fundamentalsReportType.Location = new Point(86, 18);
            fundamentalsReportType.Margin = new Padding(4, 3, 4, 3);
            fundamentalsReportType.Name = "fundamentalsReportType";
            fundamentalsReportType.Size = new Size(140, 23);
            fundamentalsReportType.TabIndex = 1;
            // 
            // contractDetailsGroupBox
            // 
            contractDetailsGroupBox.Controls.Add(conDetIssuerIdLabel);
            contractDetailsGroupBox.Controls.Add(conDetIssuerId);
            contractDetailsGroupBox.Controls.Add(requestMatchingSymbolsCD);
            contractDetailsGroupBox.Controls.Add(searchContractDetails);
            contractDetailsGroupBox.Controls.Add(conDetSymbolLabel);
            contractDetailsGroupBox.Controls.Add(conDetRightLabel);
            contractDetailsGroupBox.Controls.Add(conDetStrikeLabel);
            contractDetailsGroupBox.Controls.Add(conDetRight);
            contractDetailsGroupBox.Controls.Add(conDetLastTradeDateLabel);
            contractDetailsGroupBox.Controls.Add(conDetSecType);
            contractDetailsGroupBox.Controls.Add(conDetMultiplierLabel);
            contractDetailsGroupBox.Controls.Add(conDetSecTypeLabel);
            contractDetailsGroupBox.Controls.Add(conDetLocalSymbolLabel);
            contractDetailsGroupBox.Controls.Add(conDetExchangeLabel);
            contractDetailsGroupBox.Controls.Add(conDetExchange);
            contractDetailsGroupBox.Controls.Add(conDetLocalSymbol);
            contractDetailsGroupBox.Controls.Add(conDetMultiplier);
            contractDetailsGroupBox.Controls.Add(conDetCurrencyLabel);
            contractDetailsGroupBox.Controls.Add(conDetCurrency);
            contractDetailsGroupBox.Controls.Add(conDetLastTradeDateOrContractMonth);
            contractDetailsGroupBox.Controls.Add(conDetStrike);
            contractDetailsGroupBox.Controls.Add(conDetSymbol);
            contractDetailsGroupBox.Location = new Point(9, 7);
            contractDetailsGroupBox.Margin = new Padding(4, 3, 4, 3);
            contractDetailsGroupBox.Name = "contractDetailsGroupBox";
            contractDetailsGroupBox.Padding = new Padding(4, 3, 4, 3);
            contractDetailsGroupBox.Size = new Size(465, 200);
            contractDetailsGroupBox.TabIndex = 0;
            contractDetailsGroupBox.TabStop = false;
            contractDetailsGroupBox.Text = "Contract details";
            // 
            // conDetIssuerIdLabel
            // 
            conDetIssuerIdLabel.AutoSize = true;
            conDetIssuerIdLabel.Location = new Point(261, 140);
            conDetIssuerIdLabel.Margin = new Padding(4, 0, 4, 0);
            conDetIssuerIdLabel.Name = "conDetIssuerIdLabel";
            conDetIssuerIdLabel.Size = new Size(47, 15);
            conDetIssuerIdLabel.TabIndex = 18;
            conDetIssuerIdLabel.Text = "IssuerId";
            // 
            // conDetIssuerId
            // 
            conDetIssuerId.Location = new Point(331, 136);
            conDetIssuerId.Margin = new Padding(4, 3, 4, 3);
            conDetIssuerId.Name = "conDetIssuerId";
            conDetIssuerId.Size = new Size(116, 23);
            conDetIssuerId.TabIndex = 19;
            // 
            // conDetSymbolLabel
            // 
            conDetSymbolLabel.AutoSize = true;
            conDetSymbolLabel.Location = new Point(23, 30);
            conDetSymbolLabel.Margin = new Padding(4, 0, 4, 0);
            conDetSymbolLabel.Name = "conDetSymbolLabel";
            conDetSymbolLabel.Size = new Size(47, 15);
            conDetSymbolLabel.TabIndex = 0;
            conDetSymbolLabel.Text = "Symbol";
            // 
            // conDetRightLabel
            // 
            conDetRightLabel.AutoSize = true;
            conDetRightLabel.Location = new Point(19, 147);
            conDetRightLabel.Margin = new Padding(4, 0, 4, 0);
            conDetRightLabel.Name = "conDetRightLabel";
            conDetRightLabel.Size = new Size(50, 15);
            conDetRightLabel.TabIndex = 8;
            conDetRightLabel.Text = "Put/Call";
            // 
            // conDetStrikeLabel
            // 
            conDetStrikeLabel.AutoSize = true;
            conDetStrikeLabel.Location = new Point(273, 80);
            conDetStrikeLabel.Margin = new Padding(4, 0, 4, 0);
            conDetStrikeLabel.Name = "conDetStrikeLabel";
            conDetStrikeLabel.Size = new Size(36, 15);
            conDetStrikeLabel.TabIndex = 14;
            conDetStrikeLabel.Text = "Strike";
            // 
            // conDetRight
            // 
            conDetRight.FormattingEnabled = true;
            conDetRight.Location = new Point(100, 147);
            conDetRight.Margin = new Padding(4, 3, 4, 3);
            conDetRight.Name = "conDetRight";
            conDetRight.Size = new Size(116, 23);
            conDetRight.TabIndex = 9;
            // 
            // conDetLastTradeDateLabel
            // 
            conDetLastTradeDateLabel.Location = new Point(224, 32);
            conDetLastTradeDateLabel.Margin = new Padding(4, 0, 4, 0);
            conDetLastTradeDateLabel.Name = "conDetLastTradeDateLabel";
            conDetLastTradeDateLabel.Size = new Size(100, 38);
            conDetLastTradeDateLabel.TabIndex = 12;
            conDetLastTradeDateLabel.Text = "Last trade date / contract month";
            // 
            // conDetSecType
            // 
            conDetSecType.FormattingEnabled = true;
            conDetSecType.Items.AddRange(new object[] { "STK", "OPT", "FUT", "CONTFUT", "CASH", "BOND", "CFD", "FOP", "WAR", "IOPT", "FWD", "BAG", "IND", "BILL", "FUND", "FIXED", "SLB", "NEWS", "CMDTY", "BSK", "ICU", "ICS", "CRYPTO" });
            conDetSecType.Location = new Point(100, 55);
            conDetSecType.Margin = new Padding(4, 3, 4, 3);
            conDetSecType.Name = "conDetSecType";
            conDetSecType.Size = new Size(116, 23);
            conDetSecType.TabIndex = 3;
            conDetSecType.Text = "STK";
            // 
            // conDetMultiplierLabel
            // 
            conDetMultiplierLabel.AutoSize = true;
            conDetMultiplierLabel.Location = new Point(257, 15);
            conDetMultiplierLabel.Margin = new Padding(4, 0, 4, 0);
            conDetMultiplierLabel.Name = "conDetMultiplierLabel";
            conDetMultiplierLabel.Size = new Size(58, 15);
            conDetMultiplierLabel.TabIndex = 10;
            conDetMultiplierLabel.Text = "Multiplier";
            // 
            // conDetSecTypeLabel
            // 
            conDetSecTypeLabel.AutoSize = true;
            conDetSecTypeLabel.Location = new Point(13, 55);
            conDetSecTypeLabel.Margin = new Padding(4, 0, 4, 0);
            conDetSecTypeLabel.Name = "conDetSecTypeLabel";
            conDetSecTypeLabel.Size = new Size(49, 15);
            conDetSecTypeLabel.TabIndex = 2;
            conDetSecTypeLabel.Text = "SecType";
            // 
            // conDetLocalSymbolLabel
            // 
            conDetLocalSymbolLabel.AutoSize = true;
            conDetLocalSymbolLabel.Location = new Point(231, 110);
            conDetLocalSymbolLabel.Margin = new Padding(4, 0, 4, 0);
            conDetLocalSymbolLabel.Name = "conDetLocalSymbolLabel";
            conDetLocalSymbolLabel.Size = new Size(78, 15);
            conDetLocalSymbolLabel.TabIndex = 16;
            conDetLocalSymbolLabel.Text = "Local Symbol";
            // 
            // conDetExchangeLabel
            // 
            conDetExchangeLabel.AutoSize = true;
            conDetExchangeLabel.Location = new Point(7, 117);
            conDetExchangeLabel.Margin = new Padding(4, 0, 4, 0);
            conDetExchangeLabel.Name = "conDetExchangeLabel";
            conDetExchangeLabel.Size = new Size(58, 15);
            conDetExchangeLabel.TabIndex = 6;
            conDetExchangeLabel.Text = "Exchange";
            // 
            // conDetExchange
            // 
            conDetExchange.Location = new Point(100, 117);
            conDetExchange.Margin = new Padding(4, 3, 4, 3);
            conDetExchange.Name = "conDetExchange";
            conDetExchange.Size = new Size(116, 23);
            conDetExchange.TabIndex = 7;
            conDetExchange.Text = "SMART";
            // 
            // conDetLocalSymbol
            // 
            conDetLocalSymbol.Location = new Point(331, 105);
            conDetLocalSymbol.Margin = new Padding(4, 3, 4, 3);
            conDetLocalSymbol.Name = "conDetLocalSymbol";
            conDetLocalSymbol.Size = new Size(116, 23);
            conDetLocalSymbol.TabIndex = 17;
            // 
            // conDetMultiplier
            // 
            conDetMultiplier.Location = new Point(331, 15);
            conDetMultiplier.Margin = new Padding(4, 3, 4, 3);
            conDetMultiplier.Name = "conDetMultiplier";
            conDetMultiplier.Size = new Size(116, 23);
            conDetMultiplier.TabIndex = 11;
            // 
            // conDetCurrencyLabel
            // 
            conDetCurrencyLabel.AutoSize = true;
            conDetCurrencyLabel.Location = new Point(14, 87);
            conDetCurrencyLabel.Margin = new Padding(4, 0, 4, 0);
            conDetCurrencyLabel.Name = "conDetCurrencyLabel";
            conDetCurrencyLabel.Size = new Size(55, 15);
            conDetCurrencyLabel.TabIndex = 4;
            conDetCurrencyLabel.Text = "Currency";
            // 
            // conDetCurrency
            // 
            conDetCurrency.Location = new Point(100, 87);
            conDetCurrency.Margin = new Padding(4, 3, 4, 3);
            conDetCurrency.Name = "conDetCurrency";
            conDetCurrency.Size = new Size(116, 23);
            conDetCurrency.TabIndex = 5;
            conDetCurrency.Text = "USD";
            // 
            // conDetLastTradeDateOrContractMonth
            // 
            conDetLastTradeDateOrContractMonth.Location = new Point(331, 45);
            conDetLastTradeDateOrContractMonth.Margin = new Padding(4, 3, 4, 3);
            conDetLastTradeDateOrContractMonth.Name = "conDetLastTradeDateOrContractMonth";
            conDetLastTradeDateOrContractMonth.Size = new Size(116, 23);
            conDetLastTradeDateOrContractMonth.TabIndex = 13;
            // 
            // conDetStrike
            // 
            conDetStrike.Location = new Point(331, 75);
            conDetStrike.Margin = new Padding(4, 3, 4, 3);
            conDetStrike.Name = "conDetStrike";
            conDetStrike.Size = new Size(116, 23);
            conDetStrike.TabIndex = 15;
            conDetStrike.Text = "10";
            // 
            // conDetSymbol
            // 
            conDetSymbol.Location = new Point(100, 27);
            conDetSymbol.Margin = new Padding(4, 3, 4, 3);
            conDetSymbol.Name = "conDetSymbol";
            conDetSymbol.Size = new Size(116, 23);
            conDetSymbol.TabIndex = 1;
            conDetSymbol.Text = "AAPL";
            // 
            // contractInfoTab
            // 
            contractInfoTab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contractInfoTab.Controls.Add(contractDetailsPage);
            contractInfoTab.Controls.Add(fundamentalsPage);
            contractInfoTab.Controls.Add(optionChainPage);
            contractInfoTab.Controls.Add(optionParametersPage);
            contractInfoTab.Controls.Add(symbolSamplesTabContractInfo);
            contractInfoTab.Controls.Add(bondContractDetailsPage);
            contractInfoTab.Controls.Add(marketRulePage);
            contractInfoTab.Location = new Point(7, 213);
            contractInfoTab.Margin = new Padding(4, 3, 4, 3);
            contractInfoTab.Name = "contractInfoTab";
            contractInfoTab.SelectedIndex = 0;
            contractInfoTab.Size = new Size(1442, 310);
            contractInfoTab.TabIndex = 32;
            // 
            // contractDetailsPage
            // 
            contractDetailsPage.BackColor = Color.LightGray;
            contractDetailsPage.Controls.Add(contractDetailsGrid);
            contractDetailsPage.Location = new Point(4, 24);
            contractDetailsPage.Margin = new Padding(4, 3, 4, 3);
            contractDetailsPage.Name = "contractDetailsPage";
            contractDetailsPage.Padding = new Padding(4, 3, 4, 3);
            contractDetailsPage.Size = new Size(1434, 282);
            contractDetailsPage.TabIndex = 0;
            contractDetailsPage.Text = "Contract Details";
            // 
            // contractDetailsGrid
            // 
            contractDetailsGrid.AllowUserToAddRows = false;
            contractDetailsGrid.AllowUserToDeleteRows = false;
            contractDetailsGrid.AllowUserToOrderColumns = true;
            contractDetailsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            contractDetailsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            contractDetailsGrid.Columns.AddRange(new DataGridViewColumn[] { conResSymbol, conResLocalSymbol, conResSecType, conResCurrency, conResExchange, conResPrimaryExch, conResLastTradeDate, conResMultiplier, conResStrike, conResRight, conResConId, conResAggGroup, conResUnderSymbol, conResUnderSecType, conResMarketRuleIds, conResRealExpirationDate, conResContractMonth, conResLastTradeTime, conResTimeZoneId, conResStockType, conResMinSize, conResSizeIncrement, conResSuggestedSizeIncrement });
            contractDetailsGrid.Location = new Point(7, 7);
            contractDetailsGrid.Margin = new Padding(4, 3, 4, 3);
            contractDetailsGrid.Name = "contractDetailsGrid";
            contractDetailsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            contractDetailsGrid.Size = new Size(1419, 264);
            contractDetailsGrid.TabIndex = 0;
            // 
            // conResSymbol
            // 
            conResSymbol.HeaderText = "Symbol";
            conResSymbol.Name = "conResSymbol";
            conResSymbol.ReadOnly = true;
            // 
            // conResLocalSymbol
            // 
            conResLocalSymbol.HeaderText = "Local Symbol";
            conResLocalSymbol.Name = "conResLocalSymbol";
            conResLocalSymbol.ReadOnly = true;
            // 
            // conResSecType
            // 
            conResSecType.HeaderText = "Type";
            conResSecType.Name = "conResSecType";
            conResSecType.ReadOnly = true;
            // 
            // conResCurrency
            // 
            conResCurrency.HeaderText = "Currency";
            conResCurrency.Name = "conResCurrency";
            conResCurrency.ReadOnly = true;
            // 
            // conResExchange
            // 
            conResExchange.HeaderText = "Exchange";
            conResExchange.Name = "conResExchange";
            conResExchange.ReadOnly = true;
            // 
            // conResPrimaryExch
            // 
            conResPrimaryExch.HeaderText = "Primary Exch.";
            conResPrimaryExch.Name = "conResPrimaryExch";
            conResPrimaryExch.ReadOnly = true;
            // 
            // conResLastTradeDate
            // 
            conResLastTradeDate.HeaderText = "LastTradeDate";
            conResLastTradeDate.Name = "conResLastTradeDate";
            conResLastTradeDate.ReadOnly = true;
            conResLastTradeDate.Width = 150;
            // 
            // conResMultiplier
            // 
            conResMultiplier.HeaderText = "Multiplier";
            conResMultiplier.Name = "conResMultiplier";
            conResMultiplier.ReadOnly = true;
            // 
            // conResStrike
            // 
            conResStrike.HeaderText = "Strike";
            conResStrike.Name = "conResStrike";
            conResStrike.ReadOnly = true;
            // 
            // conResRight
            // 
            conResRight.HeaderText = "P/C";
            conResRight.Name = "conResRight";
            conResRight.ReadOnly = true;
            // 
            // conResConId
            // 
            conResConId.HeaderText = "ConId";
            conResConId.Name = "conResConId";
            conResConId.ReadOnly = true;
            // 
            // conResAggGroup
            // 
            conResAggGroup.HeaderText = "Agg Group";
            conResAggGroup.Name = "conResAggGroup";
            // 
            // conResUnderSymbol
            // 
            conResUnderSymbol.HeaderText = "Under Symb";
            conResUnderSymbol.Name = "conResUnderSymbol";
            // 
            // conResUnderSecType
            // 
            conResUnderSecType.HeaderText = "Under SecType";
            conResUnderSecType.Name = "conResUnderSecType";
            conResUnderSecType.Width = 120;
            // 
            // conResMarketRuleIds
            // 
            conResMarketRuleIds.HeaderText = "Market Rule Ids";
            conResMarketRuleIds.Name = "conResMarketRuleIds";
            conResMarketRuleIds.Width = 300;
            // 
            // conResRealExpirationDate
            // 
            conResRealExpirationDate.HeaderText = "Real Exp Date";
            conResRealExpirationDate.Name = "conResRealExpirationDate";
            // 
            // conResContractMonth
            // 
            conResContractMonth.HeaderText = "Contract Month";
            conResContractMonth.Name = "conResContractMonth";
            // 
            // conResLastTradeTime
            // 
            conResLastTradeTime.HeaderText = "Last Trade Time";
            conResLastTradeTime.Name = "conResLastTradeTime";
            // 
            // conResTimeZoneId
            // 
            conResTimeZoneId.HeaderText = "Time Zone";
            conResTimeZoneId.Name = "conResTimeZoneId";
            // 
            // conResStockType
            // 
            conResStockType.HeaderText = "Stock Type";
            conResStockType.Name = "conResStockType";
            // 
            // conResMinSize
            // 
            conResMinSize.HeaderText = "Min Size";
            conResMinSize.Name = "conResMinSize";
            // 
            // conResSizeIncrement
            // 
            conResSizeIncrement.HeaderText = "Size Incr";
            conResSizeIncrement.Name = "conResSizeIncrement";
            // 
            // conResSuggestedSizeIncrement
            // 
            conResSuggestedSizeIncrement.HeaderText = "Sugg Size Incr";
            conResSuggestedSizeIncrement.Name = "conResSuggestedSizeIncrement";
            // 
            // fundamentalsPage
            // 
            fundamentalsPage.BackColor = Color.LightGray;
            fundamentalsPage.Controls.Add(fundamentalsOutput);
            fundamentalsPage.Location = new Point(4, 24);
            fundamentalsPage.Margin = new Padding(4, 3, 4, 3);
            fundamentalsPage.Name = "fundamentalsPage";
            fundamentalsPage.Padding = new Padding(4, 3, 4, 3);
            fundamentalsPage.Size = new Size(1434, 282);
            fundamentalsPage.TabIndex = 1;
            fundamentalsPage.Text = "Fundamentals";
            // 
            // fundamentalsOutput
            // 
            fundamentalsOutput.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fundamentalsOutput.Location = new Point(7, 7);
            fundamentalsOutput.Margin = new Padding(4, 3, 4, 3);
            fundamentalsOutput.Multiline = true;
            fundamentalsOutput.Name = "fundamentalsOutput";
            fundamentalsOutput.ReadOnly = true;
            fundamentalsOutput.ScrollBars = ScrollBars.Vertical;
            fundamentalsOutput.Size = new Size(1418, 264);
            fundamentalsOutput.TabIndex = 0;
            // 
            // optionChainPage
            // 
            optionChainPage.BackColor = Color.LightGray;
            optionChainPage.Controls.Add(optionChainCallGroup);
            optionChainPage.Controls.Add(optionChainPutGroup);
            optionChainPage.Location = new Point(4, 24);
            optionChainPage.Margin = new Padding(4, 3, 4, 3);
            optionChainPage.Name = "optionChainPage";
            optionChainPage.Padding = new Padding(4, 3, 4, 3);
            optionChainPage.Size = new Size(1434, 282);
            optionChainPage.TabIndex = 2;
            optionChainPage.Text = "Options chain";
            // 
            // optionChainCallGroup
            // 
            optionChainCallGroup.Controls.Add(optionChainCallGrid);
            optionChainCallGroup.Location = new Point(7, 7);
            optionChainCallGroup.Margin = new Padding(4, 3, 4, 3);
            optionChainCallGroup.Name = "optionChainCallGroup";
            optionChainCallGroup.Padding = new Padding(4, 3, 4, 3);
            optionChainCallGroup.Size = new Size(688, 267);
            optionChainCallGroup.TabIndex = 43;
            optionChainCallGroup.TabStop = false;
            optionChainCallGroup.Text = "Calls";
            // 
            // optionChainCallGrid
            // 
            optionChainCallGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            optionChainCallGrid.Columns.AddRange(new DataGridViewColumn[] { callLastTradeDate, callStrike, callBid, callAsk, callImpliedVolatility, callDelta, callGamma, callVega, callTheta });
            optionChainCallGrid.Location = new Point(7, 22);
            optionChainCallGrid.Margin = new Padding(4, 3, 4, 3);
            optionChainCallGrid.Name = "optionChainCallGrid";
            optionChainCallGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            optionChainCallGrid.Size = new Size(672, 238);
            optionChainCallGrid.TabIndex = 40;
            // 
            // callLastTradeDate
            // 
            callLastTradeDate.HeaderText = "lastTradeDate";
            callLastTradeDate.Name = "callLastTradeDate";
            callLastTradeDate.Width = 70;
            // 
            // callStrike
            // 
            callStrike.HeaderText = "Strike";
            callStrike.Name = "callStrike";
            callStrike.Width = 50;
            // 
            // callBid
            // 
            callBid.HeaderText = "Bid";
            callBid.Name = "callBid";
            callBid.ReadOnly = true;
            callBid.Width = 50;
            // 
            // callAsk
            // 
            callAsk.HeaderText = "Ask";
            callAsk.Name = "callAsk";
            callAsk.ReadOnly = true;
            callAsk.Width = 50;
            // 
            // callImpliedVolatility
            // 
            callImpliedVolatility.HeaderText = "Imp. Vol.";
            callImpliedVolatility.Name = "callImpliedVolatility";
            callImpliedVolatility.ReadOnly = true;
            callImpliedVolatility.Width = 80;
            // 
            // callDelta
            // 
            callDelta.HeaderText = "Delta";
            callDelta.Name = "callDelta";
            callDelta.ReadOnly = true;
            callDelta.Width = 50;
            // 
            // callGamma
            // 
            callGamma.HeaderText = "Gamma";
            callGamma.Name = "callGamma";
            callGamma.ReadOnly = true;
            callGamma.Width = 50;
            // 
            // callVega
            // 
            callVega.HeaderText = "Vega";
            callVega.Name = "callVega";
            callVega.ReadOnly = true;
            callVega.Width = 50;
            // 
            // callTheta
            // 
            callTheta.HeaderText = "Theta";
            callTheta.Name = "callTheta";
            callTheta.ReadOnly = true;
            callTheta.Width = 50;
            // 
            // optionChainPutGroup
            // 
            optionChainPutGroup.Controls.Add(optionChainPutGrid);
            optionChainPutGroup.Location = new Point(726, 7);
            optionChainPutGroup.Margin = new Padding(4, 3, 4, 3);
            optionChainPutGroup.Name = "optionChainPutGroup";
            optionChainPutGroup.Padding = new Padding(4, 3, 4, 3);
            optionChainPutGroup.Size = new Size(690, 267);
            optionChainPutGroup.TabIndex = 42;
            optionChainPutGroup.TabStop = false;
            optionChainPutGroup.Text = "Puts";
            // 
            // optionChainPutGrid
            // 
            optionChainPutGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            optionChainPutGrid.Columns.AddRange(new DataGridViewColumn[] { putLastTradeDate, putStrike, putBid, putAsk, putImpliedVolatility, putDelta, putGamma, putVega, putTheta });
            optionChainPutGrid.Location = new Point(7, 22);
            optionChainPutGrid.Margin = new Padding(4, 3, 4, 3);
            optionChainPutGrid.Name = "optionChainPutGrid";
            optionChainPutGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            optionChainPutGrid.Size = new Size(676, 238);
            optionChainPutGrid.TabIndex = 41;
            // 
            // putLastTradeDate
            // 
            putLastTradeDate.HeaderText = "lastTradeDate";
            putLastTradeDate.Name = "putLastTradeDate";
            putLastTradeDate.Width = 70;
            // 
            // putStrike
            // 
            putStrike.HeaderText = "Strike";
            putStrike.Name = "putStrike";
            putStrike.Width = 50;
            // 
            // putBid
            // 
            putBid.HeaderText = "Bid";
            putBid.Name = "putBid";
            putBid.ReadOnly = true;
            putBid.Width = 50;
            // 
            // putAsk
            // 
            putAsk.HeaderText = "Ask";
            putAsk.Name = "putAsk";
            putAsk.ReadOnly = true;
            putAsk.Width = 50;
            // 
            // putImpliedVolatility
            // 
            putImpliedVolatility.HeaderText = "Imp. Vol.";
            putImpliedVolatility.Name = "putImpliedVolatility";
            putImpliedVolatility.ReadOnly = true;
            putImpliedVolatility.Width = 80;
            // 
            // putDelta
            // 
            putDelta.HeaderText = "Delta";
            putDelta.Name = "putDelta";
            putDelta.ReadOnly = true;
            putDelta.Width = 50;
            // 
            // putGamma
            // 
            putGamma.HeaderText = "Gamma";
            putGamma.Name = "putGamma";
            putGamma.ReadOnly = true;
            putGamma.Width = 50;
            // 
            // putVega
            // 
            putVega.HeaderText = "Vega";
            putVega.Name = "putVega";
            putVega.ReadOnly = true;
            putVega.Width = 50;
            // 
            // putTheta
            // 
            putTheta.HeaderText = "Theta";
            putTheta.Name = "putTheta";
            putTheta.ReadOnly = true;
            putTheta.Width = 50;
            // 
            // optionParametersPage
            // 
            optionParametersPage.Controls.Add(listViewOptionParams);
            optionParametersPage.Location = new Point(4, 24);
            optionParametersPage.Margin = new Padding(4, 3, 4, 3);
            optionParametersPage.Name = "optionParametersPage";
            optionParametersPage.Size = new Size(1434, 282);
            optionParametersPage.TabIndex = 3;
            optionParametersPage.Text = "Option parameters";
            optionParametersPage.UseVisualStyleBackColor = true;
            // 
            // listViewOptionParams
            // 
            listViewOptionParams.Columns.AddRange(new ColumnHeader[] { columnHeader1, columnHeader2 });
            listViewOptionParams.Dock = DockStyle.Fill;
            listViewOptionParams.Location = new Point(0, 0);
            listViewOptionParams.Margin = new Padding(4, 3, 4, 3);
            listViewOptionParams.Name = "listViewOptionParams";
            listViewOptionParams.Size = new Size(1434, 282);
            listViewOptionParams.TabIndex = 0;
            listViewOptionParams.UseCompatibleStateImageBehavior = false;
            listViewOptionParams.View = View.Details;
            // 
            // columnHeader1
            // 
            columnHeader1.Text = "Expirations";
            columnHeader1.Width = 141;
            // 
            // columnHeader2
            // 
            columnHeader2.Text = "Strikes";
            columnHeader2.Width = 71;
            // 
            // symbolSamplesTabContractInfo
            // 
            symbolSamplesTabContractInfo.BackColor = Color.LightGray;
            symbolSamplesTabContractInfo.Controls.Add(clearSymbolSamplesContractInfo);
            symbolSamplesTabContractInfo.Controls.Add(symbolSamplesDataGridContractInfo);
            symbolSamplesTabContractInfo.Location = new Point(4, 24);
            symbolSamplesTabContractInfo.Margin = new Padding(4, 3, 4, 3);
            symbolSamplesTabContractInfo.Name = "symbolSamplesTabContractInfo";
            symbolSamplesTabContractInfo.Padding = new Padding(4, 3, 4, 3);
            symbolSamplesTabContractInfo.Size = new Size(1434, 282);
            symbolSamplesTabContractInfo.TabIndex = 4;
            symbolSamplesTabContractInfo.Text = "Symbol Samples";
            // 
            // clearSymbolSamplesContractInfo
            // 
            clearSymbolSamplesContractInfo.AutoSize = true;
            clearSymbolSamplesContractInfo.Location = new Point(5, 7);
            clearSymbolSamplesContractInfo.Margin = new Padding(4, 0, 4, 0);
            clearSymbolSamplesContractInfo.Name = "clearSymbolSamplesContractInfo";
            clearSymbolSamplesContractInfo.Size = new Size(34, 15);
            clearSymbolSamplesContractInfo.TabIndex = 5;
            clearSymbolSamplesContractInfo.TabStop = true;
            clearSymbolSamplesContractInfo.Text = "Clear";
            clearSymbolSamplesContractInfo.LinkClicked += clearSymbolSamplesContractInfo_LinkClicked;
            // 
            // symbolSamplesDataGridContractInfo
            // 
            symbolSamplesDataGridContractInfo.AllowUserToAddRows = false;
            symbolSamplesDataGridContractInfo.AllowUserToDeleteRows = false;
            symbolSamplesDataGridContractInfo.AllowUserToOrderColumns = true;
            symbolSamplesDataGridContractInfo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            symbolSamplesDataGridContractInfo.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            symbolSamplesDataGridContractInfo.Columns.AddRange(new DataGridViewColumn[] { symbolSamplesConId2, symbolSamplesSymbol2, symbolSamplesSecType2, symbolSamplesPrimExch2, symbolSamplesCurrency2, dataGridViewTextBoxColumn14, symbolSamplesDescription2, symbolSamplesIssuerId2 });
            symbolSamplesDataGridContractInfo.Location = new Point(4, 25);
            symbolSamplesDataGridContractInfo.Margin = new Padding(4, 3, 4, 3);
            symbolSamplesDataGridContractInfo.Name = "symbolSamplesDataGridContractInfo";
            symbolSamplesDataGridContractInfo.ReadOnly = true;
            symbolSamplesDataGridContractInfo.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            symbolSamplesDataGridContractInfo.Size = new Size(1377, 246);
            symbolSamplesDataGridContractInfo.TabIndex = 4;
            symbolSamplesDataGridContractInfo.Visible = false;
            // 
            // symbolSamplesConId2
            // 
            symbolSamplesConId2.HeaderText = "ConId";
            symbolSamplesConId2.Name = "symbolSamplesConId2";
            symbolSamplesConId2.ReadOnly = true;
            // 
            // symbolSamplesSymbol2
            // 
            symbolSamplesSymbol2.HeaderText = "Symbol";
            symbolSamplesSymbol2.Name = "symbolSamplesSymbol2";
            symbolSamplesSymbol2.ReadOnly = true;
            // 
            // symbolSamplesSecType2
            // 
            symbolSamplesSecType2.HeaderText = "SecType";
            symbolSamplesSecType2.Name = "symbolSamplesSecType2";
            symbolSamplesSecType2.ReadOnly = true;
            // 
            // symbolSamplesPrimExch2
            // 
            symbolSamplesPrimExch2.HeaderText = "Prim Exch";
            symbolSamplesPrimExch2.Name = "symbolSamplesPrimExch2";
            symbolSamplesPrimExch2.ReadOnly = true;
            // 
            // symbolSamplesCurrency2
            // 
            symbolSamplesCurrency2.HeaderText = "Currency";
            symbolSamplesCurrency2.Name = "symbolSamplesCurrency2";
            symbolSamplesCurrency2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            dataGridViewTextBoxColumn14.HeaderText = "Derivative Sec Types";
            dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            dataGridViewTextBoxColumn14.ReadOnly = true;
            dataGridViewTextBoxColumn14.Width = 200;
            // 
            // symbolSamplesDescription2
            // 
            symbolSamplesDescription2.HeaderText = "Description";
            symbolSamplesDescription2.Name = "symbolSamplesDescription2";
            symbolSamplesDescription2.ReadOnly = true;
            symbolSamplesDescription2.Width = 300;
            // 
            // symbolSamplesIssuerId2
            // 
            symbolSamplesIssuerId2.HeaderText = "Issuer Id";
            symbolSamplesIssuerId2.Name = "symbolSamplesIssuerId2";
            symbolSamplesIssuerId2.ReadOnly = true;
            // 
            // bondContractDetailsPage
            // 
            bondContractDetailsPage.BackColor = Color.LightGray;
            bondContractDetailsPage.Controls.Add(bondContractDetailsGrid);
            bondContractDetailsPage.Location = new Point(4, 24);
            bondContractDetailsPage.Margin = new Padding(4, 3, 4, 3);
            bondContractDetailsPage.Name = "bondContractDetailsPage";
            bondContractDetailsPage.Padding = new Padding(4, 3, 4, 3);
            bondContractDetailsPage.Size = new Size(1434, 282);
            bondContractDetailsPage.TabIndex = 4;
            bondContractDetailsPage.Text = "Bond Contract Details";
            // 
            // bondContractDetailsGrid
            // 
            bondContractDetailsGrid.AllowUserToAddRows = false;
            bondContractDetailsGrid.AllowUserToDeleteRows = false;
            bondContractDetailsGrid.AllowUserToOrderColumns = true;
            bondContractDetailsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            bondContractDetailsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            bondContractDetailsGrid.Columns.AddRange(new DataGridViewColumn[] { bondContractDetailsConId, bondContractDetailsSymbol, bondContractDetailsExchange, bondContractDetailsCurrency, bondContractDetailsTradingClass, bondContractDetailsMarketName, bondContractDetailsMinTick, bondContractDetailsOrderTypes, bondContractDetailsValidExchanges, bondContractDetailsLongName, bondContractDetailsAggGroup, bondContractDetailsMarketRuleIds, bondContractDetailsCusip, bondContractDetailsRatings, bondContractDetailsDescAppend, bondContractDetailsBondType, bondContractDetailsCouponType, bondContractDetailsCallable, bondContractDetailsPutable, bondContractDetailsCoupon, bondContractDetailsConvertible, bondContractDetailsMaturity, bondContractDetailsIssueDate, bondContractDetailsNextOptionDate, bondContractDetailsNextOptionType, bondContractDetailsNextOptionPartial, bondContractDetailsNotes, bondContractDetailsLastTradeTime, bondContractDetsilsTimeZoneId, bondContractDetailsMinSize, bondContractDetailsSizeIncrement, bondContractDetailsSuggestedSizeIncrement });
            bondContractDetailsGrid.Location = new Point(7, 7);
            bondContractDetailsGrid.Margin = new Padding(4, 3, 4, 3);
            bondContractDetailsGrid.Name = "bondContractDetailsGrid";
            bondContractDetailsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bondContractDetailsGrid.Size = new Size(1419, 264);
            bondContractDetailsGrid.TabIndex = 1;
            // 
            // bondContractDetailsConId
            // 
            bondContractDetailsConId.HeaderText = "ConId";
            bondContractDetailsConId.Name = "bondContractDetailsConId";
            bondContractDetailsConId.ReadOnly = true;
            // 
            // bondContractDetailsSymbol
            // 
            bondContractDetailsSymbol.HeaderText = "Symbol";
            bondContractDetailsSymbol.Name = "bondContractDetailsSymbol";
            // 
            // bondContractDetailsExchange
            // 
            bondContractDetailsExchange.HeaderText = "Exchange";
            bondContractDetailsExchange.Name = "bondContractDetailsExchange";
            // 
            // bondContractDetailsCurrency
            // 
            bondContractDetailsCurrency.HeaderText = "Currency";
            bondContractDetailsCurrency.Name = "bondContractDetailsCurrency";
            // 
            // bondContractDetailsTradingClass
            // 
            bondContractDetailsTradingClass.HeaderText = "TradingClass";
            bondContractDetailsTradingClass.Name = "bondContractDetailsTradingClass";
            // 
            // bondContractDetailsMarketName
            // 
            bondContractDetailsMarketName.HeaderText = "MarketName";
            bondContractDetailsMarketName.Name = "bondContractDetailsMarketName";
            // 
            // bondContractDetailsMinTick
            // 
            bondContractDetailsMinTick.HeaderText = "MinTick";
            bondContractDetailsMinTick.Name = "bondContractDetailsMinTick";
            // 
            // bondContractDetailsOrderTypes
            // 
            bondContractDetailsOrderTypes.HeaderText = "OrderTypes";
            bondContractDetailsOrderTypes.Name = "bondContractDetailsOrderTypes";
            // 
            // bondContractDetailsValidExchanges
            // 
            bondContractDetailsValidExchanges.HeaderText = "ValidExchanges";
            bondContractDetailsValidExchanges.Name = "bondContractDetailsValidExchanges";
            // 
            // bondContractDetailsLongName
            // 
            bondContractDetailsLongName.HeaderText = "LongName";
            bondContractDetailsLongName.Name = "bondContractDetailsLongName";
            // 
            // bondContractDetailsAggGroup
            // 
            bondContractDetailsAggGroup.HeaderText = "Agg Group";
            bondContractDetailsAggGroup.Name = "bondContractDetailsAggGroup";
            // 
            // bondContractDetailsMarketRuleIds
            // 
            bondContractDetailsMarketRuleIds.HeaderText = "Market Rule Ids";
            bondContractDetailsMarketRuleIds.Name = "bondContractDetailsMarketRuleIds";
            // 
            // bondContractDetailsCusip
            // 
            bondContractDetailsCusip.HeaderText = "Cusip";
            bondContractDetailsCusip.Name = "bondContractDetailsCusip";
            // 
            // bondContractDetailsRatings
            // 
            bondContractDetailsRatings.HeaderText = "Ratings";
            bondContractDetailsRatings.Name = "bondContractDetailsRatings";
            // 
            // bondContractDetailsDescAppend
            // 
            bondContractDetailsDescAppend.HeaderText = "DescAppend";
            bondContractDetailsDescAppend.Name = "bondContractDetailsDescAppend";
            // 
            // bondContractDetailsBondType
            // 
            bondContractDetailsBondType.HeaderText = "BondType";
            bondContractDetailsBondType.Name = "bondContractDetailsBondType";
            // 
            // bondContractDetailsCouponType
            // 
            bondContractDetailsCouponType.HeaderText = "CouponType";
            bondContractDetailsCouponType.Name = "bondContractDetailsCouponType";
            // 
            // bondContractDetailsCallable
            // 
            bondContractDetailsCallable.HeaderText = "Callable";
            bondContractDetailsCallable.Name = "bondContractDetailsCallable";
            // 
            // bondContractDetailsPutable
            // 
            bondContractDetailsPutable.HeaderText = "Putable";
            bondContractDetailsPutable.Name = "bondContractDetailsPutable";
            // 
            // bondContractDetailsCoupon
            // 
            bondContractDetailsCoupon.HeaderText = "Coupon";
            bondContractDetailsCoupon.Name = "bondContractDetailsCoupon";
            // 
            // bondContractDetailsConvertible
            // 
            bondContractDetailsConvertible.HeaderText = "Convertible";
            bondContractDetailsConvertible.Name = "bondContractDetailsConvertible";
            // 
            // bondContractDetailsMaturity
            // 
            bondContractDetailsMaturity.HeaderText = "Maturity";
            bondContractDetailsMaturity.Name = "bondContractDetailsMaturity";
            // 
            // bondContractDetailsIssueDate
            // 
            bondContractDetailsIssueDate.HeaderText = "IsuueDate";
            bondContractDetailsIssueDate.Name = "bondContractDetailsIssueDate";
            // 
            // bondContractDetailsNextOptionDate
            // 
            bondContractDetailsNextOptionDate.HeaderText = "NextOptionDate";
            bondContractDetailsNextOptionDate.Name = "bondContractDetailsNextOptionDate";
            // 
            // bondContractDetailsNextOptionType
            // 
            bondContractDetailsNextOptionType.HeaderText = "NextOptionType";
            bondContractDetailsNextOptionType.Name = "bondContractDetailsNextOptionType";
            // 
            // bondContractDetailsNextOptionPartial
            // 
            bondContractDetailsNextOptionPartial.HeaderText = "NextOptionPartial";
            bondContractDetailsNextOptionPartial.Name = "bondContractDetailsNextOptionPartial";
            // 
            // bondContractDetailsNotes
            // 
            bondContractDetailsNotes.HeaderText = "Notes";
            bondContractDetailsNotes.Name = "bondContractDetailsNotes";
            // 
            // bondContractDetailsLastTradeTime
            // 
            bondContractDetailsLastTradeTime.HeaderText = "Last Trade Time";
            bondContractDetailsLastTradeTime.Name = "bondContractDetailsLastTradeTime";
            // 
            // bondContractDetsilsTimeZoneId
            // 
            bondContractDetsilsTimeZoneId.HeaderText = "Time Zone";
            bondContractDetsilsTimeZoneId.Name = "bondContractDetsilsTimeZoneId";
            // 
            // bondContractDetailsMinSize
            // 
            bondContractDetailsMinSize.HeaderText = "Min Size";
            bondContractDetailsMinSize.Name = "bondContractDetailsMinSize";
            // 
            // bondContractDetailsSizeIncrement
            // 
            bondContractDetailsSizeIncrement.HeaderText = "Size Incr";
            bondContractDetailsSizeIncrement.Name = "bondContractDetailsSizeIncrement";
            // 
            // bondContractDetailsSuggestedSizeIncrement
            // 
            bondContractDetailsSuggestedSizeIncrement.HeaderText = "Sugg Size Incr";
            bondContractDetailsSuggestedSizeIncrement.Name = "bondContractDetailsSuggestedSizeIncrement";
            // 
            // marketRulePage
            // 
            marketRulePage.BackColor = Color.LightGray;
            marketRulePage.Controls.Add(labelMarketRuleIdRes);
            marketRulePage.Controls.Add(dataGridViewMarketRule);
            marketRulePage.Location = new Point(4, 24);
            marketRulePage.Margin = new Padding(4, 3, 4, 3);
            marketRulePage.Name = "marketRulePage";
            marketRulePage.Size = new Size(1434, 282);
            marketRulePage.TabIndex = 5;
            marketRulePage.Text = "Market Rule";
            // 
            // labelMarketRuleIdRes
            // 
            labelMarketRuleIdRes.AutoSize = true;
            labelMarketRuleIdRes.Location = new Point(8, 6);
            labelMarketRuleIdRes.Margin = new Padding(4, 0, 4, 0);
            labelMarketRuleIdRes.Name = "labelMarketRuleIdRes";
            labelMarketRuleIdRes.Size = new Size(83, 15);
            labelMarketRuleIdRes.TabIndex = 50;
            labelMarketRuleIdRes.Text = "Market Rule Id";
            // 
            // dataGridViewMarketRule
            // 
            dataGridViewMarketRule.AllowUserToAddRows = false;
            dataGridViewMarketRule.AllowUserToDeleteRows = false;
            dataGridViewMarketRule.AllowUserToOrderColumns = true;
            dataGridViewMarketRule.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewMarketRule.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewMarketRule.Columns.AddRange(new DataGridViewColumn[] { dataGridViewPriceIncrementLowEdge, dataGridViewPriceIncrementIncrement });
            dataGridViewMarketRule.Location = new Point(5, 24);
            dataGridViewMarketRule.Margin = new Padding(4, 3, 4, 3);
            dataGridViewMarketRule.Name = "dataGridViewMarketRule";
            dataGridViewMarketRule.ReadOnly = true;
            dataGridViewMarketRule.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewMarketRule.Size = new Size(306, 246);
            dataGridViewMarketRule.TabIndex = 7;
            // 
            // dataGridViewPriceIncrementLowEdge
            // 
            dataGridViewPriceIncrementLowEdge.HeaderText = "Low Edge";
            dataGridViewPriceIncrementLowEdge.Name = "dataGridViewPriceIncrementLowEdge";
            dataGridViewPriceIncrementLowEdge.ReadOnly = true;
            // 
            // dataGridViewPriceIncrementIncrement
            // 
            dataGridViewPriceIncrementIncrement.HeaderText = "Increment";
            dataGridViewPriceIncrementIncrement.Name = "dataGridViewPriceIncrementIncrement";
            dataGridViewPriceIncrementIncrement.ReadOnly = true;
            // 
            // accountInfoTab
            // 
            accountInfoTab.BackColor = Color.LightGray;
            accountInfoTab.Controls.Add(reqUserInfo);
            accountInfoTab.Controls.Add(tabControl1);
            accountInfoTab.Controls.Add(accountSelectorLabel);
            accountInfoTab.Controls.Add(accountSelector);
            accountInfoTab.Location = new Point(4, 24);
            accountInfoTab.Margin = new Padding(4, 3, 4, 3);
            accountInfoTab.Name = "accountInfoTab";
            accountInfoTab.Padding = new Padding(4, 3, 4, 3);
            accountInfoTab.Size = new Size(1457, 519);
            accountInfoTab.TabIndex = 3;
            accountInfoTab.Text = "Account Info";
            // 
            // reqUserInfo
            // 
            reqUserInfo.Location = new Point(293, 3);
            reqUserInfo.Margin = new Padding(4, 3, 4, 3);
            reqUserInfo.Name = "reqUserInfo";
            reqUserInfo.Size = new Size(88, 27);
            reqUserInfo.TabIndex = 2;
            reqUserInfo.Text = "User Info";
            reqUserInfo.UseVisualStyleBackColor = true;
            reqUserInfo.Click += reqUserInfo_Click;
            // 
            // tabControl1
            // 
            tabControl1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tabControl1.Controls.Add(accSummaryTab);
            tabControl1.Controls.Add(accUpdatesTab);
            tabControl1.Controls.Add(positionsTab);
            tabControl1.Controls.Add(familyCodesTab);
            tabControl1.Controls.Add(pnlTab);
            tabControl1.Location = new Point(7, 35);
            tabControl1.Margin = new Padding(4, 3, 4, 3);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1442, 489);
            tabControl1.TabIndex = 2;
            // 
            // accSummaryTab
            // 
            accSummaryTab.BackColor = Color.LightGray;
            accSummaryTab.Controls.Add(accSummaryRequest);
            accSummaryTab.Controls.Add(accSummaryGrid);
            accSummaryTab.Location = new Point(4, 24);
            accSummaryTab.Margin = new Padding(4, 3, 4, 3);
            accSummaryTab.Name = "accSummaryTab";
            accSummaryTab.Padding = new Padding(4, 3, 4, 3);
            accSummaryTab.Size = new Size(1434, 461);
            accSummaryTab.TabIndex = 0;
            accSummaryTab.Text = "Account Summary";
            // 
            // accSummaryRequest
            // 
            accSummaryRequest.Location = new Point(727, 7);
            accSummaryRequest.Margin = new Padding(4, 3, 4, 3);
            accSummaryRequest.Name = "accSummaryRequest";
            accSummaryRequest.Size = new Size(88, 27);
            accSummaryRequest.TabIndex = 1;
            accSummaryRequest.Text = "Request";
            accSummaryRequest.UseVisualStyleBackColor = true;
            accSummaryRequest.Click += accSummaryRequest_Click;
            // 
            // accSummaryGrid
            // 
            accSummaryGrid.AllowUserToAddRows = false;
            accSummaryGrid.AllowUserToDeleteRows = false;
            accSummaryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accSummaryGrid.Columns.AddRange(new DataGridViewColumn[] { tag, value, currency, accountSummaryAccount });
            accSummaryGrid.Location = new Point(7, 7);
            accSummaryGrid.Margin = new Padding(4, 3, 4, 3);
            accSummaryGrid.Name = "accSummaryGrid";
            accSummaryGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            accSummaryGrid.Size = new Size(713, 445);
            accSummaryGrid.TabIndex = 0;
            // 
            // tag
            // 
            tag.HeaderText = "Tag";
            tag.Name = "tag";
            tag.ReadOnly = true;
            tag.Width = 150;
            // 
            // value
            // 
            value.HeaderText = "Value";
            value.Name = "value";
            value.ReadOnly = true;
            value.Width = 150;
            // 
            // currency
            // 
            currency.HeaderText = "Currency";
            currency.Name = "currency";
            currency.ReadOnly = true;
            currency.Width = 150;
            // 
            // accountSummaryAccount
            // 
            accountSummaryAccount.HeaderText = "Account";
            accountSummaryAccount.Name = "accountSummaryAccount";
            accountSummaryAccount.ReadOnly = true;
            // 
            // accUpdatesTab
            // 
            accUpdatesTab.BackColor = Color.LightGray;
            accUpdatesTab.Controls.Add(accUpdatesSubscribedAccount);
            accUpdatesTab.Controls.Add(accUpdatesAccountLabel);
            accUpdatesTab.Controls.Add(accUpdatesLastUpdateValue);
            accUpdatesTab.Controls.Add(accountPortfolioGrid);
            accUpdatesTab.Controls.Add(accountValuesGrid);
            accUpdatesTab.Controls.Add(accUpdatesSubscribe);
            accUpdatesTab.Controls.Add(lastUpdatedLabel);
            accUpdatesTab.Location = new Point(4, 24);
            accUpdatesTab.Margin = new Padding(4, 3, 4, 3);
            accUpdatesTab.Name = "accUpdatesTab";
            accUpdatesTab.Padding = new Padding(4, 3, 4, 3);
            accUpdatesTab.Size = new Size(1434, 461);
            accUpdatesTab.TabIndex = 1;
            accUpdatesTab.Text = "Account Updates";
            // 
            // accUpdatesSubscribedAccount
            // 
            accUpdatesSubscribedAccount.AutoSize = true;
            accUpdatesSubscribedAccount.Location = new Point(167, 13);
            accUpdatesSubscribedAccount.Margin = new Padding(4, 0, 4, 0);
            accUpdatesSubscribedAccount.Name = "accUpdatesSubscribedAccount";
            accUpdatesSubscribedAccount.Size = new Size(16, 15);
            accUpdatesSubscribedAccount.TabIndex = 6;
            accUpdatesSubscribedAccount.Text = "...";
            // 
            // accUpdatesAccountLabel
            // 
            accUpdatesAccountLabel.AutoSize = true;
            accUpdatesAccountLabel.Location = new Point(102, 13);
            accUpdatesAccountLabel.Margin = new Padding(4, 0, 4, 0);
            accUpdatesAccountLabel.Name = "accUpdatesAccountLabel";
            accUpdatesAccountLabel.Size = new Size(55, 15);
            accUpdatesAccountLabel.TabIndex = 5;
            accUpdatesAccountLabel.Text = "Account:";
            // 
            // accUpdatesLastUpdateValue
            // 
            accUpdatesLastUpdateValue.AutoSize = true;
            accUpdatesLastUpdateValue.Location = new Point(354, 13);
            accUpdatesLastUpdateValue.Margin = new Padding(4, 0, 4, 0);
            accUpdatesLastUpdateValue.Name = "accUpdatesLastUpdateValue";
            accUpdatesLastUpdateValue.Size = new Size(16, 15);
            accUpdatesLastUpdateValue.TabIndex = 4;
            accUpdatesLastUpdateValue.Text = "...";
            // 
            // accountPortfolioGrid
            // 
            accountPortfolioGrid.AllowUserToAddRows = false;
            accountPortfolioGrid.AllowUserToDeleteRows = false;
            accountPortfolioGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountPortfolioGrid.Columns.AddRange(new DataGridViewColumn[] { updatePortfolioContract, updatePortfolioPosition, updatePortfolioMarketPrice, updatePortfolioMarketValue, updatePortfolioAvgCost, updatePortfolioUnrealizedPnL, updatePortfolioRealizedPnL });
            accountPortfolioGrid.Location = new Point(439, 40);
            accountPortfolioGrid.Margin = new Padding(4, 3, 4, 3);
            accountPortfolioGrid.Name = "accountPortfolioGrid";
            accountPortfolioGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            accountPortfolioGrid.Size = new Size(962, 399);
            accountPortfolioGrid.TabIndex = 1;
            // 
            // updatePortfolioContract
            // 
            updatePortfolioContract.HeaderText = "Contract";
            updatePortfolioContract.Name = "updatePortfolioContract";
            updatePortfolioContract.ReadOnly = true;
            updatePortfolioContract.Width = 140;
            // 
            // updatePortfolioPosition
            // 
            updatePortfolioPosition.HeaderText = "Position";
            updatePortfolioPosition.Name = "updatePortfolioPosition";
            updatePortfolioPosition.ReadOnly = true;
            // 
            // updatePortfolioMarketPrice
            // 
            updatePortfolioMarketPrice.HeaderText = "Market Price";
            updatePortfolioMarketPrice.Name = "updatePortfolioMarketPrice";
            updatePortfolioMarketPrice.ReadOnly = true;
            // 
            // updatePortfolioMarketValue
            // 
            updatePortfolioMarketValue.HeaderText = "Market Value";
            updatePortfolioMarketValue.Name = "updatePortfolioMarketValue";
            updatePortfolioMarketValue.ReadOnly = true;
            // 
            // updatePortfolioAvgCost
            // 
            updatePortfolioAvgCost.HeaderText = "Average Cost";
            updatePortfolioAvgCost.Name = "updatePortfolioAvgCost";
            updatePortfolioAvgCost.ReadOnly = true;
            // 
            // updatePortfolioUnrealizedPnL
            // 
            updatePortfolioUnrealizedPnL.HeaderText = "Unrealized P&L";
            updatePortfolioUnrealizedPnL.Name = "updatePortfolioUnrealizedPnL";
            updatePortfolioUnrealizedPnL.ReadOnly = true;
            updatePortfolioUnrealizedPnL.Width = 120;
            // 
            // updatePortfolioRealizedPnL
            // 
            updatePortfolioRealizedPnL.HeaderText = "Realized P&L";
            updatePortfolioRealizedPnL.Name = "updatePortfolioRealizedPnL";
            updatePortfolioRealizedPnL.ReadOnly = true;
            updatePortfolioRealizedPnL.Width = 120;
            // 
            // accountValuesGrid
            // 
            accountValuesGrid.AllowUserToAddRows = false;
            accountValuesGrid.AllowUserToDeleteRows = false;
            accountValuesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            accountValuesGrid.Columns.AddRange(new DataGridViewColumn[] { accUpdatesKey, accUpdatesValue, accUpdatesCurrency });
            accountValuesGrid.Location = new Point(7, 40);
            accountValuesGrid.Margin = new Padding(4, 3, 4, 3);
            accountValuesGrid.Name = "accountValuesGrid";
            accountValuesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            accountValuesGrid.Size = new Size(425, 399);
            accountValuesGrid.TabIndex = 0;
            // 
            // accUpdatesKey
            // 
            accUpdatesKey.HeaderText = "Key";
            accUpdatesKey.Name = "accUpdatesKey";
            accUpdatesKey.ReadOnly = true;
            accUpdatesKey.Width = 150;
            // 
            // accUpdatesValue
            // 
            accUpdatesValue.HeaderText = "Value";
            accUpdatesValue.Name = "accUpdatesValue";
            accUpdatesValue.ReadOnly = true;
            accUpdatesValue.Width = 90;
            // 
            // accUpdatesCurrency
            // 
            accUpdatesCurrency.HeaderText = "Currency";
            accUpdatesCurrency.Name = "accUpdatesCurrency";
            accUpdatesCurrency.ReadOnly = true;
            accUpdatesCurrency.Width = 60;
            // 
            // accUpdatesSubscribe
            // 
            accUpdatesSubscribe.Location = new Point(7, 7);
            accUpdatesSubscribe.Margin = new Padding(4, 3, 4, 3);
            accUpdatesSubscribe.Name = "accUpdatesSubscribe";
            accUpdatesSubscribe.Size = new Size(88, 27);
            accUpdatesSubscribe.TabIndex = 2;
            accUpdatesSubscribe.Text = "Subscribe";
            accUpdatesSubscribe.UseVisualStyleBackColor = true;
            accUpdatesSubscribe.Click += accUpdatesSubscribe_Click;
            // 
            // lastUpdatedLabel
            // 
            lastUpdatedLabel.AutoSize = true;
            lastUpdatedLabel.Location = new Point(262, 13);
            lastUpdatedLabel.Margin = new Padding(4, 0, 4, 0);
            lastUpdatedLabel.Name = "lastUpdatedLabel";
            lastUpdatedLabel.Size = new Size(78, 15);
            lastUpdatedLabel.TabIndex = 3;
            lastUpdatedLabel.Text = "Last updated:";
            // 
            // positionsTab
            // 
            positionsTab.BackColor = Color.LightGray;
            positionsTab.Controls.Add(positionRequest);
            positionsTab.Controls.Add(positionsGrid);
            positionsTab.Location = new Point(4, 24);
            positionsTab.Margin = new Padding(4, 3, 4, 3);
            positionsTab.Name = "positionsTab";
            positionsTab.Padding = new Padding(4, 3, 4, 3);
            positionsTab.Size = new Size(1434, 461);
            positionsTab.TabIndex = 2;
            positionsTab.Text = "Positions (all accounts)";
            // 
            // positionRequest
            // 
            positionRequest.Location = new Point(592, 7);
            positionRequest.Margin = new Padding(4, 3, 4, 3);
            positionRequest.Name = "positionRequest";
            positionRequest.Size = new Size(88, 27);
            positionRequest.TabIndex = 1;
            positionRequest.Text = "Request";
            positionRequest.UseVisualStyleBackColor = true;
            positionRequest.Click += positionRequest_Click;
            // 
            // positionsGrid
            // 
            positionsGrid.AllowUserToAddRows = false;
            positionsGrid.AllowUserToDeleteRows = false;
            positionsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            positionsGrid.Columns.AddRange(new DataGridViewColumn[] { positionContract, positionAccount, positionPosition, positionAvgCost });
            positionsGrid.Location = new Point(7, 7);
            positionsGrid.Margin = new Padding(4, 3, 4, 3);
            positionsGrid.Name = "positionsGrid";
            positionsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            positionsGrid.Size = new Size(578, 422);
            positionsGrid.TabIndex = 0;
            // 
            // positionContract
            // 
            positionContract.HeaderText = "Contract";
            positionContract.Name = "positionContract";
            positionContract.ReadOnly = true;
            positionContract.Width = 150;
            // 
            // positionAccount
            // 
            positionAccount.HeaderText = "Account";
            positionAccount.Name = "positionAccount";
            positionAccount.ReadOnly = true;
            // 
            // positionPosition
            // 
            positionPosition.HeaderText = "Position";
            positionPosition.Name = "positionPosition";
            positionPosition.ReadOnly = true;
            positionPosition.Width = 80;
            // 
            // positionAvgCost
            // 
            positionAvgCost.HeaderText = "Average Cost";
            positionAvgCost.Name = "positionAvgCost";
            positionAvgCost.ReadOnly = true;
            // 
            // familyCodesTab
            // 
            familyCodesTab.BackColor = Color.LightGray;
            familyCodesTab.Controls.Add(clearFamilyCodes);
            familyCodesTab.Controls.Add(requestFamilyCodes);
            familyCodesTab.Controls.Add(familyCodesGrid);
            familyCodesTab.Location = new Point(4, 24);
            familyCodesTab.Margin = new Padding(4, 3, 4, 3);
            familyCodesTab.Name = "familyCodesTab";
            familyCodesTab.Padding = new Padding(4, 3, 4, 3);
            familyCodesTab.Size = new Size(1434, 461);
            familyCodesTab.TabIndex = 3;
            familyCodesTab.Text = "Family Codes";
            // 
            // clearFamilyCodes
            // 
            clearFamilyCodes.Location = new Point(594, 40);
            clearFamilyCodes.Margin = new Padding(4, 3, 4, 3);
            clearFamilyCodes.Name = "clearFamilyCodes";
            clearFamilyCodes.Size = new Size(164, 27);
            clearFamilyCodes.TabIndex = 3;
            clearFamilyCodes.Text = "Clear Family Codes";
            clearFamilyCodes.UseVisualStyleBackColor = true;
            clearFamilyCodes.Click += clearFamilyCodes_Click;
            // 
            // requestFamilyCodes
            // 
            requestFamilyCodes.Location = new Point(594, 7);
            requestFamilyCodes.Margin = new Padding(4, 3, 4, 3);
            requestFamilyCodes.Name = "requestFamilyCodes";
            requestFamilyCodes.Size = new Size(164, 27);
            requestFamilyCodes.TabIndex = 2;
            requestFamilyCodes.Text = "Request Family  Codes";
            requestFamilyCodes.UseVisualStyleBackColor = true;
            requestFamilyCodes.Click += requestFamilyCodes_Click;
            // 
            // familyCodesGrid
            // 
            familyCodesGrid.AllowUserToAddRows = false;
            familyCodesGrid.AllowUserToDeleteRows = false;
            familyCodesGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            familyCodesGrid.Columns.AddRange(new DataGridViewColumn[] { familyCodesGridColumnAccountID, familyCodesGridColumnFamilyCode });
            familyCodesGrid.Location = new Point(7, 7);
            familyCodesGrid.Margin = new Padding(4, 3, 4, 3);
            familyCodesGrid.Name = "familyCodesGrid";
            familyCodesGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            familyCodesGrid.Size = new Size(580, 422);
            familyCodesGrid.TabIndex = 1;
            // 
            // familyCodesGridColumnAccountID
            // 
            familyCodesGridColumnAccountID.HeaderText = "Account ID";
            familyCodesGridColumnAccountID.Name = "familyCodesGridColumnAccountID";
            familyCodesGridColumnAccountID.ReadOnly = true;
            familyCodesGridColumnAccountID.Width = 150;
            // 
            // familyCodesGridColumnFamilyCode
            // 
            familyCodesGridColumnFamilyCode.HeaderText = "Family Code";
            familyCodesGridColumnFamilyCode.Name = "familyCodesGridColumnFamilyCode";
            familyCodesGridColumnFamilyCode.ReadOnly = true;
            familyCodesGridColumnFamilyCode.Width = 300;
            // 
            // pnlTab
            // 
            pnlTab.BackColor = Color.LightGray;
            pnlTab.Controls.Add(btnCancelPnLSingle);
            pnlTab.Controls.Add(btnCancelPnL);
            pnlTab.Controls.Add(btnReqPnLSingle);
            pnlTab.Controls.Add(tbConId);
            pnlTab.Controls.Add(label13);
            pnlTab.Controls.Add(tbModelCode);
            pnlTab.Controls.Add(label9);
            pnlTab.Controls.Add(btnReqPnL);
            pnlTab.Controls.Add(dataGridViewPnL);
            pnlTab.Location = new Point(4, 24);
            pnlTab.Margin = new Padding(4, 3, 4, 3);
            pnlTab.Name = "pnlTab";
            pnlTab.Size = new Size(1434, 461);
            pnlTab.TabIndex = 4;
            pnlTab.Text = "PnL";
            // 
            // btnCancelPnLSingle
            // 
            btnCancelPnLSingle.Location = new Point(1042, 33);
            btnCancelPnLSingle.Margin = new Padding(4, 3, 4, 3);
            btnCancelPnLSingle.Name = "btnCancelPnLSingle";
            btnCancelPnLSingle.Size = new Size(176, 27);
            btnCancelPnLSingle.TabIndex = 8;
            btnCancelPnLSingle.Text = "Cancel PnL Single";
            btnCancelPnLSingle.UseVisualStyleBackColor = true;
            btnCancelPnLSingle.Click += btnCancelPnLSingle_Click;
            // 
            // btnCancelPnL
            // 
            btnCancelPnL.Location = new Point(1042, 3);
            btnCancelPnL.Margin = new Padding(4, 3, 4, 3);
            btnCancelPnL.Name = "btnCancelPnL";
            btnCancelPnL.Size = new Size(176, 27);
            btnCancelPnL.TabIndex = 7;
            btnCancelPnL.Text = "Cancel PnL";
            btnCancelPnL.UseVisualStyleBackColor = true;
            btnCancelPnL.Click += btnCancelPnL_Click;
            // 
            // btnReqPnLSingle
            // 
            btnReqPnLSingle.Location = new Point(859, 33);
            btnReqPnLSingle.Margin = new Padding(4, 3, 4, 3);
            btnReqPnLSingle.Name = "btnReqPnLSingle";
            btnReqPnLSingle.Size = new Size(176, 27);
            btnReqPnLSingle.TabIndex = 6;
            btnReqPnLSingle.Text = "Request PnL Single";
            btnReqPnLSingle.UseVisualStyleBackColor = true;
            btnReqPnLSingle.Click += btnReqPnLSingle_Click;
            // 
            // tbConId
            // 
            tbConId.Location = new Point(735, 36);
            tbConId.Margin = new Padding(4, 3, 4, 3);
            tbConId.Name = "tbConId";
            tbConId.Size = new Size(116, 23);
            tbConId.TabIndex = 5;
            tbConId.Text = "0";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(594, 39);
            label13.Margin = new Padding(4, 0, 4, 0);
            label13.Name = "label13";
            label13.Size = new Size(45, 15);
            label13.TabIndex = 4;
            label13.Text = "Con Id:";
            // 
            // tbModelCode
            // 
            tbModelCode.Location = new Point(735, 6);
            tbModelCode.Margin = new Padding(4, 3, 4, 3);
            tbModelCode.Name = "tbModelCode";
            tbModelCode.Size = new Size(116, 23);
            tbModelCode.TabIndex = 3;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(594, 9);
            label9.Margin = new Padding(4, 0, 4, 0);
            label9.Name = "label9";
            label9.Size = new Size(73, 15);
            label9.TabIndex = 2;
            label9.Text = "Model code:";
            // 
            // btnReqPnL
            // 
            btnReqPnL.Location = new Point(859, 3);
            btnReqPnL.Margin = new Padding(4, 3, 4, 3);
            btnReqPnL.Name = "btnReqPnL";
            btnReqPnL.Size = new Size(176, 27);
            btnReqPnL.TabIndex = 1;
            btnReqPnL.Text = "Request PnL";
            btnReqPnL.UseVisualStyleBackColor = true;
            btnReqPnL.Click += btnReqPnL_Click;
            // 
            // dataGridViewPnL
            // 
            dataGridViewPnL.AllowUserToAddRows = false;
            dataGridViewPnL.AllowUserToDeleteRows = false;
            dataGridViewPnL.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewPnL.Location = new Point(7, 3);
            dataGridViewPnL.Margin = new Padding(4, 3, 4, 3);
            dataGridViewPnL.Name = "dataGridViewPnL";
            dataGridViewPnL.ReadOnly = true;
            dataGridViewPnL.Size = new Size(580, 415);
            dataGridViewPnL.TabIndex = 0;
            // 
            // accountSelectorLabel
            // 
            accountSelectorLabel.AutoSize = true;
            accountSelectorLabel.Location = new Point(9, 3);
            accountSelectorLabel.Margin = new Padding(4, 0, 4, 0);
            accountSelectorLabel.Name = "accountSelectorLabel";
            accountSelectorLabel.Size = new Size(93, 15);
            accountSelectorLabel.TabIndex = 1;
            accountSelectorLabel.Text = "Choose account";
            // 
            // accountSelector
            // 
            accountSelector.FormattingEnabled = true;
            accountSelector.Location = new Point(115, 3);
            accountSelector.Margin = new Padding(4, 3, 4, 3);
            accountSelector.Name = "accountSelector";
            accountSelector.Size = new Size(140, 23);
            accountSelector.TabIndex = 0;
            // 
            // tradingTab
            // 
            tradingTab.BackColor = Color.LightGray;
            tradingTab.Controls.Add(completedOrdersButton);
            tradingTab.Controls.Add(completedOrdersGroup);
            tradingTab.Controls.Add(buttonAttachOrder);
            tradingTab.Controls.Add(execFilterGroup);
            tradingTab.Controls.Add(globalCancelButton);
            tradingTab.Controls.Add(clientOrdersButton);
            tradingTab.Controls.Add(refreshOrdersButton);
            tradingTab.Controls.Add(cancelOrdersButton);
            tradingTab.Controls.Add(button1);
            tradingTab.Controls.Add(newOrderLink);
            tradingTab.Controls.Add(executionsGroup);
            tradingTab.Controls.Add(liveOrdersGroup);
            tradingTab.Location = new Point(4, 24);
            tradingTab.Margin = new Padding(4, 3, 4, 3);
            tradingTab.Name = "tradingTab";
            tradingTab.Padding = new Padding(4, 3, 4, 3);
            tradingTab.Size = new Size(1457, 519);
            tradingTab.TabIndex = 2;
            tradingTab.Text = "Trading";
            // 
            // completedOrdersButton
            // 
            completedOrdersButton.Location = new Point(1138, 192);
            completedOrdersButton.Margin = new Padding(4, 3, 4, 3);
            completedOrdersButton.Name = "completedOrdersButton";
            completedOrdersButton.Size = new Size(166, 27);
            completedOrdersButton.TabIndex = 12;
            completedOrdersButton.Text = "Get completed orders";
            completedOrdersButton.UseVisualStyleBackColor = true;
            completedOrdersButton.Click += completedOrdersButton_Click;
            // 
            // completedOrdersGroup
            // 
            completedOrdersGroup.Controls.Add(completedOrdersGrid);
            completedOrdersGroup.Location = new Point(10, 172);
            completedOrdersGroup.Margin = new Padding(4, 3, 4, 3);
            completedOrdersGroup.Name = "completedOrdersGroup";
            completedOrdersGroup.Padding = new Padding(4, 3, 4, 3);
            completedOrdersGroup.Size = new Size(1120, 159);
            completedOrdersGroup.TabIndex = 2;
            completedOrdersGroup.TabStop = false;
            completedOrdersGroup.Text = "Completed Orders";
            // 
            // completedOrdersGrid
            // 
            completedOrdersGrid.AllowUserToAddRows = false;
            completedOrdersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            completedOrdersGrid.Columns.AddRange(new DataGridViewColumn[] { completedOrdersBoxColumn1, completedOrdersBoxColumn2, completedOrdersBoxColumn3, completedOrdersBoxColumn4, completedOrdersBoxColumn5, completedOrdersBoxColumn6, completedOrdersBoxColumn7, completedOrdersBoxColumn8, completedOrdersBoxColumn9, completedOrdersBoxColumn10, completedOrdersBoxColumn11, completedOrdersBoxColumn12, completedOrdersBoxColumn13 });
            completedOrdersGrid.Location = new Point(9, 22);
            completedOrdersGrid.Margin = new Padding(4, 3, 4, 3);
            completedOrdersGrid.Name = "completedOrdersGrid";
            completedOrdersGrid.ReadOnly = true;
            completedOrdersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            completedOrdersGrid.Size = new Size(1104, 136);
            completedOrdersGrid.TabIndex = 1;
            // 
            // completedOrdersBoxColumn1
            // 
            completedOrdersBoxColumn1.HeaderText = "Perm ID";
            completedOrdersBoxColumn1.Name = "completedOrdersBoxColumn1";
            completedOrdersBoxColumn1.ReadOnly = true;
            // 
            // completedOrdersBoxColumn2
            // 
            completedOrdersBoxColumn2.HeaderText = "Parent Perm ID";
            completedOrdersBoxColumn2.Name = "completedOrdersBoxColumn2";
            completedOrdersBoxColumn2.ReadOnly = true;
            // 
            // completedOrdersBoxColumn3
            // 
            completedOrdersBoxColumn3.HeaderText = "Account";
            completedOrdersBoxColumn3.Name = "completedOrdersBoxColumn3";
            completedOrdersBoxColumn3.ReadOnly = true;
            // 
            // completedOrdersBoxColumn4
            // 
            completedOrdersBoxColumn4.HeaderText = "Action";
            completedOrdersBoxColumn4.Name = "completedOrdersBoxColumn4";
            completedOrdersBoxColumn4.ReadOnly = true;
            // 
            // completedOrdersBoxColumn5
            // 
            completedOrdersBoxColumn5.HeaderText = "Qty";
            completedOrdersBoxColumn5.Name = "completedOrdersBoxColumn5";
            completedOrdersBoxColumn5.ReadOnly = true;
            // 
            // completedOrdersBoxColumn6
            // 
            completedOrdersBoxColumn6.HeaderText = "Cash Qty";
            completedOrdersBoxColumn6.Name = "completedOrdersBoxColumn6";
            completedOrdersBoxColumn6.ReadOnly = true;
            // 
            // completedOrdersBoxColumn7
            // 
            completedOrdersBoxColumn7.HeaderText = "Filled Qty";
            completedOrdersBoxColumn7.Name = "completedOrdersBoxColumn7";
            completedOrdersBoxColumn7.ReadOnly = true;
            // 
            // completedOrdersBoxColumn8
            // 
            completedOrdersBoxColumn8.HeaderText = "Lmt Price";
            completedOrdersBoxColumn8.Name = "completedOrdersBoxColumn8";
            completedOrdersBoxColumn8.ReadOnly = true;
            // 
            // completedOrdersBoxColumn9
            // 
            completedOrdersBoxColumn9.HeaderText = "Aux Price";
            completedOrdersBoxColumn9.Name = "completedOrdersBoxColumn9";
            completedOrdersBoxColumn9.ReadOnly = true;
            completedOrdersBoxColumn9.Width = 120;
            // 
            // completedOrdersBoxColumn10
            // 
            completedOrdersBoxColumn10.HeaderText = "Contract";
            completedOrdersBoxColumn10.Name = "completedOrdersBoxColumn10";
            completedOrdersBoxColumn10.ReadOnly = true;
            // 
            // completedOrdersBoxColumn11
            // 
            completedOrdersBoxColumn11.HeaderText = "Status";
            completedOrdersBoxColumn11.Name = "completedOrdersBoxColumn11";
            completedOrdersBoxColumn11.ReadOnly = true;
            // 
            // completedOrdersBoxColumn12
            // 
            completedOrdersBoxColumn12.HeaderText = "Comp Time";
            completedOrdersBoxColumn12.Name = "completedOrdersBoxColumn12";
            completedOrdersBoxColumn12.ReadOnly = true;
            // 
            // completedOrdersBoxColumn13
            // 
            completedOrdersBoxColumn13.HeaderText = "Comp Status";
            completedOrdersBoxColumn13.Name = "completedOrdersBoxColumn13";
            completedOrdersBoxColumn13.ReadOnly = true;
            // 
            // buttonAttachOrder
            // 
            buttonAttachOrder.Location = new Point(1269, 29);
            buttonAttachOrder.Margin = new Padding(4, 3, 4, 3);
            buttonAttachOrder.Name = "buttonAttachOrder";
            buttonAttachOrder.Size = new Size(122, 27);
            buttonAttachOrder.TabIndex = 11;
            buttonAttachOrder.Text = "Attach order";
            buttonAttachOrder.UseVisualStyleBackColor = true;
            buttonAttachOrder.Click += buttonAttachOrder_Click;
            // 
            // execFilterGroup
            // 
            execFilterGroup.Controls.Add(execFilterExchange);
            execFilterGroup.Controls.Add(execFilterSide);
            execFilterGroup.Controls.Add(execFilterSideLabel);
            execFilterGroup.Controls.Add(execFilterExchangeLabel);
            execFilterGroup.Controls.Add(execFilterSecTypeLabel);
            execFilterGroup.Controls.Add(execFilterSymbolLabel);
            execFilterGroup.Controls.Add(execFilterTimeLabel);
            execFilterGroup.Controls.Add(execFilterAcctLabel);
            execFilterGroup.Controls.Add(execFilterClientLabel);
            execFilterGroup.Controls.Add(execFilterSecType);
            execFilterGroup.Controls.Add(execFilterSymbol);
            execFilterGroup.Controls.Add(execFilterTime);
            execFilterGroup.Controls.Add(execFilterAccount);
            execFilterGroup.Controls.Add(execFilterClientId);
            execFilterGroup.Controls.Add(refreshExecutionsButton);
            execFilterGroup.Location = new Point(1138, 285);
            execFilterGroup.Margin = new Padding(4, 3, 4, 3);
            execFilterGroup.Name = "execFilterGroup";
            execFilterGroup.Padding = new Padding(4, 3, 4, 3);
            execFilterGroup.Size = new Size(268, 225);
            execFilterGroup.TabIndex = 10;
            execFilterGroup.TabStop = false;
            execFilterGroup.Text = "Execution Filter";
            // 
            // execFilterExchange
            // 
            execFilterExchange.Location = new Point(76, 78);
            execFilterExchange.Margin = new Padding(4, 3, 4, 3);
            execFilterExchange.Name = "execFilterExchange";
            execFilterExchange.Size = new Size(89, 23);
            execFilterExchange.TabIndex = 15;
            // 
            // execFilterSide
            // 
            execFilterSide.Location = new Point(76, 108);
            execFilterSide.Margin = new Padding(4, 3, 4, 3);
            execFilterSide.Name = "execFilterSide";
            execFilterSide.Size = new Size(89, 23);
            execFilterSide.TabIndex = 14;
            execFilterSide.Text = "BUY";
            // 
            // execFilterSideLabel
            // 
            execFilterSideLabel.AutoSize = true;
            execFilterSideLabel.Location = new Point(7, 117);
            execFilterSideLabel.Margin = new Padding(4, 0, 4, 0);
            execFilterSideLabel.Name = "execFilterSideLabel";
            execFilterSideLabel.Size = new Size(29, 15);
            execFilterSideLabel.TabIndex = 13;
            execFilterSideLabel.Text = "Side";
            // 
            // execFilterExchangeLabel
            // 
            execFilterExchangeLabel.AutoSize = true;
            execFilterExchangeLabel.Location = new Point(7, 88);
            execFilterExchangeLabel.Margin = new Padding(4, 0, 4, 0);
            execFilterExchangeLabel.Name = "execFilterExchangeLabel";
            execFilterExchangeLabel.Size = new Size(58, 15);
            execFilterExchangeLabel.TabIndex = 12;
            execFilterExchangeLabel.Text = "Exchange";
            // 
            // execFilterSecTypeLabel
            // 
            execFilterSecTypeLabel.AutoSize = true;
            execFilterSecTypeLabel.Location = new Point(7, 174);
            execFilterSecTypeLabel.Margin = new Padding(4, 0, 4, 0);
            execFilterSecTypeLabel.Name = "execFilterSecTypeLabel";
            execFilterSecTypeLabel.Size = new Size(49, 15);
            execFilterSecTypeLabel.TabIndex = 11;
            execFilterSecTypeLabel.Text = "SecType";
            // 
            // execFilterSymbolLabel
            // 
            execFilterSymbolLabel.AutoSize = true;
            execFilterSymbolLabel.Location = new Point(7, 145);
            execFilterSymbolLabel.Margin = new Padding(4, 0, 4, 0);
            execFilterSymbolLabel.Name = "execFilterSymbolLabel";
            execFilterSymbolLabel.Size = new Size(47, 15);
            execFilterSymbolLabel.TabIndex = 10;
            execFilterSymbolLabel.Text = "Symbol";
            // 
            // execFilterTimeLabel
            // 
            execFilterTimeLabel.AutoSize = true;
            execFilterTimeLabel.Location = new Point(7, 203);
            execFilterTimeLabel.Margin = new Padding(4, 0, 4, 0);
            execFilterTimeLabel.Name = "execFilterTimeLabel";
            execFilterTimeLabel.Size = new Size(33, 15);
            execFilterTimeLabel.TabIndex = 9;
            execFilterTimeLabel.Text = "Time";
            // 
            // execFilterAcctLabel
            // 
            execFilterAcctLabel.AutoSize = true;
            execFilterAcctLabel.Location = new Point(7, 58);
            execFilterAcctLabel.Margin = new Padding(4, 0, 4, 0);
            execFilterAcctLabel.Name = "execFilterAcctLabel";
            execFilterAcctLabel.Size = new Size(52, 15);
            execFilterAcctLabel.TabIndex = 8;
            execFilterAcctLabel.Text = "Account";
            // 
            // execFilterClientLabel
            // 
            execFilterClientLabel.AutoSize = true;
            execFilterClientLabel.Location = new Point(7, 28);
            execFilterClientLabel.Margin = new Padding(4, 0, 4, 0);
            execFilterClientLabel.Name = "execFilterClientLabel";
            execFilterClientLabel.Size = new Size(48, 15);
            execFilterClientLabel.TabIndex = 7;
            execFilterClientLabel.Text = "ClientId";
            // 
            // execFilterSecType
            // 
            execFilterSecType.Location = new Point(76, 166);
            execFilterSecType.Margin = new Padding(4, 3, 4, 3);
            execFilterSecType.Name = "execFilterSecType";
            execFilterSecType.Size = new Size(89, 23);
            execFilterSecType.TabIndex = 6;
            // 
            // execFilterSymbol
            // 
            execFilterSymbol.Location = new Point(76, 137);
            execFilterSymbol.Margin = new Padding(4, 3, 4, 3);
            execFilterSymbol.Name = "execFilterSymbol";
            execFilterSymbol.Size = new Size(89, 23);
            execFilterSymbol.TabIndex = 5;
            // 
            // execFilterTime
            // 
            execFilterTime.Location = new Point(76, 195);
            execFilterTime.Margin = new Padding(4, 3, 4, 3);
            execFilterTime.Name = "execFilterTime";
            execFilterTime.Size = new Size(117, 23);
            execFilterTime.TabIndex = 4;
            // 
            // execFilterAccount
            // 
            execFilterAccount.Location = new Point(76, 50);
            execFilterAccount.Margin = new Padding(4, 3, 4, 3);
            execFilterAccount.Name = "execFilterAccount";
            execFilterAccount.Size = new Size(89, 23);
            execFilterAccount.TabIndex = 3;
            // 
            // execFilterClientId
            // 
            execFilterClientId.Location = new Point(76, 20);
            execFilterClientId.Margin = new Padding(4, 3, 4, 3);
            execFilterClientId.Name = "execFilterClientId";
            execFilterClientId.Size = new Size(89, 23);
            execFilterClientId.TabIndex = 2;
            // 
            // refreshExecutionsButton
            // 
            refreshExecutionsButton.Location = new Point(174, 20);
            refreshExecutionsButton.Margin = new Padding(4, 3, 4, 3);
            refreshExecutionsButton.Name = "refreshExecutionsButton";
            refreshExecutionsButton.Size = new Size(88, 27);
            refreshExecutionsButton.TabIndex = 1;
            refreshExecutionsButton.Text = "Refresh";
            refreshExecutionsButton.UseVisualStyleBackColor = true;
            refreshExecutionsButton.Click += refreshExecutionsButton_Click;
            // 
            // globalCancelButton
            // 
            globalCancelButton.Location = new Point(1140, 150);
            globalCancelButton.Margin = new Padding(4, 3, 4, 3);
            globalCancelButton.Name = "globalCancelButton";
            globalCancelButton.Size = new Size(122, 27);
            globalCancelButton.TabIndex = 9;
            globalCancelButton.Text = "Global cancel";
            globalCancelButton.UseVisualStyleBackColor = true;
            globalCancelButton.Click += globalCancelButton_Click;
            // 
            // clientOrdersButton
            // 
            clientOrdersButton.Location = new Point(1140, 29);
            clientOrdersButton.Margin = new Padding(4, 3, 4, 3);
            clientOrdersButton.Name = "clientOrdersButton";
            clientOrdersButton.Size = new Size(122, 27);
            clientOrdersButton.TabIndex = 8;
            clientOrdersButton.Text = "Get client's orders";
            clientOrdersButton.UseVisualStyleBackColor = true;
            clientOrdersButton.Click += clientOrdersButton_Click;
            // 
            // refreshOrdersButton
            // 
            refreshOrdersButton.Location = new Point(1140, 59);
            refreshOrdersButton.Margin = new Padding(4, 3, 4, 3);
            refreshOrdersButton.Name = "refreshOrdersButton";
            refreshOrdersButton.Size = new Size(122, 27);
            refreshOrdersButton.TabIndex = 1;
            refreshOrdersButton.Text = "Get all orders";
            refreshOrdersButton.UseVisualStyleBackColor = true;
            refreshOrdersButton.Click += refreshOrdersButton_Click;
            // 
            // cancelOrdersButton
            // 
            cancelOrdersButton.Location = new Point(1140, 120);
            cancelOrdersButton.Margin = new Padding(4, 3, 4, 3);
            cancelOrdersButton.Name = "cancelOrdersButton";
            cancelOrdersButton.Size = new Size(122, 27);
            cancelOrdersButton.TabIndex = 7;
            cancelOrdersButton.Text = "Cancel selection";
            cancelOrdersButton.UseVisualStyleBackColor = true;
            cancelOrdersButton.Click += cancelOrdersButton_Click;
            // 
            // button1
            // 
            button1.Location = new Point(1140, 89);
            button1.Margin = new Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new Size(122, 27);
            button1.TabIndex = 6;
            button1.Text = "Bind TWS orders";
            button1.UseVisualStyleBackColor = true;
            button1.Click += bindOrdersButton_Click;
            // 
            // newOrderLink
            // 
            newOrderLink.AutoSize = true;
            newOrderLink.Location = new Point(1136, 7);
            newOrderLink.Margin = new Padding(4, 0, 4, 0);
            newOrderLink.Name = "newOrderLink";
            newOrderLink.Size = new Size(64, 15);
            newOrderLink.TabIndex = 3;
            newOrderLink.TabStop = true;
            newOrderLink.Text = "New Order";
            newOrderLink.LinkClicked += newOrderLink_LinkClicked;
            // 
            // executionsGroup
            // 
            executionsGroup.Controls.Add(tradeLogGrid);
            executionsGroup.Location = new Point(10, 343);
            executionsGroup.Margin = new Padding(4, 3, 4, 3);
            executionsGroup.Name = "executionsGroup";
            executionsGroup.Padding = new Padding(4, 3, 4, 3);
            executionsGroup.Size = new Size(1120, 167);
            executionsGroup.TabIndex = 2;
            executionsGroup.TabStop = false;
            executionsGroup.Text = "Trade Log (Executions)";
            // 
            // tradeLogGrid
            // 
            tradeLogGrid.AllowUserToAddRows = false;
            tradeLogGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            tradeLogGrid.Columns.AddRange(new DataGridViewColumn[] { ExecutionId, dateTimeExecColumn, accountExecColumn, dataGridViewTextBoxColumn8, actionExecColumn, quantityExecColumn, descriptionExecColumn, priceExecColumn, commissionExecColumn, RealizedPnL, LastLiquidity });
            tradeLogGrid.Location = new Point(7, 22);
            tradeLogGrid.Margin = new Padding(4, 3, 4, 3);
            tradeLogGrid.Name = "tradeLogGrid";
            tradeLogGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            tradeLogGrid.Size = new Size(1104, 136);
            tradeLogGrid.TabIndex = 0;
            // 
            // ExecutionId
            // 
            ExecutionId.HeaderText = "Execution ID";
            ExecutionId.Name = "ExecutionId";
            ExecutionId.ReadOnly = true;
            // 
            // dateTimeExecColumn
            // 
            dateTimeExecColumn.HeaderText = "Date/Time";
            dateTimeExecColumn.Name = "dateTimeExecColumn";
            dateTimeExecColumn.ReadOnly = true;
            // 
            // accountExecColumn
            // 
            accountExecColumn.HeaderText = "Account";
            accountExecColumn.Name = "accountExecColumn";
            accountExecColumn.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            dataGridViewTextBoxColumn8.HeaderText = "Model Code";
            dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            // 
            // actionExecColumn
            // 
            actionExecColumn.HeaderText = "Action";
            actionExecColumn.Name = "actionExecColumn";
            actionExecColumn.ReadOnly = true;
            // 
            // quantityExecColumn
            // 
            quantityExecColumn.HeaderText = "Quantity";
            quantityExecColumn.Name = "quantityExecColumn";
            quantityExecColumn.ReadOnly = true;
            // 
            // descriptionExecColumn
            // 
            descriptionExecColumn.HeaderText = "Description";
            descriptionExecColumn.Name = "descriptionExecColumn";
            descriptionExecColumn.ReadOnly = true;
            // 
            // priceExecColumn
            // 
            priceExecColumn.HeaderText = "Price";
            priceExecColumn.Name = "priceExecColumn";
            priceExecColumn.ReadOnly = true;
            // 
            // commissionExecColumn
            // 
            commissionExecColumn.HeaderText = "Commissions";
            commissionExecColumn.Name = "commissionExecColumn";
            commissionExecColumn.ReadOnly = true;
            // 
            // RealizedPnL
            // 
            RealizedPnL.HeaderText = "RealizedPnL";
            RealizedPnL.Name = "RealizedPnL";
            RealizedPnL.ReadOnly = true;
            // 
            // LastLiquidity
            // 
            LastLiquidity.HeaderText = "Last Liquidity";
            LastLiquidity.Name = "LastLiquidity";
            LastLiquidity.ReadOnly = true;
            // 
            // liveOrdersGroup
            // 
            liveOrdersGroup.Controls.Add(liveOrdersGrid);
            liveOrdersGroup.Location = new Point(10, 7);
            liveOrdersGroup.Margin = new Padding(4, 3, 4, 3);
            liveOrdersGroup.Name = "liveOrdersGroup";
            liveOrdersGroup.Padding = new Padding(4, 3, 4, 3);
            liveOrdersGroup.Size = new Size(1120, 158);
            liveOrdersGroup.TabIndex = 1;
            liveOrdersGroup.TabStop = false;
            liveOrdersGroup.Text = "Live Orders - double click to modify.";
            // 
            // liveOrdersGrid
            // 
            liveOrdersGrid.AllowUserToAddRows = false;
            liveOrdersGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            liveOrdersGrid.Columns.AddRange(new DataGridViewColumn[] { permIdColumn, clientIdColumn, orderIdColumn, accountColumn, modelCodeColumn, actionColumn, quantityColumn, contractColumn, statusColumn, cashQtyColumn });
            liveOrdersGrid.Location = new Point(7, 22);
            liveOrdersGrid.Margin = new Padding(4, 3, 4, 3);
            liveOrdersGrid.Name = "liveOrdersGrid";
            liveOrdersGrid.ReadOnly = true;
            liveOrdersGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            liveOrdersGrid.Size = new Size(1104, 136);
            liveOrdersGrid.TabIndex = 0;
            liveOrdersGrid.CellDoubleClick += liveOrdersGrid_CellCoubleClick;
            // 
            // permIdColumn
            // 
            permIdColumn.HeaderText = "Perm ID";
            permIdColumn.Name = "permIdColumn";
            permIdColumn.ReadOnly = true;
            // 
            // clientIdColumn
            // 
            clientIdColumn.HeaderText = "Client ID";
            clientIdColumn.Name = "clientIdColumn";
            clientIdColumn.ReadOnly = true;
            // 
            // orderIdColumn
            // 
            orderIdColumn.HeaderText = "Order ID";
            orderIdColumn.Name = "orderIdColumn";
            orderIdColumn.ReadOnly = true;
            // 
            // accountColumn
            // 
            accountColumn.HeaderText = "Account";
            accountColumn.Name = "accountColumn";
            accountColumn.ReadOnly = true;
            // 
            // modelCodeColumn
            // 
            modelCodeColumn.HeaderText = "Model Code";
            modelCodeColumn.Name = "modelCodeColumn";
            modelCodeColumn.ReadOnly = true;
            // 
            // actionColumn
            // 
            actionColumn.HeaderText = "Action";
            actionColumn.Name = "actionColumn";
            actionColumn.ReadOnly = true;
            // 
            // quantityColumn
            // 
            quantityColumn.HeaderText = "Quantity";
            quantityColumn.Name = "quantityColumn";
            quantityColumn.ReadOnly = true;
            // 
            // contractColumn
            // 
            contractColumn.HeaderText = "Contract";
            contractColumn.Name = "contractColumn";
            contractColumn.ReadOnly = true;
            contractColumn.Width = 120;
            // 
            // statusColumn
            // 
            statusColumn.HeaderText = "Status";
            statusColumn.Name = "statusColumn";
            statusColumn.ReadOnly = true;
            // 
            // cashQtyColumn
            // 
            cashQtyColumn.HeaderText = "Cash Qty";
            cashQtyColumn.Name = "cashQtyColumn";
            cashQtyColumn.ReadOnly = true;
            // 
            // marketDataTab
            // 
            marketDataTab.BackColor = Color.LightGray;
            marketDataTab.Controls.Add(marketData_MDT);
            marketDataTab.Controls.Add(dataResults_MDT);
            marketDataTab.Location = new Point(4, 24);
            marketDataTab.Margin = new Padding(4, 3, 4, 3);
            marketDataTab.Name = "marketDataTab";
            marketDataTab.Padding = new Padding(4, 3, 4, 3);
            marketDataTab.Size = new Size(1457, 519);
            marketDataTab.TabIndex = 1;
            marketDataTab.Text = "Data";
            // 
            // marketData_MDT
            // 
            marketData_MDT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            marketData_MDT.Controls.Add(topMarketDataTab_MDT);
            marketData_MDT.Controls.Add(deepBookTab_MDT);
            marketData_MDT.Controls.Add(historicalDataTab);
            marketData_MDT.Controls.Add(rtBarsTab_MDT);
            marketData_MDT.Controls.Add(scannerTab);
            marketData_MDT.Controls.Add(scannerParamsTab);
            marketData_MDT.Controls.Add(mktDepthExchanges_MDT);
            marketData_MDT.Controls.Add(symbolSamplesTabData);
            marketData_MDT.Controls.Add(smartComponentsTabPage);
            marketData_MDT.Controls.Add(headTimestampTabPage);
            marketData_MDT.Controls.Add(histogramTabPage);
            marketData_MDT.Controls.Add(historicalTicksTabPage);
            marketData_MDT.Controls.Add(tabPageTickByTick);
            marketData_MDT.Controls.Add(tabHistoricalSchedule);
            marketData_MDT.Location = new Point(0, 242);
            marketData_MDT.Margin = new Padding(0);
            marketData_MDT.Name = "marketData_MDT";
            marketData_MDT.SelectedIndex = 0;
            marketData_MDT.Size = new Size(1449, 271);
            marketData_MDT.TabIndex = 1;
            // 
            // topMarketDataTab_MDT
            // 
            topMarketDataTab_MDT.BackColor = Color.LightGray;
            topMarketDataTab_MDT.Controls.Add(closeMketDataTab);
            topMarketDataTab_MDT.Controls.Add(marketDataGrid_MDT);
            topMarketDataTab_MDT.Location = new Point(4, 24);
            topMarketDataTab_MDT.Margin = new Padding(4, 3, 4, 3);
            topMarketDataTab_MDT.Name = "topMarketDataTab_MDT";
            topMarketDataTab_MDT.Padding = new Padding(4, 3, 4, 3);
            topMarketDataTab_MDT.Size = new Size(1441, 243);
            topMarketDataTab_MDT.TabIndex = 0;
            topMarketDataTab_MDT.Text = "Market Data";
            // 
            // closeMketDataTab
            // 
            closeMketDataTab.AutoSize = true;
            closeMketDataTab.Location = new Point(7, 3);
            closeMketDataTab.Margin = new Padding(4, 0, 4, 0);
            closeMketDataTab.Name = "closeMketDataTab";
            closeMketDataTab.Size = new Size(36, 15);
            closeMketDataTab.TabIndex = 1;
            closeMketDataTab.TabStop = true;
            closeMketDataTab.Text = "Close";
            closeMketDataTab.LinkClicked += closeMketDataTab_LinkClicked;
            // 
            // marketDataGrid_MDT
            // 
            marketDataGrid_MDT.AllowUserToAddRows = false;
            marketDataGrid_MDT.AllowUserToDeleteRows = false;
            marketDataGrid_MDT.AllowUserToOrderColumns = true;
            marketDataGrid_MDT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            marketDataGrid_MDT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            marketDataGrid_MDT.Columns.AddRange(new DataGridViewColumn[] { marketDataContract, marketDataTypeTickerColumn, bidSize, bidPrice, preOpenBid, preOpenAsk, askPrice, askSize, lastTickerColumn, lastPrice, volume, closeTickerColumn, openTickerColumn, highTickerColumn, lowTickerColumn, futuresOpenInterestTickerColumn, avgOptVolumeTickerColumn, shortableSharesTickerColumn, estimatedIPOMidpointTickerColumn, finalIPOLastTickerColumn });
            marketDataGrid_MDT.Location = new Point(4, 22);
            marketDataGrid_MDT.Margin = new Padding(4, 3, 4, 3);
            marketDataGrid_MDT.Name = "marketDataGrid_MDT";
            marketDataGrid_MDT.ReadOnly = true;
            marketDataGrid_MDT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            marketDataGrid_MDT.Size = new Size(1429, 210);
            marketDataGrid_MDT.TabIndex = 0;
            marketDataGrid_MDT.Visible = false;
            // 
            // marketDataContract
            // 
            marketDataContract.HeaderText = "Description";
            marketDataContract.Name = "marketDataContract";
            marketDataContract.ReadOnly = true;
            marketDataContract.Width = 200;
            // 
            // marketDataTypeTickerColumn
            // 
            marketDataTypeTickerColumn.HeaderText = "Mkt Data Type";
            marketDataTypeTickerColumn.Name = "marketDataTypeTickerColumn";
            marketDataTypeTickerColumn.ReadOnly = true;
            marketDataTypeTickerColumn.Width = 150;
            // 
            // bidSize
            // 
            bidSize.HeaderText = "Bid Size";
            bidSize.Name = "bidSize";
            bidSize.ReadOnly = true;
            // 
            // bidPrice
            // 
            bidPrice.HeaderText = "Bid";
            bidPrice.Name = "bidPrice";
            bidPrice.ReadOnly = true;
            // 
            // preOpenBid
            // 
            preOpenBid.HeaderText = "Pre-Open Bid";
            preOpenBid.Name = "preOpenBid";
            preOpenBid.ReadOnly = true;
            // 
            // preOpenAsk
            // 
            preOpenAsk.HeaderText = "Pre-Open Ask";
            preOpenAsk.Name = "preOpenAsk";
            preOpenAsk.ReadOnly = true;
            // 
            // askPrice
            // 
            askPrice.HeaderText = "Ask";
            askPrice.Name = "askPrice";
            askPrice.ReadOnly = true;
            // 
            // askSize
            // 
            askSize.HeaderText = "Ask Size";
            askSize.Name = "askSize";
            askSize.ReadOnly = true;
            // 
            // lastTickerColumn
            // 
            lastTickerColumn.HeaderText = "Last";
            lastTickerColumn.Name = "lastTickerColumn";
            lastTickerColumn.ReadOnly = true;
            // 
            // lastPrice
            // 
            lastPrice.HeaderText = "Last Size";
            lastPrice.Name = "lastPrice";
            lastPrice.ReadOnly = true;
            // 
            // volume
            // 
            volume.HeaderText = "Volume";
            volume.Name = "volume";
            volume.ReadOnly = true;
            // 
            // closeTickerColumn
            // 
            closeTickerColumn.HeaderText = "Close";
            closeTickerColumn.Name = "closeTickerColumn";
            closeTickerColumn.ReadOnly = true;
            closeTickerColumn.Resizable = DataGridViewTriState.True;
            closeTickerColumn.SortMode = DataGridViewColumnSortMode.NotSortable;
            // 
            // openTickerColumn
            // 
            openTickerColumn.HeaderText = "Open";
            openTickerColumn.Name = "openTickerColumn";
            openTickerColumn.ReadOnly = true;
            // 
            // highTickerColumn
            // 
            highTickerColumn.HeaderText = "High";
            highTickerColumn.Name = "highTickerColumn";
            highTickerColumn.ReadOnly = true;
            // 
            // lowTickerColumn
            // 
            lowTickerColumn.HeaderText = "Low";
            lowTickerColumn.Name = "lowTickerColumn";
            lowTickerColumn.ReadOnly = true;
            // 
            // futuresOpenInterestTickerColumn
            // 
            futuresOpenInterestTickerColumn.HeaderText = "Fut Open Int";
            futuresOpenInterestTickerColumn.Name = "futuresOpenInterestTickerColumn";
            futuresOpenInterestTickerColumn.ReadOnly = true;
            // 
            // avgOptVolumeTickerColumn
            // 
            avgOptVolumeTickerColumn.HeaderText = "Avg Opt Vol";
            avgOptVolumeTickerColumn.Name = "avgOptVolumeTickerColumn";
            avgOptVolumeTickerColumn.ReadOnly = true;
            // 
            // shortableSharesTickerColumn
            // 
            shortableSharesTickerColumn.HeaderText = "Shortable Shares";
            shortableSharesTickerColumn.Name = "shortableSharesTickerColumn";
            shortableSharesTickerColumn.ReadOnly = true;
            // 
            // estimatedIPOMidpointTickerColumn
            // 
            estimatedIPOMidpointTickerColumn.HeaderText = "Est IPO Mid";
            estimatedIPOMidpointTickerColumn.Name = "estimatedIPOMidpointTickerColumn";
            estimatedIPOMidpointTickerColumn.ReadOnly = true;
            // 
            // finalIPOLastTickerColumn
            // 
            finalIPOLastTickerColumn.HeaderText = "Final IPO Last";
            finalIPOLastTickerColumn.Name = "finalIPOLastTickerColumn";
            finalIPOLastTickerColumn.ReadOnly = true;
            // 
            // deepBookTab_MDT
            // 
            deepBookTab_MDT.BackColor = Color.LightGray;
            deepBookTab_MDT.Controls.Add(closeDeepBookLink);
            deepBookTab_MDT.Controls.Add(deepBookGrid);
            deepBookTab_MDT.Location = new Point(4, 24);
            deepBookTab_MDT.Margin = new Padding(4, 3, 4, 3);
            deepBookTab_MDT.Name = "deepBookTab_MDT";
            deepBookTab_MDT.Padding = new Padding(4, 3, 4, 3);
            deepBookTab_MDT.Size = new Size(1441, 243);
            deepBookTab_MDT.TabIndex = 1;
            deepBookTab_MDT.Text = "Deep Book";
            // 
            // closeDeepBookLink
            // 
            closeDeepBookLink.AutoSize = true;
            closeDeepBookLink.Location = new Point(7, 3);
            closeDeepBookLink.Margin = new Padding(4, 0, 4, 0);
            closeDeepBookLink.Name = "closeDeepBookLink";
            closeDeepBookLink.Size = new Size(36, 15);
            closeDeepBookLink.TabIndex = 1;
            closeDeepBookLink.TabStop = true;
            closeDeepBookLink.Text = "Close";
            closeDeepBookLink.LinkClicked += closeDeepBookLink_LinkClicked;
            // 
            // deepBookGrid
            // 
            deepBookGrid.AllowUserToAddRows = false;
            deepBookGrid.AllowUserToDeleteRows = false;
            deepBookGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            deepBookGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            deepBookGrid.Columns.AddRange(new DataGridViewColumn[] { bidBookMaker, bidBookSize, bidBookPrice, askBookPrice, askBookSize, askBookMaker });
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = SystemColors.ButtonHighlight;
            dataGridViewCellStyle1.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            dataGridViewCellStyle1.ForeColor = SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            deepBookGrid.DefaultCellStyle = dataGridViewCellStyle1;
            deepBookGrid.Location = new Point(5, 22);
            deepBookGrid.Margin = new Padding(4, 3, 4, 3);
            deepBookGrid.Name = "deepBookGrid";
            deepBookGrid.ReadOnly = true;
            deepBookGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            deepBookGrid.Size = new Size(1428, 210);
            deepBookGrid.TabIndex = 0;
            // 
            // bidBookMaker
            // 
            bidBookMaker.HeaderText = "Market Maker";
            bidBookMaker.Name = "bidBookMaker";
            bidBookMaker.ReadOnly = true;
            // 
            // bidBookSize
            // 
            bidBookSize.HeaderText = "Bid Size";
            bidBookSize.Name = "bidBookSize";
            bidBookSize.ReadOnly = true;
            // 
            // bidBookPrice
            // 
            bidBookPrice.HeaderText = "Bid Price";
            bidBookPrice.Name = "bidBookPrice";
            bidBookPrice.ReadOnly = true;
            // 
            // askBookPrice
            // 
            askBookPrice.HeaderText = "Ask Price";
            askBookPrice.Name = "askBookPrice";
            askBookPrice.ReadOnly = true;
            // 
            // askBookSize
            // 
            askBookSize.HeaderText = "Ask Size";
            askBookSize.Name = "askBookSize";
            askBookSize.ReadOnly = true;
            // 
            // askBookMaker
            // 
            askBookMaker.HeaderText = "Market Maker";
            askBookMaker.Name = "askBookMaker";
            askBookMaker.ReadOnly = true;
            // 
            // historicalDataTab
            // 
            historicalDataTab.BackColor = Color.LightGray;
            historicalDataTab.Controls.Add(histDataTabClose_MDT);
            historicalDataTab.Controls.Add(barsGrid);
            historicalDataTab.Controls.Add(historicalChart);
            historicalDataTab.Location = new Point(4, 24);
            historicalDataTab.Margin = new Padding(4, 3, 4, 3);
            historicalDataTab.Name = "historicalDataTab";
            historicalDataTab.Padding = new Padding(4, 3, 4, 3);
            historicalDataTab.Size = new Size(1441, 243);
            historicalDataTab.TabIndex = 0;
            historicalDataTab.Text = "Historical Bars";
            // 
            // histDataTabClose_MDT
            // 
            histDataTabClose_MDT.AutoSize = true;
            histDataTabClose_MDT.Location = new Point(7, 3);
            histDataTabClose_MDT.Margin = new Padding(4, 0, 4, 0);
            histDataTabClose_MDT.Name = "histDataTabClose_MDT";
            histDataTabClose_MDT.Size = new Size(36, 15);
            histDataTabClose_MDT.TabIndex = 2;
            histDataTabClose_MDT.TabStop = true;
            histDataTabClose_MDT.Text = "Close";
            histDataTabClose_MDT.LinkClicked += histDataTabClose_MDT_LinkClicked;
            // 
            // barsGrid
            // 
            barsGrid.AllowUserToAddRows = false;
            barsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            barsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            barsGrid.Columns.AddRange(new DataGridViewColumn[] { hdDate, hdOpen, hdHigh, hdLow, hdClose, hdVolume, hdWap });
            barsGrid.Location = new Point(4, 22);
            barsGrid.Margin = new Padding(4, 3, 4, 3);
            barsGrid.Name = "barsGrid";
            barsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            barsGrid.Size = new Size(588, 210);
            barsGrid.TabIndex = 1;
            // 
            // hdDate
            // 
            hdDate.HeaderText = "Date";
            hdDate.Name = "hdDate";
            hdDate.ReadOnly = true;
            hdDate.Width = 80;
            // 
            // hdOpen
            // 
            hdOpen.HeaderText = "Open";
            hdOpen.Name = "hdOpen";
            hdOpen.ReadOnly = true;
            hdOpen.Width = 60;
            // 
            // hdHigh
            // 
            hdHigh.HeaderText = "High";
            hdHigh.Name = "hdHigh";
            hdHigh.ReadOnly = true;
            hdHigh.Width = 60;
            // 
            // hdLow
            // 
            hdLow.HeaderText = "Low";
            hdLow.Name = "hdLow";
            hdLow.ReadOnly = true;
            hdLow.Width = 60;
            // 
            // hdClose
            // 
            hdClose.HeaderText = "Close";
            hdClose.Name = "hdClose";
            hdClose.ReadOnly = true;
            hdClose.Width = 60;
            // 
            // hdVolume
            // 
            hdVolume.HeaderText = "Volume";
            hdVolume.Name = "hdVolume";
            hdVolume.ReadOnly = true;
            hdVolume.Width = 60;
            // 
            // hdWap
            // 
            hdWap.HeaderText = "WAP";
            hdWap.Name = "hdWap";
            hdWap.ReadOnly = true;
            hdWap.Width = 60;
            // 
            // historicalChart
            // 
            historicalChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            historicalChart.BackColor = Color.LightGray;
            historicalChart.BackgroundImageLayout = ImageLayout.None;
            historicalChart.BackImageTransparentColor = Color.Silver;
            historicalChart.BackSecondaryColor = Color.Silver;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.IsStartedFromZero = false;
            chartArea1.Name = "ChartArea1";
            chartArea1.Position.Auto = false;
            chartArea1.Position.Height = 100F;
            chartArea1.Position.Width = 100F;
            historicalChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            historicalChart.Legends.Add(legend1);
            historicalChart.Location = new Point(617, 3);
            historicalChart.Margin = new Padding(4, 3, 4, 3);
            historicalChart.Name = "historicalChart";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series1.IsVisibleInLegend = false;
            series1.IsXValueIndexed = true;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series1.YValuesPerPoint = 4;
            historicalChart.Series.Add(series1);
            historicalChart.Size = new Size(816, 227);
            historicalChart.TabIndex = 0;
            historicalChart.Text = "Historical Data";
            // 
            // rtBarsTab_MDT
            // 
            rtBarsTab_MDT.BackColor = Color.LightGray;
            rtBarsTab_MDT.Controls.Add(rtBarsCloseLink);
            rtBarsTab_MDT.Controls.Add(rtBarsGrid);
            rtBarsTab_MDT.Controls.Add(rtBarsChart);
            rtBarsTab_MDT.Location = new Point(4, 24);
            rtBarsTab_MDT.Margin = new Padding(4, 3, 4, 3);
            rtBarsTab_MDT.Name = "rtBarsTab_MDT";
            rtBarsTab_MDT.Padding = new Padding(4, 3, 4, 3);
            rtBarsTab_MDT.Size = new Size(1441, 243);
            rtBarsTab_MDT.TabIndex = 2;
            rtBarsTab_MDT.Text = "RT Bars";
            // 
            // rtBarsCloseLink
            // 
            rtBarsCloseLink.AutoSize = true;
            rtBarsCloseLink.Location = new Point(7, 5);
            rtBarsCloseLink.Margin = new Padding(4, 0, 4, 0);
            rtBarsCloseLink.Name = "rtBarsCloseLink";
            rtBarsCloseLink.Size = new Size(36, 15);
            rtBarsCloseLink.TabIndex = 4;
            rtBarsCloseLink.TabStop = true;
            rtBarsCloseLink.Text = "Close";
            rtBarsCloseLink.LinkClicked += rtBarsCloseLink_LinkClicked;
            // 
            // rtBarsGrid
            // 
            rtBarsGrid.AllowUserToAddRows = false;
            rtBarsGrid.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left;
            rtBarsGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            rtBarsGrid.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5, dataGridViewTextBoxColumn6, dataGridViewTextBoxColumn7 });
            rtBarsGrid.Location = new Point(6, 23);
            rtBarsGrid.Margin = new Padding(4, 3, 4, 3);
            rtBarsGrid.Name = "rtBarsGrid";
            rtBarsGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            rtBarsGrid.Size = new Size(588, 210);
            rtBarsGrid.TabIndex = 3;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.HeaderText = "Date";
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.ReadOnly = true;
            dataGridViewTextBoxColumn1.Width = 80;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.HeaderText = "Open";
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.ReadOnly = true;
            dataGridViewTextBoxColumn2.Width = 60;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.HeaderText = "High";
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.ReadOnly = true;
            dataGridViewTextBoxColumn3.Width = 60;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.HeaderText = "Low";
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.ReadOnly = true;
            dataGridViewTextBoxColumn4.Width = 60;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.HeaderText = "Close";
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.ReadOnly = true;
            dataGridViewTextBoxColumn5.Width = 60;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.HeaderText = "Volume";
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.ReadOnly = true;
            dataGridViewTextBoxColumn6.Width = 60;
            // 
            // dataGridViewTextBoxColumn7
            // 
            dataGridViewTextBoxColumn7.HeaderText = "WAP";
            dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            dataGridViewTextBoxColumn7.ReadOnly = true;
            dataGridViewTextBoxColumn7.Width = 60;
            // 
            // rtBarsChart
            // 
            rtBarsChart.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            rtBarsChart.BackColor = Color.LightGray;
            rtBarsChart.BackgroundImageLayout = ImageLayout.None;
            rtBarsChart.BackImageTransparentColor = Color.Silver;
            rtBarsChart.BackSecondaryColor = Color.Silver;
            chartArea2.AxisX.MajorGrid.Enabled = false;
            chartArea2.AxisX.MajorTickMark.Enabled = false;
            chartArea2.AxisY.IsStartedFromZero = false;
            chartArea2.Name = "ChartArea1";
            chartArea2.Position.Auto = false;
            chartArea2.Position.Height = 100F;
            chartArea2.Position.Width = 100F;
            rtBarsChart.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            rtBarsChart.Legends.Add(legend2);
            rtBarsChart.Location = new Point(620, 5);
            rtBarsChart.Margin = new Padding(4, 3, 4, 3);
            rtBarsChart.Name = "rtBarsChart";
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Candlestick;
            series2.IsVisibleInLegend = false;
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            series2.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.DateTime;
            series2.YValuesPerPoint = 4;
            rtBarsChart.Series.Add(series2);
            rtBarsChart.Size = new Size(816, 227);
            rtBarsChart.TabIndex = 2;
            rtBarsChart.Text = "Historical Data";
            // 
            // scannerTab
            // 
            scannerTab.BackColor = Color.LightGray;
            scannerTab.Controls.Add(scannerTab_link);
            scannerTab.Controls.Add(scannerGrid);
            scannerTab.Location = new Point(4, 24);
            scannerTab.Margin = new Padding(4, 3, 4, 3);
            scannerTab.Name = "scannerTab";
            scannerTab.Padding = new Padding(4, 3, 4, 3);
            scannerTab.Size = new Size(1441, 243);
            scannerTab.TabIndex = 3;
            scannerTab.Text = "Scanner Results";
            // 
            // scannerTab_link
            // 
            scannerTab_link.AutoSize = true;
            scannerTab_link.Location = new Point(7, 3);
            scannerTab_link.Margin = new Padding(4, 0, 4, 0);
            scannerTab_link.Name = "scannerTab_link";
            scannerTab_link.Size = new Size(36, 15);
            scannerTab_link.TabIndex = 1;
            scannerTab_link.TabStop = true;
            scannerTab_link.Text = "Close";
            scannerTab_link.LinkClicked += scannerTab_link_LinkClicked;
            // 
            // scannerGrid
            // 
            scannerGrid.AllowUserToAddRows = false;
            scannerGrid.AllowUserToDeleteRows = false;
            scannerGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            scannerGrid.Columns.AddRange(new DataGridViewColumn[] { scanRank, scanContract, scanDistance, scanBenchmark, scanProjection, scanLegStr });
            scannerGrid.Location = new Point(5, 32);
            scannerGrid.Margin = new Padding(4, 3, 4, 3);
            scannerGrid.Name = "scannerGrid";
            scannerGrid.ReadOnly = true;
            scannerGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            scannerGrid.Size = new Size(892, 181);
            scannerGrid.TabIndex = 0;
            // 
            // scanRank
            // 
            scanRank.HeaderText = "Rank";
            scanRank.Name = "scanRank";
            scanRank.ReadOnly = true;
            // 
            // scanContract
            // 
            scanContract.HeaderText = "Contract";
            scanContract.Name = "scanContract";
            scanContract.ReadOnly = true;
            scanContract.Width = 200;
            // 
            // scanDistance
            // 
            scanDistance.HeaderText = "Distance";
            scanDistance.Name = "scanDistance";
            scanDistance.ReadOnly = true;
            // 
            // scanBenchmark
            // 
            scanBenchmark.HeaderText = "Benchmark";
            scanBenchmark.Name = "scanBenchmark";
            scanBenchmark.ReadOnly = true;
            // 
            // scanProjection
            // 
            scanProjection.HeaderText = "Projection";
            scanProjection.Name = "scanProjection";
            scanProjection.ReadOnly = true;
            // 
            // scanLegStr
            // 
            scanLegStr.HeaderText = "Legs";
            scanLegStr.Name = "scanLegStr";
            scanLegStr.ReadOnly = true;
            // 
            // scannerParamsTab
            // 
            scannerParamsTab.BackColor = Color.LightGray;
            scannerParamsTab.Controls.Add(scannerParamsOutput);
            scannerParamsTab.Location = new Point(4, 24);
            scannerParamsTab.Margin = new Padding(4, 3, 4, 3);
            scannerParamsTab.Name = "scannerParamsTab";
            scannerParamsTab.Padding = new Padding(4, 3, 4, 3);
            scannerParamsTab.Size = new Size(1441, 243);
            scannerParamsTab.TabIndex = 4;
            scannerParamsTab.Text = "Scanner Parameters";
            // 
            // scannerParamsOutput
            // 
            scannerParamsOutput.BackColor = SystemColors.Control;
            scannerParamsOutput.Location = new Point(5, 7);
            scannerParamsOutput.Margin = new Padding(4, 3, 4, 3);
            scannerParamsOutput.Multiline = true;
            scannerParamsOutput.Name = "scannerParamsOutput";
            scannerParamsOutput.ReadOnly = true;
            scannerParamsOutput.ScrollBars = ScrollBars.Vertical;
            scannerParamsOutput.Size = new Size(1427, 206);
            scannerParamsOutput.TabIndex = 0;
            // 
            // mktDepthExchanges_MDT
            // 
            mktDepthExchanges_MDT.BackColor = Color.LightGray;
            mktDepthExchanges_MDT.Controls.Add(mktDepthExchangesGrid_MDT);
            mktDepthExchanges_MDT.Controls.Add(clearMktDepthExchanges_Button);
            mktDepthExchanges_MDT.Location = new Point(4, 24);
            mktDepthExchanges_MDT.Margin = new Padding(4, 3, 4, 3);
            mktDepthExchanges_MDT.Name = "mktDepthExchanges_MDT";
            mktDepthExchanges_MDT.Size = new Size(1441, 243);
            mktDepthExchanges_MDT.TabIndex = 5;
            mktDepthExchanges_MDT.Text = "Mkt Depth Exchanges";
            // 
            // mktDepthExchangesGrid_MDT
            // 
            mktDepthExchangesGrid_MDT.AllowUserToAddRows = false;
            mktDepthExchangesGrid_MDT.AllowUserToDeleteRows = false;
            mktDepthExchangesGrid_MDT.AllowUserToOrderColumns = true;
            mktDepthExchangesGrid_MDT.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            mktDepthExchangesGrid_MDT.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            mktDepthExchangesGrid_MDT.Columns.AddRange(new DataGridViewColumn[] { mktDepthExchangesColumn_Exchange, mktDepthExchangesColumn_SecType, mktDepthExchangesColumn_ListingExch, mktDepthExchangesColumn_ServiceDataType, mktDepthExchangesColumn_AggGroup });
            mktDepthExchangesGrid_MDT.Location = new Point(6, 22);
            mktDepthExchangesGrid_MDT.Margin = new Padding(4, 3, 4, 3);
            mktDepthExchangesGrid_MDT.Name = "mktDepthExchangesGrid_MDT";
            mktDepthExchangesGrid_MDT.ReadOnly = true;
            mktDepthExchangesGrid_MDT.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mktDepthExchangesGrid_MDT.Size = new Size(681, 210);
            mktDepthExchangesGrid_MDT.TabIndex = 3;
            // 
            // mktDepthExchangesColumn_Exchange
            // 
            mktDepthExchangesColumn_Exchange.HeaderText = "Exchange";
            mktDepthExchangesColumn_Exchange.Name = "mktDepthExchangesColumn_Exchange";
            mktDepthExchangesColumn_Exchange.ReadOnly = true;
            // 
            // mktDepthExchangesColumn_SecType
            // 
            mktDepthExchangesColumn_SecType.HeaderText = "SecType";
            mktDepthExchangesColumn_SecType.Name = "mktDepthExchangesColumn_SecType";
            mktDepthExchangesColumn_SecType.ReadOnly = true;
            // 
            // mktDepthExchangesColumn_ListingExch
            // 
            mktDepthExchangesColumn_ListingExch.HeaderText = "ListingExch";
            mktDepthExchangesColumn_ListingExch.Name = "mktDepthExchangesColumn_ListingExch";
            mktDepthExchangesColumn_ListingExch.ReadOnly = true;
            // 
            // mktDepthExchangesColumn_ServiceDataType
            // 
            mktDepthExchangesColumn_ServiceDataType.HeaderText = "ServiceDataType";
            mktDepthExchangesColumn_ServiceDataType.Name = "mktDepthExchangesColumn_ServiceDataType";
            mktDepthExchangesColumn_ServiceDataType.ReadOnly = true;
            // 
            // mktDepthExchangesColumn_AggGroup
            // 
            mktDepthExchangesColumn_AggGroup.HeaderText = "AggGroup";
            mktDepthExchangesColumn_AggGroup.Name = "mktDepthExchangesColumn_AggGroup";
            mktDepthExchangesColumn_AggGroup.ReadOnly = true;
            // 
            // clearMktDepthExchanges_Button
            // 
            clearMktDepthExchanges_Button.AutoSize = true;
            clearMktDepthExchanges_Button.Location = new Point(2, 3);
            clearMktDepthExchanges_Button.Margin = new Padding(4, 0, 4, 0);
            clearMktDepthExchanges_Button.Name = "clearMktDepthExchanges_Button";
            clearMktDepthExchanges_Button.Size = new Size(34, 15);
            clearMktDepthExchanges_Button.TabIndex = 2;
            clearMktDepthExchanges_Button.TabStop = true;
            clearMktDepthExchanges_Button.Text = "Clear";
            clearMktDepthExchanges_Button.LinkClicked += ClearMktDepthExchanges_Button_LinkClicked;
            // 
            // symbolSamplesTabData
            // 
            symbolSamplesTabData.BackColor = Color.LightGray;
            symbolSamplesTabData.Controls.Add(clearSymbolSamplesMarketData);
            symbolSamplesTabData.Controls.Add(symbolSamplesDataGridData);
            symbolSamplesTabData.Location = new Point(4, 24);
            symbolSamplesTabData.Margin = new Padding(4, 3, 4, 3);
            symbolSamplesTabData.Name = "symbolSamplesTabData";
            symbolSamplesTabData.Padding = new Padding(4, 3, 4, 3);
            symbolSamplesTabData.Size = new Size(1441, 243);
            symbolSamplesTabData.TabIndex = 5;
            symbolSamplesTabData.Text = "Symbol Samples";
            // 
            // clearSymbolSamplesMarketData
            // 
            clearSymbolSamplesMarketData.AutoSize = true;
            clearSymbolSamplesMarketData.Location = new Point(13, 7);
            clearSymbolSamplesMarketData.Margin = new Padding(4, 0, 4, 0);
            clearSymbolSamplesMarketData.Name = "clearSymbolSamplesMarketData";
            clearSymbolSamplesMarketData.Size = new Size(34, 15);
            clearSymbolSamplesMarketData.TabIndex = 4;
            clearSymbolSamplesMarketData.TabStop = true;
            clearSymbolSamplesMarketData.Text = "Clear";
            clearSymbolSamplesMarketData.LinkClicked += clearSymbolSamplesMarketData_LinkClicked;
            // 
            // symbolSamplesDataGridData
            // 
            symbolSamplesDataGridData.AllowUserToAddRows = false;
            symbolSamplesDataGridData.AllowUserToDeleteRows = false;
            symbolSamplesDataGridData.AllowUserToOrderColumns = true;
            symbolSamplesDataGridData.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            symbolSamplesDataGridData.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            symbolSamplesDataGridData.Columns.AddRange(new DataGridViewColumn[] { symbolSamplesConId, symbolSamplesSymbol, symbolSamplesSecType, symbolSamplesPrimExch, symbolSamplesCurrency, symbolSamplesDerivativeSecTypes, symbolSamplesDescription, symbolSamplesIssuerId });
            symbolSamplesDataGridData.Location = new Point(10, 25);
            symbolSamplesDataGridData.Margin = new Padding(4, 3, 4, 3);
            symbolSamplesDataGridData.Name = "symbolSamplesDataGridData";
            symbolSamplesDataGridData.ReadOnly = true;
            symbolSamplesDataGridData.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            symbolSamplesDataGridData.Size = new Size(1402, 205);
            symbolSamplesDataGridData.TabIndex = 3;
            symbolSamplesDataGridData.Visible = false;
            // 
            // symbolSamplesConId
            // 
            symbolSamplesConId.HeaderText = "ConId";
            symbolSamplesConId.Name = "symbolSamplesConId";
            symbolSamplesConId.ReadOnly = true;
            // 
            // symbolSamplesSymbol
            // 
            symbolSamplesSymbol.HeaderText = "Symbol";
            symbolSamplesSymbol.Name = "symbolSamplesSymbol";
            symbolSamplesSymbol.ReadOnly = true;
            // 
            // symbolSamplesSecType
            // 
            symbolSamplesSecType.HeaderText = "SecType";
            symbolSamplesSecType.Name = "symbolSamplesSecType";
            symbolSamplesSecType.ReadOnly = true;
            // 
            // symbolSamplesPrimExch
            // 
            symbolSamplesPrimExch.HeaderText = "Prim Exch";
            symbolSamplesPrimExch.Name = "symbolSamplesPrimExch";
            symbolSamplesPrimExch.ReadOnly = true;
            // 
            // symbolSamplesCurrency
            // 
            symbolSamplesCurrency.HeaderText = "Currency";
            symbolSamplesCurrency.Name = "symbolSamplesCurrency";
            symbolSamplesCurrency.ReadOnly = true;
            // 
            // symbolSamplesDerivativeSecTypes
            // 
            symbolSamplesDerivativeSecTypes.HeaderText = "Derivative Sec Types";
            symbolSamplesDerivativeSecTypes.Name = "symbolSamplesDerivativeSecTypes";
            symbolSamplesDerivativeSecTypes.ReadOnly = true;
            symbolSamplesDerivativeSecTypes.Width = 200;
            // 
            // symbolSamplesDescription
            // 
            symbolSamplesDescription.HeaderText = "Description";
            symbolSamplesDescription.Name = "symbolSamplesDescription";
            symbolSamplesDescription.ReadOnly = true;
            symbolSamplesDescription.Width = 300;
            // 
            // symbolSamplesIssuerId
            // 
            symbolSamplesIssuerId.HeaderText = "IssuerId";
            symbolSamplesIssuerId.Name = "symbolSamplesIssuerId";
            symbolSamplesIssuerId.ReadOnly = true;
            // 
            // smartComponentsTabPage
            // 
            smartComponentsTabPage.BackColor = Color.LightGray;
            smartComponentsTabPage.Controls.Add(linkLabel1);
            smartComponentsTabPage.Controls.Add(dataGridViewSmartComponents);
            smartComponentsTabPage.Location = new Point(4, 24);
            smartComponentsTabPage.Margin = new Padding(4, 3, 4, 3);
            smartComponentsTabPage.Name = "smartComponentsTabPage";
            smartComponentsTabPage.Size = new Size(1441, 243);
            smartComponentsTabPage.TabIndex = 6;
            smartComponentsTabPage.Text = "Smart Components";
            // 
            // linkLabel1
            // 
            linkLabel1.AutoSize = true;
            linkLabel1.Location = new Point(9, 5);
            linkLabel1.Margin = new Padding(4, 0, 4, 0);
            linkLabel1.Name = "linkLabel1";
            linkLabel1.Size = new Size(34, 15);
            linkLabel1.TabIndex = 3;
            linkLabel1.TabStop = true;
            linkLabel1.Text = "Clear";
            linkLabel1.LinkClicked += linkLabel1_LinkClicked;
            // 
            // dataGridViewSmartComponents
            // 
            dataGridViewSmartComponents.AllowUserToAddRows = false;
            dataGridViewSmartComponents.AllowUserToDeleteRows = false;
            dataGridViewSmartComponents.AllowUserToOrderColumns = true;
            dataGridViewSmartComponents.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridViewSmartComponents.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewSmartComponents.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn25, dataGridViewTextBoxColumn26, dataGridViewTextBoxColumn27 });
            dataGridViewSmartComponents.Location = new Point(6, 23);
            dataGridViewSmartComponents.Margin = new Padding(4, 3, 4, 3);
            dataGridViewSmartComponents.Name = "dataGridViewSmartComponents";
            dataGridViewSmartComponents.ReadOnly = true;
            dataGridViewSmartComponents.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewSmartComponents.Size = new Size(1429, 210);
            dataGridViewSmartComponents.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn25
            // 
            dataGridViewTextBoxColumn25.HeaderText = "Bit number";
            dataGridViewTextBoxColumn25.Name = "dataGridViewTextBoxColumn25";
            dataGridViewTextBoxColumn25.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn26
            // 
            dataGridViewTextBoxColumn26.HeaderText = "Exchange";
            dataGridViewTextBoxColumn26.Name = "dataGridViewTextBoxColumn26";
            dataGridViewTextBoxColumn26.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn27
            // 
            dataGridViewTextBoxColumn27.HeaderText = "Exchange single-letter abbrevation";
            dataGridViewTextBoxColumn27.Name = "dataGridViewTextBoxColumn27";
            dataGridViewTextBoxColumn27.ReadOnly = true;
            dataGridViewTextBoxColumn27.Width = 200;
            // 
            // headTimestampTabPage
            // 
            headTimestampTabPage.BackColor = Color.LightGray;
            headTimestampTabPage.Controls.Add(clearHeadTimestampGridViewlinkLabel);
            headTimestampTabPage.Controls.Add(headTimestampDataGridView);
            headTimestampTabPage.Location = new Point(4, 24);
            headTimestampTabPage.Margin = new Padding(4, 3, 4, 3);
            headTimestampTabPage.Name = "headTimestampTabPage";
            headTimestampTabPage.Size = new Size(1441, 243);
            headTimestampTabPage.TabIndex = 7;
            headTimestampTabPage.Text = "Head Time Stamp";
            // 
            // clearHeadTimestampGridViewlinkLabel
            // 
            clearHeadTimestampGridViewlinkLabel.AutoSize = true;
            clearHeadTimestampGridViewlinkLabel.Location = new Point(9, 5);
            clearHeadTimestampGridViewlinkLabel.Margin = new Padding(4, 0, 4, 0);
            clearHeadTimestampGridViewlinkLabel.Name = "clearHeadTimestampGridViewlinkLabel";
            clearHeadTimestampGridViewlinkLabel.Size = new Size(34, 15);
            clearHeadTimestampGridViewlinkLabel.TabIndex = 3;
            clearHeadTimestampGridViewlinkLabel.TabStop = true;
            clearHeadTimestampGridViewlinkLabel.Text = "Clear";
            clearHeadTimestampGridViewlinkLabel.LinkClicked += clearHeadTimestampGridViewlinkLabel_LinkClicked;
            // 
            // headTimestampDataGridView
            // 
            headTimestampDataGridView.AllowUserToAddRows = false;
            headTimestampDataGridView.AllowUserToDeleteRows = false;
            headTimestampDataGridView.AllowUserToOrderColumns = true;
            headTimestampDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            headTimestampDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            headTimestampDataGridView.Columns.AddRange(new DataGridViewColumn[] { reqIdColumn, headTimestampColumn, conIdColumn, symbolColumn, secTypeColumn, lastTradeDateorContractMonthColumn, strikeColumn, rightColumn, multiplierColumn, exchangeColumn, primaryExchColumn, currencyColumn, localSymbolColumn, tradingClassColumn, includeExpiredColumn, whatToShowColumn });
            headTimestampDataGridView.Location = new Point(6, 23);
            headTimestampDataGridView.Margin = new Padding(4, 3, 4, 3);
            headTimestampDataGridView.Name = "headTimestampDataGridView";
            headTimestampDataGridView.ReadOnly = true;
            headTimestampDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            headTimestampDataGridView.Size = new Size(1429, 210);
            headTimestampDataGridView.TabIndex = 2;
            // 
            // reqIdColumn
            // 
            reqIdColumn.HeaderText = "Req Id";
            reqIdColumn.Name = "reqIdColumn";
            reqIdColumn.ReadOnly = true;
            reqIdColumn.Visible = false;
            // 
            // headTimestampColumn
            // 
            headTimestampColumn.HeaderText = "Head Time Stamp";
            headTimestampColumn.Name = "headTimestampColumn";
            headTimestampColumn.ReadOnly = true;
            // 
            // conIdColumn
            // 
            conIdColumn.HeaderText = "Con Id";
            conIdColumn.Name = "conIdColumn";
            conIdColumn.ReadOnly = true;
            // 
            // symbolColumn
            // 
            symbolColumn.HeaderText = "Symbol";
            symbolColumn.Name = "symbolColumn";
            symbolColumn.ReadOnly = true;
            // 
            // secTypeColumn
            // 
            secTypeColumn.HeaderText = "Sec Type";
            secTypeColumn.Name = "secTypeColumn";
            secTypeColumn.ReadOnly = true;
            // 
            // lastTradeDateorContractMonthColumn
            // 
            lastTradeDateorContractMonthColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.ColumnHeader;
            lastTradeDateorContractMonthColumn.HeaderText = "Last Trade Date / Contract Month";
            lastTradeDateorContractMonthColumn.Name = "lastTradeDateorContractMonthColumn";
            lastTradeDateorContractMonthColumn.ReadOnly = true;
            lastTradeDateorContractMonthColumn.Width = 156;
            // 
            // strikeColumn
            // 
            strikeColumn.HeaderText = "Strike";
            strikeColumn.Name = "strikeColumn";
            strikeColumn.ReadOnly = true;
            // 
            // rightColumn
            // 
            rightColumn.HeaderText = "Right";
            rightColumn.Name = "rightColumn";
            rightColumn.ReadOnly = true;
            // 
            // multiplierColumn
            // 
            multiplierColumn.HeaderText = "Multiplier";
            multiplierColumn.Name = "multiplierColumn";
            multiplierColumn.ReadOnly = true;
            // 
            // exchangeColumn
            // 
            exchangeColumn.HeaderText = "Exchange";
            exchangeColumn.Name = "exchangeColumn";
            exchangeColumn.ReadOnly = true;
            // 
            // primaryExchColumn
            // 
            primaryExchColumn.HeaderText = "Primary Exchange";
            primaryExchColumn.Name = "primaryExchColumn";
            primaryExchColumn.ReadOnly = true;
            // 
            // currencyColumn
            // 
            currencyColumn.HeaderText = "Currency";
            currencyColumn.Name = "currencyColumn";
            currencyColumn.ReadOnly = true;
            // 
            // localSymbolColumn
            // 
            localSymbolColumn.HeaderText = "Local Symbol";
            localSymbolColumn.Name = "localSymbolColumn";
            localSymbolColumn.ReadOnly = true;
            // 
            // tradingClassColumn
            // 
            tradingClassColumn.HeaderText = "Trading Class";
            tradingClassColumn.Name = "tradingClassColumn";
            tradingClassColumn.ReadOnly = true;
            // 
            // includeExpiredColumn
            // 
            includeExpiredColumn.HeaderText = "Include Expired";
            includeExpiredColumn.Name = "includeExpiredColumn";
            includeExpiredColumn.ReadOnly = true;
            // 
            // whatToShowColumn
            // 
            whatToShowColumn.HeaderText = "What To Show";
            whatToShowColumn.Name = "whatToShowColumn";
            whatToShowColumn.ReadOnly = true;
            // 
            // histogramTabPage
            // 
            histogramTabPage.BackColor = Color.LightGray;
            histogramTabPage.Controls.Add(histogramClearLinkLabel);
            histogramTabPage.Controls.Add(histogramDataGridView);
            histogramTabPage.Location = new Point(4, 24);
            histogramTabPage.Margin = new Padding(4, 3, 4, 3);
            histogramTabPage.Name = "histogramTabPage";
            histogramTabPage.Size = new Size(1441, 243);
            histogramTabPage.TabIndex = 8;
            histogramTabPage.Text = "Histogram";
            // 
            // histogramClearLinkLabel
            // 
            histogramClearLinkLabel.AutoSize = true;
            histogramClearLinkLabel.Location = new Point(9, 5);
            histogramClearLinkLabel.Margin = new Padding(4, 0, 4, 0);
            histogramClearLinkLabel.Name = "histogramClearLinkLabel";
            histogramClearLinkLabel.Size = new Size(34, 15);
            histogramClearLinkLabel.TabIndex = 3;
            histogramClearLinkLabel.TabStop = true;
            histogramClearLinkLabel.Text = "Clear";
            histogramClearLinkLabel.LinkClicked += histogramClearLinkLabel_LinkClicked;
            // 
            // histogramDataGridView
            // 
            histogramDataGridView.AllowUserToAddRows = false;
            histogramDataGridView.AllowUserToDeleteRows = false;
            histogramDataGridView.AllowUserToOrderColumns = true;
            histogramDataGridView.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            histogramDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            histogramDataGridView.Columns.AddRange(new DataGridViewColumn[] { Column1, dataGridViewTextBoxColumn16, dataGridViewTextBoxColumn17 });
            histogramDataGridView.Location = new Point(6, 23);
            histogramDataGridView.Margin = new Padding(4, 3, 4, 3);
            histogramDataGridView.Name = "histogramDataGridView";
            histogramDataGridView.ReadOnly = true;
            histogramDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            histogramDataGridView.Size = new Size(1429, 210);
            histogramDataGridView.TabIndex = 2;
            // 
            // Column1
            // 
            Column1.HeaderText = "ReqId";
            Column1.Name = "Column1";
            Column1.ReadOnly = true;
            Column1.Visible = false;
            // 
            // dataGridViewTextBoxColumn16
            // 
            dataGridViewTextBoxColumn16.HeaderText = "Price";
            dataGridViewTextBoxColumn16.Name = "dataGridViewTextBoxColumn16";
            dataGridViewTextBoxColumn16.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn17
            // 
            dataGridViewTextBoxColumn17.HeaderText = "Size";
            dataGridViewTextBoxColumn17.Name = "dataGridViewTextBoxColumn17";
            dataGridViewTextBoxColumn17.ReadOnly = true;
            dataGridViewTextBoxColumn17.Width = 200;
            // 
            // historicalTicksTabPage
            // 
            historicalTicksTabPage.BackColor = Color.LightGray;
            historicalTicksTabPage.Controls.Add(label15);
            historicalTicksTabPage.Controls.Add(linkLabel2);
            historicalTicksTabPage.Controls.Add(dataGridViewHistoricalTicks);
            historicalTicksTabPage.Location = new Point(4, 24);
            historicalTicksTabPage.Margin = new Padding(4, 3, 4, 3);
            historicalTicksTabPage.Name = "historicalTicksTabPage";
            historicalTicksTabPage.Size = new Size(1441, 243);
            historicalTicksTabPage.TabIndex = 9;
            historicalTicksTabPage.Text = "Historical ticks";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(386, 5);
            label15.Margin = new Padding(2, 0, 2, 0);
            label15.Name = "label15";
            label15.Size = new Size(87, 15);
            label15.TabIndex = 6;
            label15.Text = "Historical ticks:";
            // 
            // linkLabel2
            // 
            linkLabel2.AutoSize = true;
            linkLabel2.Location = new Point(9, 5);
            linkLabel2.Margin = new Padding(4, 0, 4, 0);
            linkLabel2.Name = "linkLabel2";
            linkLabel2.Size = new Size(34, 15);
            linkLabel2.TabIndex = 3;
            linkLabel2.TabStop = true;
            linkLabel2.Text = "Clear";
            linkLabel2.LinkClicked += linkLabel2_LinkClicked;
            // 
            // dataGridViewHistoricalTicks
            // 
            dataGridViewHistoricalTicks.AllowUserToAddRows = false;
            dataGridViewHistoricalTicks.AllowUserToDeleteRows = false;
            dataGridViewHistoricalTicks.AllowUserToOrderColumns = true;
            dataGridViewHistoricalTicks.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridViewHistoricalTicks.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewHistoricalTicks.Location = new Point(6, 23);
            dataGridViewHistoricalTicks.Margin = new Padding(4, 3, 4, 3);
            dataGridViewHistoricalTicks.Name = "dataGridViewHistoricalTicks";
            dataGridViewHistoricalTicks.ReadOnly = true;
            dataGridViewHistoricalTicks.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewHistoricalTicks.Size = new Size(1429, 210);
            dataGridViewHistoricalTicks.TabIndex = 2;
            // 
            // tabPageTickByTick
            // 
            tabPageTickByTick.BackColor = Color.LightGray;
            tabPageTickByTick.Controls.Add(linkLabelClearTickByTick);
            tabPageTickByTick.Controls.Add(labelTickByTick);
            tabPageTickByTick.Controls.Add(dataGridViewTickByTick);
            tabPageTickByTick.Location = new Point(4, 24);
            tabPageTickByTick.Margin = new Padding(4, 3, 4, 3);
            tabPageTickByTick.Name = "tabPageTickByTick";
            tabPageTickByTick.Size = new Size(1441, 243);
            tabPageTickByTick.TabIndex = 10;
            tabPageTickByTick.Text = "Tick-By-Tick";
            // 
            // linkLabelClearTickByTick
            // 
            linkLabelClearTickByTick.AutoSize = true;
            linkLabelClearTickByTick.Location = new Point(13, 6);
            linkLabelClearTickByTick.Margin = new Padding(4, 0, 4, 0);
            linkLabelClearTickByTick.Name = "linkLabelClearTickByTick";
            linkLabelClearTickByTick.Size = new Size(34, 15);
            linkLabelClearTickByTick.TabIndex = 8;
            linkLabelClearTickByTick.TabStop = true;
            linkLabelClearTickByTick.Text = "Clear";
            linkLabelClearTickByTick.LinkClicked += linkLabelClearTickByTick_LinkClicked;
            // 
            // labelTickByTick
            // 
            labelTickByTick.AutoSize = true;
            labelTickByTick.Location = new Point(64, 6);
            labelTickByTick.Margin = new Padding(2, 0, 2, 0);
            labelTickByTick.Name = "labelTickByTick";
            labelTickByTick.Size = new Size(75, 15);
            labelTickByTick.TabIndex = 7;
            labelTickByTick.Text = "Tick-By-Tick:";
            // 
            // dataGridViewTickByTick
            // 
            dataGridViewTickByTick.AllowUserToAddRows = false;
            dataGridViewTickByTick.AllowUserToDeleteRows = false;
            dataGridViewTickByTick.AllowUserToOrderColumns = true;
            dataGridViewTickByTick.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            dataGridViewTickByTick.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewTickByTick.Location = new Point(6, 24);
            dataGridViewTickByTick.Margin = new Padding(4, 3, 4, 3);
            dataGridViewTickByTick.Name = "dataGridViewTickByTick";
            dataGridViewTickByTick.ReadOnly = true;
            dataGridViewTickByTick.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridViewTickByTick.Size = new Size(1429, 210);
            dataGridViewTickByTick.TabIndex = 3;
            // 
            // tabHistoricalSchedule
            // 
            tabHistoricalSchedule.BackColor = Color.LightGray;
            tabHistoricalSchedule.Controls.Add(historicalScheduleGrid);
            tabHistoricalSchedule.Controls.Add(linkLabelClearHistoricalSchedule);
            tabHistoricalSchedule.Controls.Add(labelHistoricalSchedule);
            tabHistoricalSchedule.Controls.Add(historicalScheduleOutput);
            tabHistoricalSchedule.Location = new Point(4, 24);
            tabHistoricalSchedule.Margin = new Padding(4, 3, 4, 3);
            tabHistoricalSchedule.Name = "tabHistoricalSchedule";
            tabHistoricalSchedule.Padding = new Padding(4, 3, 4, 3);
            tabHistoricalSchedule.Size = new Size(1441, 243);
            tabHistoricalSchedule.TabIndex = 11;
            tabHistoricalSchedule.Text = "Historical Schedule";
            // 
            // historicalScheduleGrid
            // 
            historicalScheduleGrid.AllowUserToAddRows = false;
            historicalScheduleGrid.AllowUserToDeleteRows = false;
            historicalScheduleGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            historicalScheduleGrid.Columns.AddRange(new DataGridViewColumn[] { historicalSchduleGridStartDateTime, historicalSchduleGridEndDateTime, historicalSchduleGridRefDate });
            historicalScheduleGrid.Location = new Point(7, 61);
            historicalScheduleGrid.Margin = new Padding(4, 3, 4, 3);
            historicalScheduleGrid.Name = "historicalScheduleGrid";
            historicalScheduleGrid.ReadOnly = true;
            historicalScheduleGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            historicalScheduleGrid.Size = new Size(659, 150);
            historicalScheduleGrid.TabIndex = 11;
            // 
            // historicalSchduleGridStartDateTime
            // 
            historicalSchduleGridStartDateTime.HeaderText = "Start";
            historicalSchduleGridStartDateTime.Name = "historicalSchduleGridStartDateTime";
            historicalSchduleGridStartDateTime.ReadOnly = true;
            historicalSchduleGridStartDateTime.Width = 200;
            // 
            // historicalSchduleGridEndDateTime
            // 
            historicalSchduleGridEndDateTime.HeaderText = "End";
            historicalSchduleGridEndDateTime.Name = "historicalSchduleGridEndDateTime";
            historicalSchduleGridEndDateTime.ReadOnly = true;
            historicalSchduleGridEndDateTime.Width = 200;
            // 
            // historicalSchduleGridRefDate
            // 
            historicalSchduleGridRefDate.HeaderText = "Ref Date";
            historicalSchduleGridRefDate.Name = "historicalSchduleGridRefDate";
            historicalSchduleGridRefDate.ReadOnly = true;
            // 
            // linkLabelClearHistoricalSchedule
            // 
            linkLabelClearHistoricalSchedule.AutoSize = true;
            linkLabelClearHistoricalSchedule.Location = new Point(13, 6);
            linkLabelClearHistoricalSchedule.Margin = new Padding(4, 0, 4, 0);
            linkLabelClearHistoricalSchedule.Name = "linkLabelClearHistoricalSchedule";
            linkLabelClearHistoricalSchedule.Size = new Size(34, 15);
            linkLabelClearHistoricalSchedule.TabIndex = 10;
            linkLabelClearHistoricalSchedule.TabStop = true;
            linkLabelClearHistoricalSchedule.Text = "Clear";
            linkLabelClearHistoricalSchedule.LinkClicked += linkLabelClearHistoricalSchedule_LinkClicked;
            // 
            // labelHistoricalSchedule
            // 
            labelHistoricalSchedule.AutoSize = true;
            labelHistoricalSchedule.Location = new Point(59, 6);
            labelHistoricalSchedule.Margin = new Padding(2, 0, 2, 0);
            labelHistoricalSchedule.Name = "labelHistoricalSchedule";
            labelHistoricalSchedule.Size = new Size(108, 15);
            labelHistoricalSchedule.TabIndex = 9;
            labelHistoricalSchedule.Text = "HistoricalSchedule:";
            // 
            // historicalScheduleOutput
            // 
            historicalScheduleOutput.BackColor = SystemColors.ControlLight;
            historicalScheduleOutput.Location = new Point(6, 24);
            historicalScheduleOutput.Margin = new Padding(4, 3, 4, 3);
            historicalScheduleOutput.Name = "historicalScheduleOutput";
            historicalScheduleOutput.ReadOnly = true;
            historicalScheduleOutput.ScrollBars = ScrollBars.Vertical;
            historicalScheduleOutput.Size = new Size(660, 23);
            historicalScheduleOutput.TabIndex = 1;
            // 
            // dataResults_MDT
            // 
            dataResults_MDT.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            dataResults_MDT.Controls.Add(topMktData_MDT);
            dataResults_MDT.Controls.Add(marketScanner_MDT);
            dataResults_MDT.Controls.Add(historicalTicks_MDT);
            dataResults_MDT.Location = new Point(0, 0);
            dataResults_MDT.Margin = new Padding(4, 3, 4, 3);
            dataResults_MDT.Name = "dataResults_MDT";
            dataResults_MDT.SelectedIndex = 0;
            dataResults_MDT.Size = new Size(1444, 261);
            dataResults_MDT.TabIndex = 0;
            dataResults_MDT.Selected += MDT_Selected;
            // 
            // topMktData_MDT
            // 
            topMktData_MDT.BackColor = Color.LightGray;
            topMktData_MDT.Controls.Add(requestMatchingSymbolsMD);
            topMktData_MDT.Controls.Add(cancelMarketDataRequests);
            topMktData_MDT.Controls.Add(marketData_Button);
            topMktData_MDT.Controls.Add(histogram_button);
            topMktData_MDT.Controls.Add(ReqSmartComponents_Button);
            topMktData_MDT.Controls.Add(groupBox6);
            topMktData_MDT.Controls.Add(groupBoxMarketDataType_MDT);
            topMktData_MDT.Controls.Add(deepBookGroupBox);
            topMktData_MDT.Controls.Add(groupBox2);
            topMktData_MDT.Controls.Add(groupBox1);
            topMktData_MDT.Location = new Point(4, 24);
            topMktData_MDT.Margin = new Padding(4, 3, 4, 3);
            topMktData_MDT.Name = "topMktData_MDT";
            topMktData_MDT.Padding = new Padding(4, 3, 4, 3);
            topMktData_MDT.Size = new Size(1436, 233);
            topMktData_MDT.TabIndex = 0;
            topMktData_MDT.Text = "Market Data";
            // 
            // requestMatchingSymbolsMD
            // 
            requestMatchingSymbolsMD.Location = new Point(482, 100);
            requestMatchingSymbolsMD.Margin = new Padding(4, 3, 4, 3);
            requestMatchingSymbolsMD.Name = "requestMatchingSymbolsMD";
            requestMatchingSymbolsMD.Size = new Size(88, 27);
            requestMatchingSymbolsMD.TabIndex = 1;
            requestMatchingSymbolsMD.Text = "Match Symb";
            requestMatchingSymbolsMD.UseVisualStyleBackColor = true;
            requestMatchingSymbolsMD.Click += requestMatchingSymbolsData_Click;
            // 
            // cancelMarketDataRequests
            // 
            cancelMarketDataRequests.Location = new Point(482, 175);
            cancelMarketDataRequests.Margin = new Padding(4, 3, 4, 3);
            cancelMarketDataRequests.Name = "cancelMarketDataRequests";
            cancelMarketDataRequests.Size = new Size(88, 27);
            cancelMarketDataRequests.TabIndex = 3;
            cancelMarketDataRequests.Text = "Stop";
            cancelMarketDataRequests.UseVisualStyleBackColor = true;
            cancelMarketDataRequests.Click += cancelMarketDataRequests_Click;
            // 
            // marketData_Button
            // 
            marketData_Button.Location = new Point(482, 137);
            marketData_Button.Margin = new Padding(4, 3, 4, 3);
            marketData_Button.Name = "marketData_Button";
            marketData_Button.Size = new Size(88, 27);
            marketData_Button.TabIndex = 2;
            marketData_Button.Text = "Add Ticker";
            marketData_Button.UseVisualStyleBackColor = true;
            marketData_Button.Click += marketData_Click;
            // 
            // histogram_button
            // 
            histogram_button.Location = new Point(1274, 174);
            histogram_button.Margin = new Padding(4, 3, 4, 3);
            histogram_button.Name = "histogram_button";
            histogram_button.Size = new Size(88, 27);
            histogram_button.TabIndex = 9;
            histogram_button.Text = "Histogram";
            histogram_button.UseVisualStyleBackColor = true;
            histogram_button.Click += histogram_button_Click;
            // 
            // ReqSmartComponents_Button
            // 
            ReqSmartComponents_Button.Enabled = false;
            ReqSmartComponents_Button.Location = new Point(1275, 90);
            ReqSmartComponents_Button.Margin = new Padding(4, 3, 4, 3);
            ReqSmartComponents_Button.Name = "ReqSmartComponents_Button";
            ReqSmartComponents_Button.Size = new Size(88, 27);
            ReqSmartComponents_Button.TabIndex = 8;
            ReqSmartComponents_Button.Text = "Request";
            ReqSmartComponents_Button.UseVisualStyleBackColor = true;
            ReqSmartComponents_Button.Click += ReqSmartComponents_Button_Click;
            // 
            // groupBox6
            // 
            groupBox6.Controls.Add(label8);
            groupBox6.Controls.Add(bboExchange_comboBox);
            groupBox6.Location = new Point(1265, 8);
            groupBox6.Margin = new Padding(4, 3, 4, 3);
            groupBox6.Name = "groupBox6";
            groupBox6.Padding = new Padding(4, 3, 4, 3);
            groupBox6.Size = new Size(159, 113);
            groupBox6.TabIndex = 7;
            groupBox6.TabStop = false;
            groupBox6.Text = "Smart Components";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(7, 24);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(87, 15);
            label8.TabIndex = 0;
            label8.Text = "BBO Exchange:";
            // 
            // bboExchange_comboBox
            // 
            bboExchange_comboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            bboExchange_comboBox.FormattingEnabled = true;
            bboExchange_comboBox.Location = new Point(7, 43);
            bboExchange_comboBox.Margin = new Padding(4, 3, 4, 3);
            bboExchange_comboBox.Name = "bboExchange_comboBox";
            bboExchange_comboBox.Size = new Size(140, 23);
            bboExchange_comboBox.TabIndex = 1;
            // 
            // groupBoxMarketDataType_MDT
            // 
            groupBoxMarketDataType_MDT.Controls.Add(comboBoxMarketDataType_MDT);
            groupBoxMarketDataType_MDT.Location = new Point(1008, 156);
            groupBoxMarketDataType_MDT.Margin = new Padding(4, 3, 4, 3);
            groupBoxMarketDataType_MDT.Name = "groupBoxMarketDataType_MDT";
            groupBoxMarketDataType_MDT.Padding = new Padding(4, 3, 4, 3);
            groupBoxMarketDataType_MDT.Size = new Size(250, 58);
            groupBoxMarketDataType_MDT.TabIndex = 6;
            groupBoxMarketDataType_MDT.TabStop = false;
            groupBoxMarketDataType_MDT.Text = "Market Data Type";
            // 
            // comboBoxMarketDataType_MDT
            // 
            comboBoxMarketDataType_MDT.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxMarketDataType_MDT.FormattingEnabled = true;
            comboBoxMarketDataType_MDT.Location = new Point(15, 18);
            comboBoxMarketDataType_MDT.Margin = new Padding(4, 3, 4, 3);
            comboBoxMarketDataType_MDT.Name = "comboBoxMarketDataType_MDT";
            comboBoxMarketDataType_MDT.Size = new Size(213, 23);
            comboBoxMarketDataType_MDT.TabIndex = 0;
            comboBoxMarketDataType_MDT.SelectedIndexChanged += comboBoxMarketDataType_MDT_SelectedIndexChanged;
            // 
            // deepBookGroupBox
            // 
            deepBookGroupBox.Controls.Add(cbSmartDepth);
            deepBookGroupBox.Controls.Add(ReqMktDepthExchanges_Button);
            deepBookGroupBox.Controls.Add(deepBookEntries);
            deepBookGroupBox.Controls.Add(deepBookEntriesLabel);
            deepBookGroupBox.Controls.Add(deepBook_Button);
            deepBookGroupBox.Location = new Point(1006, 7);
            deepBookGroupBox.Margin = new Padding(4, 3, 4, 3);
            deepBookGroupBox.Name = "deepBookGroupBox";
            deepBookGroupBox.Padding = new Padding(4, 3, 4, 3);
            deepBookGroupBox.Size = new Size(250, 120);
            deepBookGroupBox.TabIndex = 5;
            deepBookGroupBox.TabStop = false;
            deepBookGroupBox.Text = "Market Depth";
            // 
            // cbSmartDepth
            // 
            cbSmartDepth.AutoSize = true;
            cbSmartDepth.Checked = true;
            cbSmartDepth.CheckState = CheckState.Checked;
            cbSmartDepth.Location = new Point(12, 57);
            cbSmartDepth.Margin = new Padding(4, 3, 4, 3);
            cbSmartDepth.Name = "cbSmartDepth";
            cbSmartDepth.Size = new Size(98, 19);
            cbSmartDepth.TabIndex = 2;
            cbSmartDepth.Text = "SMART Depth";
            cbSmartDepth.UseVisualStyleBackColor = true;
            // 
            // ReqMktDepthExchanges_Button
            // 
            ReqMktDepthExchanges_Button.Location = new Point(12, 83);
            ReqMktDepthExchanges_Button.Margin = new Padding(4, 3, 4, 3);
            ReqMktDepthExchanges_Button.Name = "ReqMktDepthExchanges_Button";
            ReqMktDepthExchanges_Button.Size = new Size(96, 27);
            ReqMktDepthExchanges_Button.TabIndex = 3;
            ReqMktDepthExchanges_Button.Text = "Exchanges";
            ReqMktDepthExchanges_Button.UseVisualStyleBackColor = true;
            ReqMktDepthExchanges_Button.Click += ReqMktDepthExchanges_Button_Click;
            // 
            // deepBookEntries
            // 
            deepBookEntries.Location = new Point(121, 23);
            deepBookEntries.Margin = new Padding(4, 3, 4, 3);
            deepBookEntries.Name = "deepBookEntries";
            deepBookEntries.Size = new Size(116, 23);
            deepBookEntries.TabIndex = 1;
            deepBookEntries.Text = "20";
            // 
            // deepBookEntriesLabel
            // 
            deepBookEntriesLabel.AutoSize = true;
            deepBookEntriesLabel.Location = new Point(7, 27);
            deepBookEntriesLabel.Margin = new Padding(4, 0, 4, 0);
            deepBookEntriesLabel.Name = "deepBookEntriesLabel";
            deepBookEntriesLabel.Size = new Size(103, 15);
            deepBookEntriesLabel.TabIndex = 0;
            deepBookEntriesLabel.Text = "Number of entries";
            // 
            // deepBook_Button
            // 
            deepBook_Button.Location = new Point(142, 83);
            deepBook_Button.Margin = new Padding(4, 3, 4, 3);
            deepBook_Button.Name = "deepBook_Button";
            deepBook_Button.Size = new Size(96, 27);
            deepBook_Button.TabIndex = 4;
            deepBook_Button.Text = "Deep Book";
            deepBook_Button.UseVisualStyleBackColor = true;
            deepBook_Button.Click += deepBook_Click;
            // 
            // groupBox2
            // 
            groupBox2.Controls.Add(primaryExchange);
            groupBox2.Controls.Add(primaryExchLabel);
            groupBox2.Controls.Add(genericTickList);
            groupBox2.Controls.Add(genericTickListLabel);
            groupBox2.Controls.Add(mdRightLabel);
            groupBox2.Controls.Add(mdContractRight);
            groupBox2.Controls.Add(putcall_label_TMD_MDT);
            groupBox2.Controls.Add(multiplier_TMD_MDT);
            groupBox2.Controls.Add(symbol_label_TMD_MDT);
            groupBox2.Controls.Add(secType_TMD_MDT);
            groupBox2.Controls.Add(label1);
            groupBox2.Controls.Add(exchange_label_TMD_MDT);
            groupBox2.Controls.Add(localSymbol_TMD_MDT);
            groupBox2.Controls.Add(currency_label_TMD_MDT);
            groupBox2.Controls.Add(lastTradeDateOrContractMonth_TMD_MDT);
            groupBox2.Controls.Add(symbol_TMD_MDT);
            groupBox2.Controls.Add(strike_TMD_MDT);
            groupBox2.Controls.Add(currency_TMD_MDT);
            groupBox2.Controls.Add(exchange_TMD_MDT);
            groupBox2.Controls.Add(localSymbol_label_TMD_MDT);
            groupBox2.Controls.Add(lastTradeDate_label_TMD_MDT);
            groupBox2.Controls.Add(strike_label_TMD_MDT);
            groupBox2.Location = new Point(7, 7);
            groupBox2.Margin = new Padding(4, 3, 4, 3);
            groupBox2.Name = "groupBox2";
            groupBox2.Padding = new Padding(4, 3, 4, 3);
            groupBox2.Size = new Size(468, 207);
            groupBox2.TabIndex = 0;
            groupBox2.TabStop = false;
            groupBox2.Text = "Contract";
            // 
            // primaryExchange
            // 
            primaryExchange.Location = new Point(99, 168);
            primaryExchange.Margin = new Padding(4, 3, 4, 3);
            primaryExchange.Name = "primaryExchange";
            primaryExchange.Size = new Size(116, 23);
            primaryExchange.TabIndex = 11;
            // 
            // primaryExchLabel
            // 
            primaryExchLabel.AutoSize = true;
            primaryExchLabel.Location = new Point(9, 172);
            primaryExchLabel.Margin = new Padding(4, 0, 4, 0);
            primaryExchLabel.Name = "primaryExchLabel";
            primaryExchLabel.Size = new Size(79, 15);
            primaryExchLabel.TabIndex = 10;
            primaryExchLabel.Text = "Primary Exch.";
            // 
            // genericTickList
            // 
            genericTickList.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            genericTickList.Location = new Point(341, 17);
            genericTickList.Margin = new Padding(4, 3, 4, 3);
            genericTickList.Name = "genericTickList";
            genericTickList.Size = new Size(121, 23);
            genericTickList.TabIndex = 13;
            // 
            // genericTickListLabel
            // 
            genericTickListLabel.AutoSize = true;
            genericTickListLabel.Location = new Point(223, 21);
            genericTickListLabel.Margin = new Padding(4, 0, 4, 0);
            genericTickListLabel.Name = "genericTickListLabel";
            genericTickListLabel.Size = new Size(87, 15);
            genericTickListLabel.TabIndex = 12;
            genericTickListLabel.Text = "Generic tick list";
            // 
            // mdRightLabel
            // 
            mdRightLabel.AutoSize = true;
            mdRightLabel.Location = new Point(262, 99);
            mdRightLabel.Margin = new Padding(4, 0, 4, 0);
            mdRightLabel.Name = "mdRightLabel";
            mdRightLabel.Size = new Size(50, 15);
            mdRightLabel.TabIndex = 16;
            mdRightLabel.Text = "Put/Call";
            // 
            // mdContractRight
            // 
            mdContractRight.FormattingEnabled = true;
            mdContractRight.Location = new Point(341, 98);
            mdContractRight.Margin = new Padding(4, 3, 4, 3);
            mdContractRight.Name = "mdContractRight";
            mdContractRight.Size = new Size(121, 23);
            mdContractRight.TabIndex = 17;
            // 
            // putcall_label_TMD_MDT
            // 
            putcall_label_TMD_MDT.AutoSize = true;
            putcall_label_TMD_MDT.Location = new Point(258, 164);
            putcall_label_TMD_MDT.Margin = new Padding(4, 0, 4, 0);
            putcall_label_TMD_MDT.Name = "putcall_label_TMD_MDT";
            putcall_label_TMD_MDT.Size = new Size(58, 15);
            putcall_label_TMD_MDT.TabIndex = 20;
            putcall_label_TMD_MDT.Text = "Multiplier";
            // 
            // multiplier_TMD_MDT
            // 
            multiplier_TMD_MDT.Location = new Point(341, 164);
            multiplier_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            multiplier_TMD_MDT.Name = "multiplier_TMD_MDT";
            multiplier_TMD_MDT.Size = new Size(121, 23);
            multiplier_TMD_MDT.TabIndex = 21;
            // 
            // symbol_label_TMD_MDT
            // 
            symbol_label_TMD_MDT.AutoSize = true;
            symbol_label_TMD_MDT.Location = new Point(44, 21);
            symbol_label_TMD_MDT.Margin = new Padding(4, 0, 4, 0);
            symbol_label_TMD_MDT.Name = "symbol_label_TMD_MDT";
            symbol_label_TMD_MDT.Size = new Size(47, 15);
            symbol_label_TMD_MDT.TabIndex = 0;
            symbol_label_TMD_MDT.Text = "Symbol";
            // 
            // secType_TMD_MDT
            // 
            secType_TMD_MDT.FormattingEnabled = true;
            secType_TMD_MDT.Items.AddRange(new object[] { "STK", "OPT", "FUT", "CONTFUT", "CASH", "BOND", "CFD", "FOP", "WAR", "IOPT", "FWD", "BAG", "IND", "BILL", "FUND", "FIXED", "SLB", "NEWS", "CMDTY", "BSK", "ICU", "ICS", "CRYPTO" });
            secType_TMD_MDT.Location = new Point(99, 46);
            secType_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            secType_TMD_MDT.Name = "secType_TMD_MDT";
            secType_TMD_MDT.Size = new Size(116, 23);
            secType_TMD_MDT.TabIndex = 3;
            secType_TMD_MDT.Text = "STK";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(34, 46);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(49, 15);
            label1.TabIndex = 2;
            label1.Text = "SecType";
            // 
            // exchange_label_TMD_MDT
            // 
            exchange_label_TMD_MDT.AutoSize = true;
            exchange_label_TMD_MDT.Location = new Point(28, 107);
            exchange_label_TMD_MDT.Margin = new Padding(4, 0, 4, 0);
            exchange_label_TMD_MDT.Name = "exchange_label_TMD_MDT";
            exchange_label_TMD_MDT.Size = new Size(58, 15);
            exchange_label_TMD_MDT.TabIndex = 6;
            exchange_label_TMD_MDT.Text = "Exchange";
            // 
            // localSymbol_TMD_MDT
            // 
            localSymbol_TMD_MDT.Location = new Point(99, 138);
            localSymbol_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            localSymbol_TMD_MDT.Name = "localSymbol_TMD_MDT";
            localSymbol_TMD_MDT.Size = new Size(116, 23);
            localSymbol_TMD_MDT.TabIndex = 9;
            // 
            // currency_label_TMD_MDT
            // 
            currency_label_TMD_MDT.AutoSize = true;
            currency_label_TMD_MDT.Location = new Point(35, 77);
            currency_label_TMD_MDT.Margin = new Padding(4, 0, 4, 0);
            currency_label_TMD_MDT.Name = "currency_label_TMD_MDT";
            currency_label_TMD_MDT.Size = new Size(55, 15);
            currency_label_TMD_MDT.TabIndex = 4;
            currency_label_TMD_MDT.Text = "Currency";
            // 
            // lastTradeDateOrContractMonth_TMD_MDT
            // 
            lastTradeDateOrContractMonth_TMD_MDT.Location = new Point(341, 53);
            lastTradeDateOrContractMonth_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            lastTradeDateOrContractMonth_TMD_MDT.Name = "lastTradeDateOrContractMonth_TMD_MDT";
            lastTradeDateOrContractMonth_TMD_MDT.Size = new Size(121, 23);
            lastTradeDateOrContractMonth_TMD_MDT.TabIndex = 15;
            // 
            // symbol_TMD_MDT
            // 
            symbol_TMD_MDT.Location = new Point(99, 17);
            symbol_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            symbol_TMD_MDT.Name = "symbol_TMD_MDT";
            symbol_TMD_MDT.Size = new Size(116, 23);
            symbol_TMD_MDT.TabIndex = 1;
            symbol_TMD_MDT.Text = "AAPL";
            // 
            // strike_TMD_MDT
            // 
            strike_TMD_MDT.Location = new Point(341, 130);
            strike_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            strike_TMD_MDT.Name = "strike_TMD_MDT";
            strike_TMD_MDT.Size = new Size(121, 23);
            strike_TMD_MDT.TabIndex = 19;
            // 
            // currency_TMD_MDT
            // 
            currency_TMD_MDT.Location = new Point(99, 77);
            currency_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            currency_TMD_MDT.Name = "currency_TMD_MDT";
            currency_TMD_MDT.Size = new Size(116, 23);
            currency_TMD_MDT.TabIndex = 5;
            currency_TMD_MDT.Text = "USD";
            // 
            // exchange_TMD_MDT
            // 
            exchange_TMD_MDT.Location = new Point(99, 107);
            exchange_TMD_MDT.Margin = new Padding(4, 3, 4, 3);
            exchange_TMD_MDT.Name = "exchange_TMD_MDT";
            exchange_TMD_MDT.Size = new Size(116, 23);
            exchange_TMD_MDT.TabIndex = 7;
            exchange_TMD_MDT.Text = "SMART";
            // 
            // localSymbol_label_TMD_MDT
            // 
            localSymbol_label_TMD_MDT.AutoSize = true;
            localSymbol_label_TMD_MDT.Location = new Point(10, 138);
            localSymbol_label_TMD_MDT.Margin = new Padding(4, 0, 4, 0);
            localSymbol_label_TMD_MDT.Name = "localSymbol_label_TMD_MDT";
            localSymbol_label_TMD_MDT.Size = new Size(78, 15);
            localSymbol_label_TMD_MDT.TabIndex = 8;
            localSymbol_label_TMD_MDT.Text = "Local Symbol";
            // 
            // lastTradeDate_label_TMD_MDT
            // 
            lastTradeDate_label_TMD_MDT.Location = new Point(223, 53);
            lastTradeDate_label_TMD_MDT.Margin = new Padding(4, 0, 4, 0);
            lastTradeDate_label_TMD_MDT.Name = "lastTradeDate_label_TMD_MDT";
            lastTradeDate_label_TMD_MDT.Size = new Size(107, 32);
            lastTradeDate_label_TMD_MDT.TabIndex = 14;
            lastTradeDate_label_TMD_MDT.Text = "Last trade date / contract month";
            // 
            // strike_label_TMD_MDT
            // 
            strike_label_TMD_MDT.AutoSize = true;
            strike_label_TMD_MDT.Location = new Point(275, 130);
            strike_label_TMD_MDT.Margin = new Padding(4, 0, 4, 0);
            strike_label_TMD_MDT.Name = "strike_label_TMD_MDT";
            strike_label_TMD_MDT.Size = new Size(36, 15);
            strike_label_TMD_MDT.TabIndex = 18;
            strike_label_TMD_MDT.Text = "Strike";
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(histScheduleButton);
            groupBox1.Controls.Add(cbKeepUpToDate);
            groupBox1.Controls.Add(headTimestamp_button);
            groupBox1.Controls.Add(contractMDRTH);
            groupBox1.Controls.Add(realTime_Button);
            groupBox1.Controls.Add(histData_Button);
            groupBox1.Controls.Add(hdEndDate_label_HDT);
            groupBox1.Controls.Add(label12);
            groupBox1.Controls.Add(hdRequest_EndTime);
            groupBox1.Controls.Add(hdRequest_WhatToShow);
            groupBox1.Controls.Add(hdRequest_Duration);
            groupBox1.Controls.Add(includeExpired);
            groupBox1.Controls.Add(hdRequest_BarSize);
            groupBox1.Controls.Add(label10);
            groupBox1.Controls.Add(label11);
            groupBox1.Controls.Add(hdRequest_TimeUnit);
            groupBox1.Location = new Point(593, 7);
            groupBox1.Margin = new Padding(4, 3, 4, 3);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(4, 3, 4, 3);
            groupBox1.Size = new Size(379, 207);
            groupBox1.TabIndex = 4;
            groupBox1.TabStop = false;
            groupBox1.Text = "Bar request";
            // 
            // histScheduleButton
            // 
            histScheduleButton.Location = new Point(69, 136);
            histScheduleButton.Margin = new Padding(4, 3, 4, 3);
            histScheduleButton.Name = "histScheduleButton";
            histScheduleButton.Size = new Size(139, 27);
            histScheduleButton.TabIndex = 12;
            histScheduleButton.Text = "Historical Schedule";
            histScheduleButton.UseVisualStyleBackColor = true;
            histScheduleButton.Click += histScheduleButton_Click;
            // 
            // cbKeepUpToDate
            // 
            cbKeepUpToDate.AutoSize = true;
            cbKeepUpToDate.Location = new Point(258, 76);
            cbKeepUpToDate.Margin = new Padding(4, 3, 4, 3);
            cbKeepUpToDate.Name = "cbKeepUpToDate";
            cbKeepUpToDate.Size = new Size(109, 19);
            cbKeepUpToDate.TabIndex = 9;
            cbKeepUpToDate.Text = "Keep up to date";
            cbKeepUpToDate.UseVisualStyleBackColor = true;
            // 
            // headTimestamp_button
            // 
            headTimestamp_button.Location = new Point(258, 168);
            headTimestamp_button.Margin = new Padding(4, 3, 4, 3);
            headTimestamp_button.Name = "headTimestamp_button";
            headTimestamp_button.Size = new Size(106, 27);
            headTimestamp_button.TabIndex = 15;
            headTimestamp_button.Text = "Head timestamp";
            headTimestamp_button.UseVisualStyleBackColor = true;
            headTimestamp_button.Click += headTimestamp_button_Click;
            // 
            // contractMDRTH
            // 
            contractMDRTH.AutoSize = true;
            contractMDRTH.Location = new Point(258, 22);
            contractMDRTH.Margin = new Padding(4, 3, 4, 3);
            contractMDRTH.Name = "contractMDRTH";
            contractMDRTH.Size = new Size(73, 19);
            contractMDRTH.TabIndex = 2;
            contractMDRTH.Text = "RTH only";
            contractMDRTH.UseVisualStyleBackColor = true;
            // 
            // realTime_Button
            // 
            realTime_Button.Location = new Point(163, 168);
            realTime_Button.Margin = new Padding(4, 3, 4, 3);
            realTime_Button.Name = "realTime_Button";
            realTime_Button.Size = new Size(88, 27);
            realTime_Button.TabIndex = 14;
            realTime_Button.Text = "Real Time";
            realTime_Button.UseVisualStyleBackColor = true;
            realTime_Button.Click += realTime_Button_Click;
            // 
            // histData_Button
            // 
            histData_Button.Location = new Point(69, 168);
            histData_Button.Margin = new Padding(4, 3, 4, 3);
            histData_Button.Name = "histData_Button";
            histData_Button.Size = new Size(88, 27);
            histData_Button.TabIndex = 13;
            histData_Button.Text = "Historical";
            histData_Button.UseVisualStyleBackColor = true;
            histData_Button.Click += histDataButton_Click;
            // 
            // hdEndDate_label_HDT
            // 
            hdEndDate_label_HDT.AutoSize = true;
            hdEndDate_label_HDT.Location = new Point(31, 21);
            hdEndDate_label_HDT.Margin = new Padding(4, 0, 4, 0);
            hdEndDate_label_HDT.Name = "hdEndDate_label_HDT";
            hdEndDate_label_HDT.Size = new Size(27, 15);
            hdEndDate_label_HDT.TabIndex = 0;
            hdEndDate_label_HDT.Text = "End";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(22, 107);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(36, 15);
            label12.TabIndex = 10;
            label12.Text = "Show";
            // 
            // hdRequest_EndTime
            // 
            hdRequest_EndTime.Location = new Point(69, 21);
            hdRequest_EndTime.Margin = new Padding(4, 3, 4, 3);
            hdRequest_EndTime.Name = "hdRequest_EndTime";
            hdRequest_EndTime.Size = new Size(181, 23);
            hdRequest_EndTime.TabIndex = 1;
            hdRequest_EndTime.Text = "20220808 23:59:59 US/Eastern";
            // 
            // hdRequest_WhatToShow
            // 
            hdRequest_WhatToShow.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            hdRequest_WhatToShow.FormattingEnabled = true;
            hdRequest_WhatToShow.Items.AddRange(new object[] { "TRADES", "MIDPOINT", "BID", "ASK", "BID_ASK", "HISTORICAL_VOLATILITY", "OPTION_IMPLIED_VOLATILITY", "YIELD_BID", "YIELD_ASK", "YIELD_BID_ASK", "YIELD_LAST", "ADJUSTED_LAST" });
            hdRequest_WhatToShow.Location = new Point(69, 106);
            hdRequest_WhatToShow.Margin = new Padding(4, 3, 4, 3);
            hdRequest_WhatToShow.Name = "hdRequest_WhatToShow";
            hdRequest_WhatToShow.Size = new Size(181, 20);
            hdRequest_WhatToShow.TabIndex = 11;
            hdRequest_WhatToShow.Text = "MIDPOINT";
            // 
            // hdRequest_Duration
            // 
            hdRequest_Duration.Location = new Point(69, 47);
            hdRequest_Duration.Margin = new Padding(4, 3, 4, 3);
            hdRequest_Duration.Name = "hdRequest_Duration";
            hdRequest_Duration.Size = new Size(78, 23);
            hdRequest_Duration.TabIndex = 4;
            hdRequest_Duration.Text = "10";
            // 
            // includeExpired
            // 
            includeExpired.AutoSize = true;
            includeExpired.Location = new Point(258, 52);
            includeExpired.Margin = new Padding(4, 3, 4, 3);
            includeExpired.Name = "includeExpired";
            includeExpired.Size = new Size(65, 19);
            includeExpired.TabIndex = 6;
            includeExpired.Text = "Expired";
            includeExpired.UseVisualStyleBackColor = true;
            // 
            // hdRequest_BarSize
            // 
            hdRequest_BarSize.Font = new Font("Microsoft Sans Serif", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            hdRequest_BarSize.FormattingEnabled = true;
            hdRequest_BarSize.Items.AddRange(new object[] { "1 sec", "5 secs", "15 secs", "30 secs", "1 min", "2 mins", "3 mins", "5 mins", "15 mins", "30 mins", "1 hour", "1 day", "1 week", "1 month" });
            hdRequest_BarSize.Location = new Point(69, 76);
            hdRequest_BarSize.Margin = new Padding(4, 3, 4, 3);
            hdRequest_BarSize.Name = "hdRequest_BarSize";
            hdRequest_BarSize.Size = new Size(181, 21);
            hdRequest_BarSize.TabIndex = 8;
            hdRequest_BarSize.Text = "1 day";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(7, 47);
            label10.Margin = new Padding(4, 0, 4, 0);
            label10.Name = "label10";
            label10.Size = new Size(53, 15);
            label10.TabIndex = 3;
            label10.Text = "Duration";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(8, 81);
            label11.Margin = new Padding(4, 0, 4, 0);
            label11.Name = "label11";
            label11.Size = new Size(47, 15);
            label11.TabIndex = 7;
            label11.Text = "Bar Size";
            // 
            // hdRequest_TimeUnit
            // 
            hdRequest_TimeUnit.FormattingEnabled = true;
            hdRequest_TimeUnit.Items.AddRange(new object[] { "S", "D", "W", "M", "Y" });
            hdRequest_TimeUnit.Location = new Point(154, 47);
            hdRequest_TimeUnit.Margin = new Padding(4, 3, 4, 3);
            hdRequest_TimeUnit.Name = "hdRequest_TimeUnit";
            hdRequest_TimeUnit.Size = new Size(96, 23);
            hdRequest_TimeUnit.TabIndex = 5;
            hdRequest_TimeUnit.Text = "D";
            // 
            // marketScanner_MDT
            // 
            marketScanner_MDT.BackColor = Color.LightGray;
            marketScanner_MDT.Controls.Add(groupBox8);
            marketScanner_MDT.Controls.Add(groupBox4);
            marketScanner_MDT.Controls.Add(scannerParamsRequest_button);
            marketScanner_MDT.Location = new Point(4, 24);
            marketScanner_MDT.Margin = new Padding(4, 3, 4, 3);
            marketScanner_MDT.Name = "marketScanner_MDT";
            marketScanner_MDT.Padding = new Padding(4, 3, 4, 3);
            marketScanner_MDT.Size = new Size(1436, 233);
            marketScanner_MDT.TabIndex = 4;
            marketScanner_MDT.Text = "Scanner";
            // 
            // groupBox8
            // 
            groupBox8.Controls.Add(FilterOptionRemove_button);
            groupBox8.Controls.Add(FilterOptionAdd_button);
            groupBox8.Controls.Add(label17);
            groupBox8.Controls.Add(textBoxFilterValue);
            groupBox8.Controls.Add(label16);
            groupBox8.Controls.Add(comboBoxFilterName);
            groupBox8.Controls.Add(listViewFilterOptions);
            groupBox8.Location = new Point(469, 7);
            groupBox8.Margin = new Padding(4, 3, 4, 3);
            groupBox8.Name = "groupBox8";
            groupBox8.Padding = new Padding(4, 3, 4, 3);
            groupBox8.Size = new Size(562, 207);
            groupBox8.TabIndex = 14;
            groupBox8.TabStop = false;
            groupBox8.Text = "Filter options";
            // 
            // FilterOptionRemove_button
            // 
            FilterOptionRemove_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FilterOptionRemove_button.Location = new Point(468, 75);
            FilterOptionRemove_button.Margin = new Padding(4, 3, 4, 3);
            FilterOptionRemove_button.Name = "FilterOptionRemove_button";
            FilterOptionRemove_button.Size = new Size(88, 27);
            FilterOptionRemove_button.TabIndex = 6;
            FilterOptionRemove_button.Text = "Remove";
            FilterOptionRemove_button.UseVisualStyleBackColor = true;
            FilterOptionRemove_button.Click += FilterOptionRemove_button_Click;
            // 
            // FilterOptionAdd_button
            // 
            FilterOptionAdd_button.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            FilterOptionAdd_button.Location = new Point(373, 75);
            FilterOptionAdd_button.Margin = new Padding(4, 3, 4, 3);
            FilterOptionAdd_button.Name = "FilterOptionAdd_button";
            FilterOptionAdd_button.Size = new Size(88, 27);
            FilterOptionAdd_button.TabIndex = 5;
            FilterOptionAdd_button.Text = "Add";
            FilterOptionAdd_button.UseVisualStyleBackColor = true;
            FilterOptionAdd_button.Click += FilterOptionAdd_button_Click;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Location = new Point(475, 22);
            label17.Margin = new Padding(4, 0, 4, 0);
            label17.Name = "label17";
            label17.Size = new Size(38, 15);
            label17.TabIndex = 4;
            label17.Text = "Value:";
            // 
            // textBoxFilterValue
            // 
            textBoxFilterValue.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            textBoxFilterValue.Location = new Point(478, 45);
            textBoxFilterValue.Margin = new Padding(4, 3, 4, 3);
            textBoxFilterValue.Name = "textBoxFilterValue";
            textBoxFilterValue.Size = new Size(76, 23);
            textBoxFilterValue.TabIndex = 3;
            // 
            // label16
            // 
            label16.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            label16.AutoSize = true;
            label16.Location = new Point(293, 22);
            label16.Margin = new Padding(4, 0, 4, 0);
            label16.Name = "label16";
            label16.Size = new Size(42, 15);
            label16.TabIndex = 2;
            label16.Text = "Name:";
            // 
            // comboBoxFilterName
            // 
            comboBoxFilterName.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            comboBoxFilterName.FormattingEnabled = true;
            comboBoxFilterName.Location = new Point(293, 44);
            comboBoxFilterName.Margin = new Padding(4, 3, 4, 3);
            comboBoxFilterName.Name = "comboBoxFilterName";
            comboBoxFilterName.Size = new Size(178, 23);
            comboBoxFilterName.TabIndex = 1;
            // 
            // listViewFilterOptions
            // 
            listViewFilterOptions.Columns.AddRange(new ColumnHeader[] { columnHeader3, columnHeader4 });
            listViewFilterOptions.FullRowSelect = true;
            listViewFilterOptions.Location = new Point(7, 20);
            listViewFilterOptions.Margin = new Padding(4, 3, 4, 3);
            listViewFilterOptions.Name = "listViewFilterOptions";
            listViewFilterOptions.Size = new Size(279, 179);
            listViewFilterOptions.TabIndex = 0;
            listViewFilterOptions.UseCompatibleStateImageBehavior = false;
            listViewFilterOptions.View = View.Details;
            // 
            // columnHeader3
            // 
            columnHeader3.Text = "Name";
            columnHeader3.Width = 175;
            // 
            // columnHeader4
            // 
            columnHeader4.Text = "Value";
            // 
            // groupBox4
            // 
            groupBox4.Controls.Add(scanCode);
            groupBox4.Controls.Add(scanInstrument);
            groupBox4.Controls.Add(scannerRequest_Button);
            groupBox4.Controls.Add(scanLocation);
            groupBox4.Controls.Add(scanStockType);
            groupBox4.Controls.Add(scanNumRows);
            groupBox4.Controls.Add(scanNumRows_label);
            groupBox4.Controls.Add(scanCode_label);
            groupBox4.Controls.Add(scanStockType_label);
            groupBox4.Controls.Add(scanInstrument_label);
            groupBox4.Controls.Add(scanLocation_label);
            groupBox4.Location = new Point(7, 7);
            groupBox4.Margin = new Padding(4, 3, 4, 3);
            groupBox4.Name = "groupBox4";
            groupBox4.Padding = new Padding(4, 3, 4, 3);
            groupBox4.Size = new Size(308, 186);
            groupBox4.TabIndex = 13;
            groupBox4.TabStop = false;
            groupBox4.Text = "Scanner Filters";
            // 
            // scanCode
            // 
            scanCode.FormattingEnabled = true;
            scanCode.Items.AddRange(new object[] { "LOW_OPT_VOL_PUT_CALL_RATIO", "HIGH_OPT_IMP_VOLAT_OVER_HIST", "LOW_OPT_IMP_VOLAT_OVER_HIST", "HIGH_OPT_IMP_VOLAT", "TOP_OPT_IMP_VOLAT_GAIN", "TOP_OPT_IMP_VOLAT_LOSE", "HIGH_OPT_VOLUME_PUT_CALL_RATIO", "LOW_OPT_VOLUME_PUT_CALL_RATIO", "OPT_VOLUME_MOST_ACTIVE", "HOT_BY_OPT_VOLUME", "HIGH_OPT_OPEN_INTEREST_PUT_CALL_RATIO", "LOW_OPT_OPEN_INTEREST_PUT_CALL_RATIO", "TOP_PERC_GAIN", "MOST_ACTIVE", "TOP_PERC_LOSE", "HOT_BY_VOLUME", "TOP_PERC_GAIN", "HOT_BY_PRICE", "TOP_TRADE_COUNT", "TOP_TRADE_RATE", "TOP_PRICE_RANGE", "HOT_BY_PRICE_RANGE", "TOP_VOLUME_RATE", "LOW_OPT_IMP_VOLAT", "OPT_OPEN_INTEREST_MOST_ACTIVE", "NOT_OPEN", "HALTED", "TOP_OPEN_PERC_GAIN", "TOP_OPEN_PERC_LOSE", "HIGH_OPEN_GAP", "LOW_OPEN_GAP", "LOW_OPT_IMP_VOLAT", "TOP_OPT_IMP_VOLAT_GAIN", "TOP_OPT_IMP_VOLAT_LOSE", "HIGH_VS_13W_HL", "LOW_VS_13W_HL", "HIGH_VS_26W_HL", "LOW_VS_26W_HL", "HIGH_VS_52W_HL", "LOW_VS_52W_HL", "HIGH_SYNTH_BID_REV_NAT_YIELD", "LOW_SYNTH_BID_REV_NAT_YIELD" });
            scanCode.Location = new Point(88, 22);
            scanCode.Margin = new Padding(4, 3, 4, 3);
            scanCode.Name = "scanCode";
            scanCode.Size = new Size(208, 23);
            scanCode.TabIndex = 0;
            scanCode.Text = "TOP_PERC_GAIN";
            // 
            // scanInstrument
            // 
            scanInstrument.FormattingEnabled = true;
            scanInstrument.Items.AddRange(new object[] { "STK", "STOCK.HK", "STOCK.EU" });
            scanInstrument.Location = new Point(88, 53);
            scanInstrument.Margin = new Padding(4, 3, 4, 3);
            scanInstrument.Name = "scanInstrument";
            scanInstrument.Size = new Size(140, 23);
            scanInstrument.TabIndex = 1;
            scanInstrument.Text = "STOCK.EU";
            // 
            // scannerRequest_Button
            // 
            scannerRequest_Button.Location = new Point(211, 148);
            scannerRequest_Button.Margin = new Padding(4, 3, 4, 3);
            scannerRequest_Button.Name = "scannerRequest_Button";
            scannerRequest_Button.Size = new Size(89, 24);
            scannerRequest_Button.TabIndex = 10;
            scannerRequest_Button.Text = "Submit";
            scannerRequest_Button.UseVisualStyleBackColor = true;
            scannerRequest_Button.Click += scannerRequest_Button_Click;
            // 
            // scanLocation
            // 
            scanLocation.FormattingEnabled = true;
            scanLocation.Items.AddRange(new object[] { "STK.US", "STK.US.MAJOR", "STK.US.MINOR", "STK.HK.SEHK", "STK.HK.ASX", "STK.EU" });
            scanLocation.Location = new Point(88, 117);
            scanLocation.Margin = new Padding(4, 3, 4, 3);
            scanLocation.Name = "scanLocation";
            scanLocation.Size = new Size(140, 23);
            scanLocation.TabIndex = 11;
            scanLocation.Text = "STK.EU.IBIS";
            // 
            // scanStockType
            // 
            scanStockType.FormattingEnabled = true;
            scanStockType.Location = new Point(88, 85);
            scanStockType.Margin = new Padding(4, 3, 4, 3);
            scanStockType.Name = "scanStockType";
            scanStockType.Size = new Size(140, 23);
            scanStockType.TabIndex = 3;
            scanStockType.Text = "ALL";
            // 
            // scanNumRows
            // 
            scanNumRows.Location = new Point(88, 148);
            scanNumRows.Margin = new Padding(4, 3, 4, 3);
            scanNumRows.Name = "scanNumRows";
            scanNumRows.Size = new Size(116, 23);
            scanNumRows.TabIndex = 4;
            scanNumRows.Text = "15";
            // 
            // scanNumRows_label
            // 
            scanNumRows_label.AutoSize = true;
            scanNumRows_label.Location = new Point(12, 148);
            scanNumRows_label.Margin = new Padding(4, 0, 4, 0);
            scanNumRows_label.Name = "scanNumRows_label";
            scanNumRows_label.Size = new Size(65, 15);
            scanNumRows_label.TabIndex = 9;
            scanNumRows_label.Text = "Num Rows";
            // 
            // scanCode_label
            // 
            scanCode_label.AutoSize = true;
            scanCode_label.Location = new Point(10, 22);
            scanCode_label.Margin = new Padding(4, 0, 4, 0);
            scanCode_label.Name = "scanCode_label";
            scanCode_label.Size = new Size(63, 15);
            scanCode_label.TabIndex = 5;
            scanCode_label.Text = "Scan Code";
            // 
            // scanStockType_label
            // 
            scanStockType_label.AutoSize = true;
            scanStockType_label.Location = new Point(8, 85);
            scanStockType_label.Margin = new Padding(4, 0, 4, 0);
            scanStockType_label.Name = "scanStockType_label";
            scanStockType_label.Size = new Size(63, 15);
            scanStockType_label.TabIndex = 8;
            scanStockType_label.Text = "Stock Type";
            // 
            // scanInstrument_label
            // 
            scanInstrument_label.AutoSize = true;
            scanInstrument_label.Location = new Point(15, 53);
            scanInstrument_label.Margin = new Padding(4, 0, 4, 0);
            scanInstrument_label.Name = "scanInstrument_label";
            scanInstrument_label.Size = new Size(65, 15);
            scanInstrument_label.TabIndex = 6;
            scanInstrument_label.Text = "Instrument";
            // 
            // scanLocation_label
            // 
            scanLocation_label.AutoSize = true;
            scanLocation_label.Location = new Point(24, 117);
            scanLocation_label.Margin = new Padding(4, 0, 4, 0);
            scanLocation_label.Name = "scanLocation_label";
            scanLocation_label.Size = new Size(53, 15);
            scanLocation_label.TabIndex = 7;
            scanLocation_label.Text = "Location";
            // 
            // scannerParamsRequest_button
            // 
            scannerParamsRequest_button.Location = new Point(322, 17);
            scannerParamsRequest_button.Margin = new Padding(4, 3, 4, 3);
            scannerParamsRequest_button.Name = "scannerParamsRequest_button";
            scannerParamsRequest_button.Size = new Size(140, 27);
            scannerParamsRequest_button.TabIndex = 12;
            scannerParamsRequest_button.Text = "Request Parameters";
            scannerParamsRequest_button.UseVisualStyleBackColor = true;
            scannerParamsRequest_button.Click += scannerParamsRequest_button_Click;
            // 
            // historicalTicks_MDT
            // 
            historicalTicks_MDT.BackColor = Color.LightGray;
            historicalTicks_MDT.Controls.Add(groupBoxTickByTickType);
            historicalTicks_MDT.Controls.Add(groupBox7);
            historicalTicks_MDT.Location = new Point(4, 24);
            historicalTicks_MDT.Margin = new Padding(2);
            historicalTicks_MDT.Name = "historicalTicks_MDT";
            historicalTicks_MDT.Size = new Size(1436, 233);
            historicalTicks_MDT.TabIndex = 5;
            historicalTicks_MDT.Text = "Historical ticks + Tick-by-tick";
            // 
            // groupBoxTickByTickType
            // 
            groupBoxTickByTickType.Controls.Add(buttonCancelTickByTick);
            groupBoxTickByTickType.Controls.Add(buttonRequestTickByTick);
            groupBoxTickByTickType.Controls.Add(comboBoxTickByTickType);
            groupBoxTickByTickType.Location = new Point(971, 13);
            groupBoxTickByTickType.Margin = new Padding(4, 3, 4, 3);
            groupBoxTickByTickType.Name = "groupBoxTickByTickType";
            groupBoxTickByTickType.Padding = new Padding(4, 3, 4, 3);
            groupBoxTickByTickType.Size = new Size(159, 85);
            groupBoxTickByTickType.TabIndex = 61;
            groupBoxTickByTickType.TabStop = false;
            groupBoxTickByTickType.Text = "Tick-By-Tick Type";
            // 
            // buttonCancelTickByTick
            // 
            buttonCancelTickByTick.Location = new Point(88, 51);
            buttonCancelTickByTick.Margin = new Padding(4, 3, 4, 3);
            buttonCancelTickByTick.Name = "buttonCancelTickByTick";
            buttonCancelTickByTick.Size = new Size(61, 27);
            buttonCancelTickByTick.TabIndex = 67;
            buttonCancelTickByTick.Text = "Cancel";
            buttonCancelTickByTick.UseVisualStyleBackColor = true;
            buttonCancelTickByTick.Click += buttonCancelTickByTick_Click;
            // 
            // buttonRequestTickByTick
            // 
            buttonRequestTickByTick.Location = new Point(16, 51);
            buttonRequestTickByTick.Margin = new Padding(4, 3, 4, 3);
            buttonRequestTickByTick.Name = "buttonRequestTickByTick";
            buttonRequestTickByTick.Size = new Size(64, 27);
            buttonRequestTickByTick.TabIndex = 66;
            buttonRequestTickByTick.Text = "Request";
            buttonRequestTickByTick.UseVisualStyleBackColor = true;
            buttonRequestTickByTick.Click += buttonRequestTickByTick_Click;
            // 
            // comboBoxTickByTickType
            // 
            comboBoxTickByTickType.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxTickByTickType.FormattingEnabled = true;
            comboBoxTickByTickType.Items.AddRange(new object[] { "Last", "AllLast", "BidAsk", "MidPoint" });
            comboBoxTickByTickType.Location = new Point(15, 18);
            comboBoxTickByTickType.Margin = new Padding(4, 3, 4, 3);
            comboBoxTickByTickType.Name = "comboBoxTickByTickType";
            comboBoxTickByTickType.Size = new Size(132, 23);
            comboBoxTickByTickType.TabIndex = 34;
            // 
            // groupBox7
            // 
            groupBox7.Controls.Add(btnRequestHistoricalTicks);
            groupBox7.Controls.Add(label21);
            groupBox7.Controls.Add(label20);
            groupBox7.Controls.Add(label19);
            groupBox7.Controls.Add(label18);
            groupBox7.Controls.Add(cbWhatToShow);
            groupBox7.Controls.Add(cbRthOnly);
            groupBox7.Controls.Add(cbIgnoreSize);
            groupBox7.Controls.Add(tbEndDate);
            groupBox7.Controls.Add(tbNumOfTicks);
            groupBox7.Controls.Add(tbStartDate);
            groupBox7.Location = new Point(482, 2);
            groupBox7.Margin = new Padding(2);
            groupBox7.Name = "groupBox7";
            groupBox7.Padding = new Padding(2);
            groupBox7.Size = new Size(483, 212);
            groupBox7.TabIndex = 0;
            groupBox7.TabStop = false;
            groupBox7.Text = "Historical ticks request";
            // 
            // btnRequestHistoricalTicks
            // 
            btnRequestHistoricalTicks.Location = new Point(412, 186);
            btnRequestHistoricalTicks.Margin = new Padding(2);
            btnRequestHistoricalTicks.Name = "btnRequestHistoricalTicks";
            btnRequestHistoricalTicks.Size = new Size(65, 22);
            btnRequestHistoricalTicks.TabIndex = 58;
            btnRequestHistoricalTicks.Text = "Request";
            btnRequestHistoricalTicks.UseVisualStyleBackColor = true;
            btnRequestHistoricalTicks.Click += btnRequestHistoricalTicks_Click;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(2, 23);
            label21.Margin = new Padding(2, 0, 2, 0);
            label21.Name = "label21";
            label21.Size = new Size(34, 15);
            label21.TabIndex = 57;
            label21.Text = "Start:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(2, 48);
            label20.Margin = new Padding(2, 0, 2, 0);
            label20.Name = "label20";
            label20.Size = new Size(30, 15);
            label20.TabIndex = 56;
            label20.Text = "End:";
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(2, 75);
            label19.Margin = new Padding(2, 0, 2, 0);
            label19.Name = "label19";
            label19.Size = new Size(95, 15);
            label19.TabIndex = 55;
            label19.Text = "Number of ticks:";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(2, 100);
            label18.Margin = new Padding(2, 0, 2, 0);
            label18.Name = "label18";
            label18.Size = new Size(39, 15);
            label18.TabIndex = 54;
            label18.Text = "Show:";
            // 
            // cbWhatToShow
            // 
            cbWhatToShow.Font = new Font("Microsoft Sans Serif", 6.75F, FontStyle.Regular, GraphicsUnit.Point);
            cbWhatToShow.FormattingEnabled = true;
            cbWhatToShow.Items.AddRange(new object[] { "TRADES", "MIDPOINT", "BID", "ASK", "BID_ASK", "HISTORICAL_VOLATILITY", "OPTION_IMPLIED_VOLATILITY", "YIELD_BID", "YIELD_ASK", "YIELD_BID_ASK", "YIELD_LAST" });
            cbWhatToShow.Location = new Point(103, 99);
            cbWhatToShow.Margin = new Padding(4, 3, 4, 3);
            cbWhatToShow.Name = "cbWhatToShow";
            cbWhatToShow.Size = new Size(181, 20);
            cbWhatToShow.TabIndex = 53;
            cbWhatToShow.Text = "TRADES";
            // 
            // cbRthOnly
            // 
            cbRthOnly.AutoSize = true;
            cbRthOnly.Location = new Point(391, 21);
            cbRthOnly.Margin = new Padding(2);
            cbRthOnly.Name = "cbRthOnly";
            cbRthOnly.Size = new Size(75, 19);
            cbRthOnly.TabIndex = 5;
            cbRthOnly.Text = "RTH Only";
            cbRthOnly.UseVisualStyleBackColor = true;
            // 
            // cbIgnoreSize
            // 
            cbIgnoreSize.AutoSize = true;
            cbIgnoreSize.Location = new Point(391, 48);
            cbIgnoreSize.Margin = new Padding(2);
            cbIgnoreSize.Name = "cbIgnoreSize";
            cbIgnoreSize.Size = new Size(82, 19);
            cbIgnoreSize.TabIndex = 4;
            cbIgnoreSize.Text = "Ignore size";
            cbIgnoreSize.UseVisualStyleBackColor = true;
            // 
            // tbEndDate
            // 
            tbEndDate.Location = new Point(103, 46);
            tbEndDate.Margin = new Padding(2);
            tbEndDate.Name = "tbEndDate";
            tbEndDate.Size = new Size(182, 23);
            tbEndDate.TabIndex = 2;
            tbEndDate.Text = "20220808 23:59:59 US/Eastern";
            // 
            // tbNumOfTicks
            // 
            tbNumOfTicks.Location = new Point(103, 73);
            tbNumOfTicks.Margin = new Padding(2);
            tbNumOfTicks.Name = "tbNumOfTicks";
            tbNumOfTicks.Size = new Size(182, 23);
            tbNumOfTicks.TabIndex = 1;
            tbNumOfTicks.Text = "1";
            tbNumOfTicks.TextAlign = HorizontalAlignment.Right;
            // 
            // tbStartDate
            // 
            tbStartDate.Location = new Point(103, 20);
            tbStartDate.Margin = new Padding(2);
            tbStartDate.Name = "tbStartDate";
            tbStartDate.Size = new Size(182, 23);
            tbStartDate.TabIndex = 0;
            tbStartDate.Text = "20220808 23:59:59 US/Eastern";
            // 
            // TabControl
            // 
            TabControl.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TabControl.Controls.Add(marketDataTab);
            TabControl.Controls.Add(tradingTab);
            TabControl.Controls.Add(accountInfoTab);
            TabControl.Controls.Add(tabPage1);
            TabControl.Controls.Add(advisorTab);
            TabControl.Controls.Add(optionsTab);
            TabControl.Controls.Add(acctPosTab);
            TabControl.Controls.Add(newsTab);
            TabControl.Controls.Add(wshTab);
            TabControl.Location = new Point(0, 78);
            TabControl.Margin = new Padding(4, 3, 4, 3);
            TabControl.Name = "TabControl";
            TabControl.SelectedIndex = 0;
            TabControl.Size = new Size(1465, 547);
            TabControl.TabIndex = 7;
            // 
            // wshTab
            // 
            wshTab.Controls.Add(textBoxWshTotalLimit);
            wshTab.Controls.Add(labelWshTotalLimit);
            wshTab.Controls.Add(textBoxWshEndDate);
            wshTab.Controls.Add(labelWshEndDate);
            wshTab.Controls.Add(textBoxWshStartDate);
            wshTab.Controls.Add(labelWshStartDate);
            wshTab.Controls.Add(checkBoxWshFillCompetitors);
            wshTab.Controls.Add(checkBoxWshFillPortfolio);
            wshTab.Controls.Add(checkBoxWshFillWatchlist);
            wshTab.Controls.Add(textBoxWshFilter);
            wshTab.Controls.Add(labelWshFilter);
            wshTab.Controls.Add(button3);
            wshTab.Controls.Add(button4);
            wshTab.Controls.Add(button5);
            wshTab.Controls.Add(textBoxWshConId);
            wshTab.Controls.Add(labelWshConId);
            wshTab.Controls.Add(button6);
            wshTab.Controls.Add(dataGridViewWsh);
            wshTab.Location = new Point(4, 24);
            wshTab.Margin = new Padding(4, 3, 4, 3);
            wshTab.Name = "wshTab";
            wshTab.Size = new Size(1457, 519);
            wshTab.TabIndex = 10;
            wshTab.Text = "WSHE Calendar";
            wshTab.UseVisualStyleBackColor = true;
            // 
            // textBoxWshTotalLimit
            // 
            textBoxWshTotalLimit.Location = new Point(846, 245);
            textBoxWshTotalLimit.Margin = new Padding(4, 3, 4, 3);
            textBoxWshTotalLimit.Name = "textBoxWshTotalLimit";
            textBoxWshTotalLimit.Size = new Size(116, 23);
            textBoxWshTotalLimit.TabIndex = 31;
            // 
            // labelWshTotalLimit
            // 
            labelWshTotalLimit.AutoSize = true;
            labelWshTotalLimit.Location = new Point(705, 248);
            labelWshTotalLimit.Margin = new Padding(4, 0, 4, 0);
            labelWshTotalLimit.Name = "labelWshTotalLimit";
            labelWshTotalLimit.Size = new Size(62, 15);
            labelWshTotalLimit.TabIndex = 30;
            labelWshTotalLimit.Text = "Total Limit";
            // 
            // textBoxWshEndDate
            // 
            textBoxWshEndDate.Location = new Point(846, 215);
            textBoxWshEndDate.Margin = new Padding(4, 3, 4, 3);
            textBoxWshEndDate.Name = "textBoxWshEndDate";
            textBoxWshEndDate.Size = new Size(116, 23);
            textBoxWshEndDate.TabIndex = 29;
            // 
            // labelWshEndDate
            // 
            labelWshEndDate.AutoSize = true;
            labelWshEndDate.Location = new Point(705, 223);
            labelWshEndDate.Margin = new Padding(4, 0, 4, 0);
            labelWshEndDate.Name = "labelWshEndDate";
            labelWshEndDate.Size = new Size(54, 15);
            labelWshEndDate.TabIndex = 28;
            labelWshEndDate.Text = "End Date";
            // 
            // textBoxWshStartDate
            // 
            textBoxWshStartDate.Location = new Point(846, 185);
            textBoxWshStartDate.Margin = new Padding(4, 3, 4, 3);
            textBoxWshStartDate.Name = "textBoxWshStartDate";
            textBoxWshStartDate.Size = new Size(116, 23);
            textBoxWshStartDate.TabIndex = 27;
            // 
            // labelWshStartDate
            // 
            labelWshStartDate.AutoSize = true;
            labelWshStartDate.Location = new Point(705, 193);
            labelWshStartDate.Margin = new Padding(4, 0, 4, 0);
            labelWshStartDate.Name = "labelWshStartDate";
            labelWshStartDate.Size = new Size(58, 15);
            labelWshStartDate.TabIndex = 26;
            labelWshStartDate.Text = "Start Date";
            // 
            // checkBoxWshFillCompetitors
            // 
            checkBoxWshFillCompetitors.AutoSize = true;
            checkBoxWshFillCompetitors.Location = new Point(846, 158);
            checkBoxWshFillCompetitors.Margin = new Padding(4, 3, 4, 3);
            checkBoxWshFillCompetitors.Name = "checkBoxWshFillCompetitors";
            checkBoxWshFillCompetitors.Size = new Size(110, 19);
            checkBoxWshFillCompetitors.TabIndex = 25;
            checkBoxWshFillCompetitors.Text = "Fill Competitors";
            checkBoxWshFillCompetitors.UseVisualStyleBackColor = true;
            // 
            // checkBoxWshFillPortfolio
            // 
            checkBoxWshFillPortfolio.AutoSize = true;
            checkBoxWshFillPortfolio.Location = new Point(846, 132);
            checkBoxWshFillPortfolio.Margin = new Padding(4, 3, 4, 3);
            checkBoxWshFillPortfolio.Name = "checkBoxWshFillPortfolio";
            checkBoxWshFillPortfolio.Size = new Size(90, 19);
            checkBoxWshFillPortfolio.TabIndex = 24;
            checkBoxWshFillPortfolio.Text = "Fill Portfolio";
            checkBoxWshFillPortfolio.UseVisualStyleBackColor = true;
            // 
            // checkBoxWshFillWatchlist
            // 
            checkBoxWshFillWatchlist.AutoSize = true;
            checkBoxWshFillWatchlist.Location = new Point(846, 105);
            checkBoxWshFillWatchlist.Margin = new Padding(4, 3, 4, 3);
            checkBoxWshFillWatchlist.Name = "checkBoxWshFillWatchlist";
            checkBoxWshFillWatchlist.Size = new Size(93, 19);
            checkBoxWshFillWatchlist.TabIndex = 23;
            checkBoxWshFillWatchlist.Text = "Fill Watchlist";
            checkBoxWshFillWatchlist.UseVisualStyleBackColor = true;
            // 
            // textBoxWshFilter
            // 
            textBoxWshFilter.Location = new Point(846, 66);
            textBoxWshFilter.Margin = new Padding(4, 3, 4, 3);
            textBoxWshFilter.Name = "textBoxWshFilter";
            textBoxWshFilter.Size = new Size(116, 23);
            textBoxWshFilter.TabIndex = 19;
            // 
            // labelWshFilter
            // 
            labelWshFilter.AutoSize = true;
            labelWshFilter.Location = new Point(705, 74);
            labelWshFilter.Margin = new Padding(4, 0, 4, 0);
            labelWshFilter.Name = "labelWshFilter";
            labelWshFilter.Size = new Size(33, 15);
            labelWshFilter.TabIndex = 18;
            labelWshFilter.Text = "Filter";
            // 
            // button3
            // 
            button3.Location = new Point(1153, 33);
            button3.Margin = new Padding(4, 3, 4, 3);
            button3.Name = "button3";
            button3.Size = new Size(176, 27);
            button3.TabIndex = 17;
            button3.Text = "Cancel WSH Event Data";
            button3.UseVisualStyleBackColor = true;
            button3.Click += buttonCancelWshEventData_Click;
            // 
            // button4
            // 
            button4.Location = new Point(1153, 3);
            button4.Margin = new Padding(4, 3, 4, 3);
            button4.Name = "button4";
            button4.Size = new Size(176, 27);
            button4.TabIndex = 16;
            button4.Text = "Cancel WSH Meta Data";
            button4.UseVisualStyleBackColor = true;
            button4.Click += buttonCancelWshMetaData_Click;
            // 
            // button5
            // 
            button5.Location = new Point(969, 33);
            button5.Margin = new Padding(4, 3, 4, 3);
            button5.Name = "button5";
            button5.Size = new Size(176, 27);
            button5.TabIndex = 15;
            button5.Text = "Request WSH Event Data";
            button5.UseVisualStyleBackColor = true;
            button5.Click += buttonRequestWshEventData_Click;
            // 
            // textBoxWshConId
            // 
            textBoxWshConId.Location = new Point(846, 36);
            textBoxWshConId.Margin = new Padding(4, 3, 4, 3);
            textBoxWshConId.Name = "textBoxWshConId";
            textBoxWshConId.Size = new Size(116, 23);
            textBoxWshConId.TabIndex = 14;
            textBoxWshConId.Text = "0";
            // 
            // labelWshConId
            // 
            labelWshConId.AutoSize = true;
            labelWshConId.Location = new Point(705, 39);
            labelWshConId.Margin = new Padding(4, 0, 4, 0);
            labelWshConId.Name = "labelWshConId";
            labelWshConId.Size = new Size(42, 15);
            labelWshConId.TabIndex = 13;
            labelWshConId.Text = "Con Id";
            // 
            // button6
            // 
            button6.Location = new Point(969, 3);
            button6.Margin = new Padding(4, 3, 4, 3);
            button6.Name = "button6";
            button6.Size = new Size(176, 27);
            button6.TabIndex = 10;
            button6.Text = "Request WSH Meta Data";
            button6.UseVisualStyleBackColor = true;
            button6.Click += buttonRequestWshMetaData_Click;
            // 
            // dataGridViewWsh
            // 
            dataGridViewWsh.AllowUserToAddRows = false;
            dataGridViewWsh.AllowUserToDeleteRows = false;
            dataGridViewWsh.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewWsh.Location = new Point(10, 3);
            dataGridViewWsh.Margin = new Padding(4, 3, 4, 3);
            dataGridViewWsh.Name = "dataGridViewWsh";
            dataGridViewWsh.ReadOnly = true;
            dataGridViewWsh.Size = new Size(692, 510);
            dataGridViewWsh.TabIndex = 9;
            // 
            // IBSampleAppDialog
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(1474, 854);
            Controls.Add(buttonAdditionalForm);
            Controls.Add(label7);
            Controls.Add(ib_banner);
            Controls.Add(connectButton);
            Controls.Add(tabControl2);
            Controls.Add(clientid_CT);
            Controls.Add(TabControl);
            Controls.Add(cliet_label_CT);
            Controls.Add(host_CT);
            Controls.Add(port_CT);
            Controls.Add(host_label_CT);
            Controls.Add(port_label_CT);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            Name = "IBSampleAppDialog";
            Text = "Interactive Brokers - Sample Application C# TWS API v. 9.72";
            comboTab.ResumeLayout(false);
            comboDeltaNeutralBox.ResumeLayout(false);
            comboDeltaNeutralBox.PerformLayout();
            comboLegsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            comboContractBox.ResumeLayout(false);
            comboContractBox.PerformLayout();
            tabControl2.ResumeLayout(false);
            messagesTab.ResumeLayout(false);
            messagesTab.PerformLayout();
            groupBox3.ResumeLayout(false);
            groupBox3.PerformLayout();
            groupBox5.ResumeLayout(false);
            groupBox5.PerformLayout();
            groupBoxMarketRule.ResumeLayout(false);
            groupBoxMarketRule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ib_banner).EndInit();
            newsTab.ResumeLayout(false);
            tabControlNewsResults.ResumeLayout(false);
            tabPageTickNewsResults.ResumeLayout(false);
            tabPageTickNewsResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNewsTicks).EndInit();
            tabPageNewsProvidersResults.ResumeLayout(false);
            tabPageNewsProvidersResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewNewsProviders).EndInit();
            tabPageNewsArticleResults.ResumeLayout(false);
            tabPageNewsArticleResults.PerformLayout();
            tabPageHistoricalNewsResults.ResumeLayout(false);
            tabPageHistoricalNewsResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricalNews).EndInit();
            tabControlNews.ResumeLayout(false);
            tabPageTickNews.ResumeLayout(false);
            groupBoxNewsTicks.ResumeLayout(false);
            groupBoxNewsTicks.PerformLayout();
            tabPageNewsProviders.ResumeLayout(false);
            tabPageNewsArticle.ResumeLayout(false);
            groupBoxNewsArticle.ResumeLayout(false);
            groupBoxNewsArticle.PerformLayout();
            tabPageHistoricalNews.ResumeLayout(false);
            groupBoxHistoricalNews.ResumeLayout(false);
            groupBoxHistoricalNews.PerformLayout();
            acctPosTab.ResumeLayout(false);
            acctPosMultiPanel.ResumeLayout(false);
            tabPositionsMulti.ResumeLayout(false);
            tabPositionsMulti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)positionsMultiGrid).EndInit();
            tabAccountUpdatesMulti.ResumeLayout(false);
            tabAccountUpdatesMulti.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)accountUpdatesMultiGrid).EndInit();
            groupBoxRequestData.ResumeLayout(false);
            groupBoxRequestData.PerformLayout();
            optionsTab.ResumeLayout(false);
            optionsTab.PerformLayout();
            optionsPositionsGroupBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)optionPositionsGrid).EndInit();
            advisorTab.ResumeLayout(false);
            advisorProfilesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)advisorProfilesGrid).EndInit();
            advisorGroupsBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)advisorGroupsGrid).EndInit();
            advisorAliasesBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)advisorAliasesGrid).EndInit();
            tabPage1.ResumeLayout(false);
            groupBoxMarketDataType_CDT.ResumeLayout(false);
            contractFundamentalsGroupBox.ResumeLayout(false);
            contractFundamentalsGroupBox.PerformLayout();
            contractDetailsGroupBox.ResumeLayout(false);
            contractDetailsGroupBox.PerformLayout();
            contractInfoTab.ResumeLayout(false);
            contractDetailsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)contractDetailsGrid).EndInit();
            fundamentalsPage.ResumeLayout(false);
            fundamentalsPage.PerformLayout();
            optionChainPage.ResumeLayout(false);
            optionChainCallGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)optionChainCallGrid).EndInit();
            optionChainPutGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)optionChainPutGrid).EndInit();
            optionParametersPage.ResumeLayout(false);
            symbolSamplesTabContractInfo.ResumeLayout(false);
            symbolSamplesTabContractInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)symbolSamplesDataGridContractInfo).EndInit();
            bondContractDetailsPage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)bondContractDetailsGrid).EndInit();
            marketRulePage.ResumeLayout(false);
            marketRulePage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewMarketRule).EndInit();
            accountInfoTab.ResumeLayout(false);
            accountInfoTab.PerformLayout();
            tabControl1.ResumeLayout(false);
            accSummaryTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)accSummaryGrid).EndInit();
            accUpdatesTab.ResumeLayout(false);
            accUpdatesTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)accountPortfolioGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)accountValuesGrid).EndInit();
            positionsTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)positionsGrid).EndInit();
            familyCodesTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)familyCodesGrid).EndInit();
            pnlTab.ResumeLayout(false);
            pnlTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewPnL).EndInit();
            tradingTab.ResumeLayout(false);
            tradingTab.PerformLayout();
            completedOrdersGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)completedOrdersGrid).EndInit();
            execFilterGroup.ResumeLayout(false);
            execFilterGroup.PerformLayout();
            executionsGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)tradeLogGrid).EndInit();
            liveOrdersGroup.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)liveOrdersGrid).EndInit();
            marketDataTab.ResumeLayout(false);
            marketData_MDT.ResumeLayout(false);
            topMarketDataTab_MDT.ResumeLayout(false);
            topMarketDataTab_MDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)marketDataGrid_MDT).EndInit();
            deepBookTab_MDT.ResumeLayout(false);
            deepBookTab_MDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)deepBookGrid).EndInit();
            historicalDataTab.ResumeLayout(false);
            historicalDataTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)barsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)historicalChart).EndInit();
            rtBarsTab_MDT.ResumeLayout(false);
            rtBarsTab_MDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)rtBarsGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)rtBarsChart).EndInit();
            scannerTab.ResumeLayout(false);
            scannerTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)scannerGrid).EndInit();
            scannerParamsTab.ResumeLayout(false);
            scannerParamsTab.PerformLayout();
            mktDepthExchanges_MDT.ResumeLayout(false);
            mktDepthExchanges_MDT.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)mktDepthExchangesGrid_MDT).EndInit();
            symbolSamplesTabData.ResumeLayout(false);
            symbolSamplesTabData.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)symbolSamplesDataGridData).EndInit();
            smartComponentsTabPage.ResumeLayout(false);
            smartComponentsTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewSmartComponents).EndInit();
            headTimestampTabPage.ResumeLayout(false);
            headTimestampTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)headTimestampDataGridView).EndInit();
            histogramTabPage.ResumeLayout(false);
            histogramTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)histogramDataGridView).EndInit();
            historicalTicksTabPage.ResumeLayout(false);
            historicalTicksTabPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewHistoricalTicks).EndInit();
            tabPageTickByTick.ResumeLayout(false);
            tabPageTickByTick.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewTickByTick).EndInit();
            tabHistoricalSchedule.ResumeLayout(false);
            tabHistoricalSchedule.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)historicalScheduleGrid).EndInit();
            dataResults_MDT.ResumeLayout(false);
            topMktData_MDT.ResumeLayout(false);
            groupBox6.ResumeLayout(false);
            groupBox6.PerformLayout();
            groupBoxMarketDataType_MDT.ResumeLayout(false);
            deepBookGroupBox.ResumeLayout(false);
            deepBookGroupBox.PerformLayout();
            groupBox2.ResumeLayout(false);
            groupBox2.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            marketScanner_MDT.ResumeLayout(false);
            groupBox8.ResumeLayout(false);
            groupBox8.PerformLayout();
            groupBox4.ResumeLayout(false);
            groupBox4.PerformLayout();
            historicalTicks_MDT.ResumeLayout(false);
            groupBoxTickByTickType.ResumeLayout(false);
            groupBox7.ResumeLayout(false);
            groupBox7.PerformLayout();
            TabControl.ResumeLayout(false);
            wshTab.ResumeLayout(false);
            wshTab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridViewWsh).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label cliet_label_CT;
        private TextBox port_CT;
        private Label port_label_CT;
        private Label host_label_CT;
        private TextBox host_CT;
        private TabControl tabControl2;
        private TabPage messagesTab;
        private TextBox clientid_CT;
        private Label status_label_CT;
        private Label status_CT;
        private Button connectButton;
        private TextBox messageBox;
        private LinkLabel messageBoxClear_link;// = new System.Windows.Forms.DataGridViewComboBoxColumn();
        private TabPage comboTab;
        private Label comboSymbolLabel;
        private Label comboRightLabel;
        private Label comboStrikeLabel;
        private ComboBox comboRight;
        private Label comboLastTradeDateLabel;
        private ComboBox comboSecType;
        private Label comboMultiplierLabel;
        private Label comboSecTypeLabel;
        private Label comboLocalSymbolLabel;
        private Label comboExchangeLabel;
        private TextBox comboExchange;
        private TextBox comboLocalSymbol;
        private TextBox comboMultiplier;
        private Label comboCurrencyLabel;
        private TextBox comboCurrency;
        private TextBox comboLastTradeDate;
        private TextBox comboStrike;
        private TextBox comboSymbol;
        private GroupBox comboContractBox;
        private GroupBox comboLegsBox;
        private DataGridView dataGridView1;
        private GroupBox comboDeltaNeutralBox;
        private Button comboDeltaNeutralSet;
        private Label label2;
        private Label label5;
        private TextBox textBox1;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox4;
        private TextBox textBox3;
        private ComboBox comboBox1;
        private Label label3;
        private Label label4;
        private LinkLabel findComboContract;
        private Button button2;
        private DataGridViewComboBoxColumn comboLegAction;
        private DataGridViewTextBoxColumn comboLegRatio;
        private DataGridViewTextBoxColumn comboLegDescription;
        private DataGridViewTextBoxColumn comboLegPrice;
        private ToolTip informationTooltip;
        private PictureBox ib_banner;
        private Label label7;
        private TabPage newsTab;
        private TabControl tabControlNewsResults;
        private TabPage tabPageTickNewsResults;
        private DataGridView dataGridViewNewsTicks;
        private DataGridViewTextBoxColumn dataGridViewNewsTicksTimeStamp;
        private DataGridViewTextBoxColumn dataGridViewNewsTicksProviderCode;
        private DataGridViewTextBoxColumn dataGridViewNewsTicksArticleId;
        private DataGridViewTextBoxColumn dataGridViewHeadline;
        private DataGridViewTextBoxColumn dataGridViewNewsTicksExtraData;
        private LinkLabel linkLabelNewsTicksClear;
        private TabPage tabPageNewsProvidersResults;
        private DataGridView dataGridViewNewsProviders;
        private DataGridViewTextBoxColumn dataGridViewTextBoxNewsProvidersProviderCode;
        private DataGridViewTextBoxColumn dataGridViewTextBoxNewsProvidersProviderName;
        private LinkLabel linkLabelClearNewsProviders;
        private TabPage tabPageNewsArticleResults;
        private TextBox textBoxNewsArticle;
        private LinkLabel linkLabelClearNewsArticle;
        private TabPage tabPageHistoricalNewsResults;
        private LinkLabel linkLabelClearHistoricalNews;
        private DataGridView dataGridViewHistoricalNews;
        private DataGridViewTextBoxColumn dataGridViewTextBoxTime;
        private DataGridViewTextBoxColumn dataGridViewTextBoxProviderCode;
        private DataGridViewTextBoxColumn dataGridViewTextBoxArticleId;
        private DataGridViewTextBoxColumn dataGridViewTextBoxHeadline;
        private TabControl tabControlNews;
        private TabPage tabPageTickNews;
        private GroupBox groupBoxNewsTicks;
        private Button buttonCancelNewsTicks;
        private TextBox textBoxNewsTicksPrimExchange;
        private Label labelNewsTicksPrimExchange;
        private Button buttonReqNewsTicks;
        private Label labelNewsTicksSymbol;
        private ComboBox comboBoxNewsTicksSecType;
        private Label labelNewsTicksSecType;
        private Label labelNewsTicksExchange;
        private TextBox textBoxNewsTicksExchange;
        private Label labelNewsTicksCurrency;
        private TextBox textBoxNewsTicksCurrency;
        private TextBox textBoxNewsTicksSymbol;
        private TabPage tabPageNewsProviders;
        private Button buttonReqNewsProviders;
        private TabPage tabPageNewsArticle;
        private GroupBox groupBoxNewsArticle;
        private TextBox textBoxNewsArticleArticleId;
        private Button buttonRequestNewsArticle;
        private Label labelNewsArticleProviderCode;
        private Label labelNewsArticleArticleId;
        private TextBox textBoxNewsArticleProviderCode;
        private TabPage tabPageHistoricalNews;
        private GroupBox groupBoxHistoricalNews;
        private TextBox textBoxHistoricalNewsProviderCodes;
        private Button buttonRequestHistoricalNews;
        private Label labelHistoricalNewsConId;
        private Label labelHistoricalNewsProviderCodes;
        private Label labelHistoricalNewsEndDateTime;
        private TextBox textBoxHistoricalNewsTotalResults;
        private Label labelHistoricalNewsStartDateTime;
        private TextBox textBoxHistoricalNewsContractId;
        private TextBox textBoxHistoricalNewsStartDateTime;
        private TextBox textBoxHistoricalNewsEndDateTime;
        private Label labelHistoricalNewsTotalResults;
        private TabPage acctPosTab;
        private TabControl acctPosMultiPanel;
        private TabPage tabPositionsMulti;
        private LinkLabel clearPositionsMulti;
        private DataGridView positionsMultiGrid;
        private DataGridViewTextBoxColumn accountPositionsMulti;
        private DataGridViewTextBoxColumn modelCodePositionsMulti;
        private DataGridViewTextBoxColumn contractPositionsMulti;
        private DataGridViewTextBoxColumn positionPositionsMulti;
        private DataGridViewTextBoxColumn avgCostPositionsMulti;
        private TabPage tabAccountUpdatesMulti;
        private LinkLabel clearAccountUpdatesMulti;
        private DataGridView accountUpdatesMultiGrid;
        private DataGridViewTextBoxColumn accountAccountUpdatesMulti;
        private DataGridViewTextBoxColumn modelCodeAccountUpdatesMulti;
        private DataGridViewTextBoxColumn keyAccountUpdatesMulti;
        private DataGridViewTextBoxColumn valueAccountUpdatesMulti;
        private DataGridViewTextBoxColumn currencyAccountUpdatesMulti;
        private GroupBox groupBoxRequestData;
        private Button buttonCancelAccountUpdatesMulti;
        private Button buttonCancelPositionsMulti;
        private Button buttonRequestAccountUpdatesMulti;
        private CheckBox cbLedgerAndNLV;
        private Label labelAccount;
        private Button buttonRequestPositionsMulti;
        private Label labelModelCode;
        private TextBox textAccount;
        private TextBox textModelCode;
        private TabPage optionsTab;
        private TextBox optionExchange;
        private TextBox optionExerciseQuan;
        private Label optionExchangeLabel;
        private Label optionsQuantityLabel;
        private GroupBox optionsPositionsGroupBox;
        private DataGridView optionPositionsGrid;
        private DataGridViewTextBoxColumn optionContract;
        private DataGridViewTextBoxColumn optionAccount;
        private DataGridViewTextBoxColumn optionPosition;
        private DataGridViewTextBoxColumn optionMarketPrice;
        private DataGridViewTextBoxColumn optionMarketValue;
        private DataGridViewTextBoxColumn optionAverageCost;
        private DataGridViewTextBoxColumn optionUnrealizedPnL;
        private DataGridViewTextBoxColumn optionRealizedPnL;
        private CheckBox overrideOption;
        private Button lapseOption;
        private Button exerciseOption;
        private Label exerciseAccountLabel;
        private ComboBox exerciseAccount;
        private TabPage advisorTab;
        private GroupBox advisorProfilesBox;
        private Button saveProfiles;
        private Button loadProfiles;
        private DataGridView advisorProfilesGrid;
        private DataGridViewTextBoxColumn profileName;
        private DataGridViewComboBoxColumn profileType;
        private DataGridViewTextBoxColumn profileAllocations;
        private GroupBox advisorGroupsBox;
        private Button saveGroups;
        private Button loadGroups;
        private DataGridView advisorGroupsGrid;
        private DataGridViewTextBoxColumn groupName;
        private DataGridViewComboBoxColumn groupMethod;
        private DataGridViewTextBoxColumn groupAccounts;
        private GroupBox advisorAliasesBox;
        private Button loadAliases;
        private DataGridView advisorAliasesGrid;
        private DataGridViewTextBoxColumn advisorAccount;
        private DataGridViewTextBoxColumn advisorAlias;
        private TabPage tabPage1;
        private GroupBox groupBoxMarketDataType_CDT;
        private ComboBox comboBoxMarketDataType_CDT;
        private GroupBox groupBox5;
        private Label label14;
        private TextBox underlyingConId;
        private Button queryOptionParams;
        private GroupBox groupBox3;
        private Button queryOptionChain;
        private CheckBox optionChainUseSnapshot;
        private Label optionChainOptionExchangeLabel;
        private TextBox optionChainExchange;
        private GroupBox contractFundamentalsGroupBox;
        private Button fundamentalsQueryButton;
        private Label fundamentalsReportTypeLabel;
        private ComboBox fundamentalsReportType;
        private GroupBox contractDetailsGroupBox;
        private Button requestMatchingSymbolsCD;
        private Button searchContractDetails;
        private Label conDetSymbolLabel;
        private Label conDetRightLabel;
        private Label conDetStrikeLabel;
        private ComboBox conDetRight;
        private Label conDetLastTradeDateLabel;
        private ComboBox conDetSecType;
        private Label conDetMultiplierLabel;
        private Label conDetSecTypeLabel;
        private Label conDetLocalSymbolLabel;
        private Label conDetExchangeLabel;
        private TextBox conDetExchange;
        private TextBox conDetLocalSymbol;
        private TextBox conDetMultiplier;
        private Label conDetCurrencyLabel;
        private TextBox conDetCurrency;
        private TextBox conDetLastTradeDateOrContractMonth;
        private TextBox conDetStrike;
        private TextBox conDetSymbol;
        private TabControl contractInfoTab;
        private TabPage contractDetailsPage;
        private DataGridView contractDetailsGrid;
        private TabPage fundamentalsPage;
        private TextBox fundamentalsOutput;
        private TabPage optionChainPage;
        private GroupBox optionChainCallGroup;
        private DataGridView optionChainCallGrid;
        private DataGridViewTextBoxColumn callLastTradeDate;
        private DataGridViewTextBoxColumn callStrike;
        private DataGridViewTextBoxColumn callBid;
        private DataGridViewTextBoxColumn callAsk;
        private DataGridViewTextBoxColumn callImpliedVolatility;
        private DataGridViewTextBoxColumn callDelta;
        private DataGridViewTextBoxColumn callGamma;
        private DataGridViewTextBoxColumn callVega;
        private DataGridViewTextBoxColumn callTheta;
        private GroupBox optionChainPutGroup;
        private DataGridView optionChainPutGrid;
        private DataGridViewTextBoxColumn putLastTradeDate;
        private DataGridViewTextBoxColumn putStrike;
        private DataGridViewTextBoxColumn putBid;
        private DataGridViewTextBoxColumn putAsk;
        private DataGridViewTextBoxColumn putImpliedVolatility;
        private DataGridViewTextBoxColumn putDelta;
        private DataGridViewTextBoxColumn putGamma;
        private DataGridViewTextBoxColumn putVega;
        private DataGridViewTextBoxColumn putTheta;
        private TabPage optionParametersPage;
        private ListView listViewOptionParams;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private TabPage symbolSamplesTabContractInfo;
        private LinkLabel clearSymbolSamplesContractInfo;
        private DataGridView symbolSamplesDataGridContractInfo;
        private TabPage bondContractDetailsPage;
        private DataGridView bondContractDetailsGrid;
        private TabPage accountInfoTab;
        private TabControl tabControl1;
        private TabPage accSummaryTab;
        private Button accSummaryRequest;
        private DataGridView accSummaryGrid;
        private DataGridViewTextBoxColumn tag;
        private DataGridViewTextBoxColumn value;
        private DataGridViewTextBoxColumn currency;
        private DataGridViewTextBoxColumn accountSummaryAccount;
        private TabPage accUpdatesTab;
        private Label accUpdatesSubscribedAccount;
        private Label accUpdatesAccountLabel;
        private Label accUpdatesLastUpdateValue;
        private DataGridView accountPortfolioGrid;
        private DataGridViewTextBoxColumn updatePortfolioContract;
        private DataGridViewTextBoxColumn updatePortfolioPosition;
        private DataGridViewTextBoxColumn updatePortfolioMarketPrice;
        private DataGridViewTextBoxColumn updatePortfolioMarketValue;
        private DataGridViewTextBoxColumn updatePortfolioAvgCost;
        private DataGridViewTextBoxColumn updatePortfolioUnrealizedPnL;
        private DataGridViewTextBoxColumn updatePortfolioRealizedPnL;
        private DataGridView accountValuesGrid;
        private DataGridViewTextBoxColumn accUpdatesKey;
        private DataGridViewTextBoxColumn accUpdatesValue;
        private DataGridViewTextBoxColumn accUpdatesCurrency;
        private Button accUpdatesSubscribe;
        private Label lastUpdatedLabel;
        private TabPage positionsTab;
        private Button positionRequest;
        private DataGridView positionsGrid;
        private DataGridViewTextBoxColumn positionContract;
        private DataGridViewTextBoxColumn positionAccount;
        private DataGridViewTextBoxColumn positionPosition;
        private DataGridViewTextBoxColumn positionAvgCost;
        private TabPage familyCodesTab;
        private Button clearFamilyCodes;
        private Button requestFamilyCodes;
        private DataGridView familyCodesGrid;
        private DataGridViewTextBoxColumn familyCodesGridColumnAccountID;
        private DataGridViewTextBoxColumn familyCodesGridColumnFamilyCode;
        private Label accountSelectorLabel;
        private ComboBox accountSelector;
        private TabPage tradingTab;
        private GroupBox execFilterGroup;
        private TextBox execFilterExchange;
        private TextBox execFilterSide;
        private Label execFilterSideLabel;
        private Label execFilterExchangeLabel;
        private Label execFilterSecTypeLabel;
        private Label execFilterSymbolLabel;
        private Label execFilterTimeLabel;
        private Label execFilterAcctLabel;
        private Label execFilterClientLabel;
        private TextBox execFilterSecType;
        private TextBox execFilterSymbol;
        private TextBox execFilterTime;
        private TextBox execFilterAccount;
        private TextBox execFilterClientId;
        private Button refreshExecutionsButton;
        private Button globalCancelButton;
        private Button clientOrdersButton;
        private Button refreshOrdersButton;
        private Button cancelOrdersButton;
        private Button button1;
        private LinkLabel newOrderLink;
        private GroupBox executionsGroup;
        private DataGridView tradeLogGrid;
        private GroupBox liveOrdersGroup;
        private DataGridView liveOrdersGrid;
        private DataGridViewTextBoxColumn permIdColumn;
        private DataGridViewTextBoxColumn clientIdColumn;
        private DataGridViewTextBoxColumn orderIdColumn;
        private DataGridViewTextBoxColumn accountColumn;
        private DataGridViewTextBoxColumn modelCodeColumn;
        private DataGridViewTextBoxColumn actionColumn;
        private DataGridViewTextBoxColumn quantityColumn;
        private DataGridViewTextBoxColumn contractColumn;
        private DataGridViewTextBoxColumn statusColumn;
        private DataGridViewTextBoxColumn cashQtyColumn;
        private TabPage marketDataTab;
        private TabControl marketData_MDT;
        private TabPage topMarketDataTab_MDT;
        private LinkLabel closeMketDataTab;
        private DataGridView marketDataGrid_MDT;
        private TabPage deepBookTab_MDT;
        private LinkLabel closeDeepBookLink;
        private DataGridView deepBookGrid;
        private DataGridViewTextBoxColumn bidBookMaker;
        private DataGridViewTextBoxColumn bidBookSize;
        private DataGridViewTextBoxColumn bidBookPrice;
        private DataGridViewTextBoxColumn askBookPrice;
        private DataGridViewTextBoxColumn askBookSize;
        private DataGridViewTextBoxColumn askBookMaker;
        private TabPage historicalDataTab;
        private LinkLabel histDataTabClose_MDT;
        private DataGridView barsGrid;
        private DataGridViewTextBoxColumn hdDate;
        private DataGridViewTextBoxColumn hdOpen;
        private DataGridViewTextBoxColumn hdHigh;
        private DataGridViewTextBoxColumn hdLow;
        private DataGridViewTextBoxColumn hdClose;
        private DataGridViewTextBoxColumn hdVolume;
        private DataGridViewTextBoxColumn hdWap;
        private System.Windows.Forms.DataVisualization.Charting.Chart historicalChart;
        private TabPage rtBarsTab_MDT;
        private LinkLabel rtBarsCloseLink;
        private DataGridView rtBarsGrid;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataVisualization.Charting.Chart rtBarsChart;
        private TabPage scannerTab;
        private LinkLabel scannerTab_link;
        private DataGridView scannerGrid;
        private DataGridViewTextBoxColumn scanRank;
        private DataGridViewTextBoxColumn scanContract;
        private DataGridViewTextBoxColumn scanDistance;
        private DataGridViewTextBoxColumn scanBenchmark;
        private DataGridViewTextBoxColumn scanProjection;
        private DataGridViewTextBoxColumn scanLegStr;
        private TabPage scannerParamsTab;
        private TextBox scannerParamsOutput;
        private TabPage mktDepthExchanges_MDT;
        private DataGridView mktDepthExchangesGrid_MDT;
        private LinkLabel clearMktDepthExchanges_Button;
        private TabPage symbolSamplesTabData;
        private LinkLabel clearSymbolSamplesMarketData;
        private DataGridView symbolSamplesDataGridData;
        private TabPage smartComponentsTabPage;
        private LinkLabel linkLabel1;
        private DataGridView dataGridViewSmartComponents;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn25;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn26;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn27;
        private TabPage headTimestampTabPage;
        private LinkLabel clearHeadTimestampGridViewlinkLabel;
        private DataGridView headTimestampDataGridView;
        private DataGridViewTextBoxColumn reqIdColumn;
        private DataGridViewTextBoxColumn headTimestampColumn;
        private DataGridViewTextBoxColumn conIdColumn;
        private DataGridViewTextBoxColumn symbolColumn;
        private DataGridViewTextBoxColumn secTypeColumn;
        private DataGridViewTextBoxColumn lastTradeDateorContractMonthColumn;
        private DataGridViewTextBoxColumn strikeColumn;
        private DataGridViewTextBoxColumn rightColumn;
        private DataGridViewTextBoxColumn multiplierColumn;
        private DataGridViewTextBoxColumn exchangeColumn;
        private DataGridViewTextBoxColumn primaryExchColumn;
        private DataGridViewTextBoxColumn currencyColumn;
        private DataGridViewTextBoxColumn localSymbolColumn;
        private DataGridViewTextBoxColumn tradingClassColumn;
        private DataGridViewCheckBoxColumn includeExpiredColumn;
        private DataGridViewTextBoxColumn whatToShowColumn;
        private TabControl dataResults_MDT;
        private TabPage topMktData_MDT;
        private Button ReqSmartComponents_Button;
        private GroupBox groupBox6;
        private Label label8;
        private ComboBox bboExchange_comboBox;
        private GroupBox groupBoxMarketDataType_MDT;
        private ComboBox comboBoxMarketDataType_MDT;
        private GroupBox deepBookGroupBox;
        private Button ReqMktDepthExchanges_Button;
        private TextBox deepBookEntries;
        private Label deepBookEntriesLabel;
        private Button deepBook_Button;
        private GroupBox groupBox2;
        private TextBox primaryExchange;
        private Label primaryExchLabel;
        private TextBox genericTickList;
        private Label genericTickListLabel;
        private Label mdRightLabel;
        private ComboBox mdContractRight;
        private Label putcall_label_TMD_MDT;
        private TextBox multiplier_TMD_MDT;
        private Label symbol_label_TMD_MDT;
        private ComboBox secType_TMD_MDT;
        private Label label1;
        private Label exchange_label_TMD_MDT;
        private TextBox localSymbol_TMD_MDT;
        private Label currency_label_TMD_MDT;
        private TextBox lastTradeDateOrContractMonth_TMD_MDT;
        private TextBox symbol_TMD_MDT;
        private TextBox strike_TMD_MDT;
        private TextBox currency_TMD_MDT;
        private TextBox exchange_TMD_MDT;
        private Label localSymbol_label_TMD_MDT;
        private Label lastTradeDate_label_TMD_MDT;
        private Label strike_label_TMD_MDT;
        private GroupBox groupBox1;
        private Button headTimestamp_button;
        private CheckBox contractMDRTH;
        private Button realTime_Button;
        private Button histData_Button;
        private Label hdEndDate_label_HDT;
        private Label label12;
        private TextBox hdRequest_EndTime;
        private ComboBox hdRequest_WhatToShow;
        private TextBox hdRequest_Duration;
        private CheckBox includeExpired;
        private ComboBox hdRequest_BarSize;
        private Label label10;
        private Label label11;
        private ComboBox hdRequest_TimeUnit;
        private TabPage marketScanner_MDT;
        private GroupBox groupBox4;
        private ComboBox scanCode;
        private ComboBox scanInstrument;
        private Button scannerRequest_Button;
        private ComboBox scanLocation;
        private ComboBox scanStockType;
        private TextBox scanNumRows;
        private Label scanNumRows_label;
        private Label scanCode_label;
        private Label scanStockType_label;
        private Label scanInstrument_label;
        private Label scanLocation_label;
        private Button scannerParamsRequest_button;
        private TabControl TabControl;
        private Button histogram_button;
        private TabPage histogramTabPage;
        private LinkLabel histogramClearLinkLabel;
        private DataGridView histogramDataGridView;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn16;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn17;
        private DataGridViewTextBoxColumn mktDepthExchangesColumn_Exchange;
        private DataGridViewTextBoxColumn mktDepthExchangesColumn_SecType;
        private DataGridViewTextBoxColumn mktDepthExchangesColumn_ListingExch;
        private DataGridViewTextBoxColumn mktDepthExchangesColumn_ServiceDataType;
        private DataGridViewTextBoxColumn mktDepthExchangesColumn_AggGroup;
        private CheckBox cbKeepUpToDate;
        private GroupBox groupBoxMarketRule;
        private Label labelMarketRuleId;
        private Button buttonReqMarketRule;
        private ComboBox comboBoxMarketRuleId;
        private TabPage marketRulePage;
        private DataGridView dataGridViewMarketRule;
        private DataGridViewTextBoxColumn dataGridViewPriceIncrementLowEdge;
        private DataGridViewTextBoxColumn dataGridViewPriceIncrementIncrement;
        private Label labelMarketRuleIdRes;
        private TabPage pnlTab;
        private Button btnReqPnLSingle;
        private TextBox tbConId;
        private Label label13;
        private TextBox tbModelCode;
        private Label label9;
        private Button btnReqPnL;
        private DataGridView dataGridViewPnL;
        private Button btnCancelPnLSingle;
        private Button btnCancelPnL;
        private TabPage historicalTicksTabPage;
        private Label label15;
        private LinkLabel linkLabel2;
        private DataGridView dataGridViewHistoricalTicks;
        private TabPage historicalTicks_MDT;
        private Button requestMatchingSymbolsMD;
        private Button cancelMarketDataRequests;
        private Button marketData_Button;
        private GroupBox groupBox7;
        private TextBox tbNumOfTicks;
        private TextBox tbStartDate;
        private CheckBox cbRthOnly;
        private CheckBox cbIgnoreSize;
        private TextBox tbEndDate;
        private Label label21;
        private Label label20;
        private Label label19;
        private Label label18;
        private ComboBox cbWhatToShow;
        private Button btnRequestHistoricalTicks;
        private DataGridViewTextBoxColumn ExecutionId;
        private DataGridViewTextBoxColumn dateTimeExecColumn;
        private DataGridViewTextBoxColumn accountExecColumn;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private DataGridViewTextBoxColumn actionExecColumn;
        private DataGridViewTextBoxColumn quantityExecColumn;
        private DataGridViewTextBoxColumn descriptionExecColumn;
        private DataGridViewTextBoxColumn priceExecColumn;
        private DataGridViewTextBoxColumn commissionExecColumn;
        private DataGridViewTextBoxColumn RealizedPnL;
        private DataGridViewTextBoxColumn LastLiquidity;
        private TabPage tabPageTickByTick;
        private LinkLabel linkLabelClearTickByTick;
        private Label labelTickByTick;
        private DataGridView dataGridViewTickByTick;
        private GroupBox groupBoxTickByTickType;
        private Button buttonCancelTickByTick;
        private Button buttonRequestTickByTick;
        private ComboBox comboBoxTickByTickType;
        private TextBox textBoxNewsArticlePath;
        private Label labelNewsArticlePath;
        private Button buttonPdfPathDialog;
        private Button buttonAttachOrder;
        private GroupBox groupBox8;
        private Button FilterOptionRemove_button;
        private Button FilterOptionAdd_button;
        private Label label17;
        private TextBox textBoxFilterValue;
        private Label label16;
        private ComboBox comboBoxFilterName;
        private ListView listViewFilterOptions;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private CheckBox cbSmartDepth;
        private GroupBox completedOrdersGroup;
        private Button completedOrdersButton;
        private DataGridView completedOrdersGrid;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn1;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn2;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn3;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn4;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn5;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn6;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn7;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn8;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn9;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn10;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn11;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn12;
        private DataGridViewTextBoxColumn completedOrdersBoxColumn13;
        private TabPage wshTab;
        private Button button3;
        private Button button4;
        private Button button5;
        private TextBox textBoxWshConId;
        private Label labelWshConId;
        private Button button6;
        private DataGridView dataGridViewWsh;
        private DataGridViewTextBoxColumn conResSymbol;
        private DataGridViewTextBoxColumn conResLocalSymbol;
        private DataGridViewTextBoxColumn conResSecType;
        private DataGridViewTextBoxColumn conResCurrency;
        private DataGridViewTextBoxColumn conResExchange;
        private DataGridViewTextBoxColumn conResPrimaryExch;
        private DataGridViewTextBoxColumn conResLastTradeDate;
        private DataGridViewTextBoxColumn conResMultiplier;
        private DataGridViewTextBoxColumn conResStrike;
        private DataGridViewTextBoxColumn conResRight;
        private DataGridViewTextBoxColumn conResConId;
        private DataGridViewTextBoxColumn conResAggGroup;
        private DataGridViewTextBoxColumn conResUnderSymbol;
        private DataGridViewTextBoxColumn conResUnderSecType;
        private DataGridViewTextBoxColumn conResMarketRuleIds;
        private DataGridViewTextBoxColumn conResRealExpirationDate;
        private DataGridViewTextBoxColumn conResContractMonth;
        private DataGridViewTextBoxColumn conResLastTradeTime;
        private DataGridViewTextBoxColumn conResTimeZoneId;
        private DataGridViewTextBoxColumn conResStockType;
        private DataGridViewTextBoxColumn conResMinSize;
        private DataGridViewTextBoxColumn conResSizeIncrement;
        private DataGridViewTextBoxColumn conResSuggestedSizeIncrement;
        private DataGridViewTextBoxColumn bondContractDetailsConId;
        private DataGridViewTextBoxColumn bondContractDetailsSymbol;
        private DataGridViewTextBoxColumn bondContractDetailsExchange;
        private DataGridViewTextBoxColumn bondContractDetailsCurrency;
        private DataGridViewTextBoxColumn bondContractDetailsTradingClass;
        private DataGridViewTextBoxColumn bondContractDetailsMarketName;
        private DataGridViewTextBoxColumn bondContractDetailsMinTick;
        private DataGridViewTextBoxColumn bondContractDetailsOrderTypes;
        private DataGridViewTextBoxColumn bondContractDetailsValidExchanges;
        private DataGridViewTextBoxColumn bondContractDetailsLongName;
        private DataGridViewTextBoxColumn bondContractDetailsAggGroup;
        private DataGridViewTextBoxColumn bondContractDetailsMarketRuleIds;
        private DataGridViewTextBoxColumn bondContractDetailsCusip;
        private DataGridViewTextBoxColumn bondContractDetailsRatings;
        private DataGridViewTextBoxColumn bondContractDetailsDescAppend;
        private DataGridViewTextBoxColumn bondContractDetailsBondType;
        private DataGridViewTextBoxColumn bondContractDetailsCouponType;
        private DataGridViewTextBoxColumn bondContractDetailsCallable;
        private DataGridViewTextBoxColumn bondContractDetailsPutable;
        private DataGridViewTextBoxColumn bondContractDetailsCoupon;
        private DataGridViewTextBoxColumn bondContractDetailsConvertible;
        private DataGridViewTextBoxColumn bondContractDetailsMaturity;
        private DataGridViewTextBoxColumn bondContractDetailsIssueDate;
        private DataGridViewTextBoxColumn bondContractDetailsNextOptionDate;
        private DataGridViewTextBoxColumn bondContractDetailsNextOptionType;
        private DataGridViewTextBoxColumn bondContractDetailsNextOptionPartial;
        private DataGridViewTextBoxColumn bondContractDetailsNotes;
        private DataGridViewTextBoxColumn bondContractDetailsLastTradeTime;
        private DataGridViewTextBoxColumn bondContractDetsilsTimeZoneId;
        private DataGridViewTextBoxColumn bondContractDetailsMinSize;
        private DataGridViewTextBoxColumn bondContractDetailsSizeIncrement;
        private DataGridViewTextBoxColumn bondContractDetailsSuggestedSizeIncrement;
        private Button histScheduleButton;
        private TabPage tabHistoricalSchedule;
        private DataGridView historicalScheduleGrid;
        private DataGridViewTextBoxColumn historicalSchduleGridStartDateTime;
        private DataGridViewTextBoxColumn historicalSchduleGridEndDateTime;
        private DataGridViewTextBoxColumn historicalSchduleGridRefDate;
        private LinkLabel linkLabelClearHistoricalSchedule;
        private Label labelHistoricalSchedule;
        private TextBox historicalScheduleOutput;
        private Button reqUserInfo;
        private CheckBox checkBoxWshFillCompetitors;
        private CheckBox checkBoxWshFillPortfolio;
        private CheckBox checkBoxWshFillWatchlist;
        private TextBox textBoxWshFilter;
        private Label labelWshFilter;
        private DataGridViewTextBoxColumn marketDataContract;
        private DataGridViewTextBoxColumn marketDataTypeTickerColumn;
        private DataGridViewTextBoxColumn bidSize;
        private DataGridViewTextBoxColumn bidPrice;
        private DataGridViewTextBoxColumn preOpenBid;
        private DataGridViewTextBoxColumn preOpenAsk;
        private DataGridViewTextBoxColumn askPrice;
        private DataGridViewTextBoxColumn askSize;
        private DataGridViewTextBoxColumn lastTickerColumn;
        private DataGridViewTextBoxColumn lastPrice;
        private DataGridViewTextBoxColumn volume;
        private DataGridViewTextBoxColumn closeTickerColumn;
        private DataGridViewTextBoxColumn openTickerColumn;
        private DataGridViewTextBoxColumn highTickerColumn;
        private DataGridViewTextBoxColumn lowTickerColumn;
        private DataGridViewTextBoxColumn futuresOpenInterestTickerColumn;
        private DataGridViewTextBoxColumn avgOptVolumeTickerColumn;
        private DataGridViewTextBoxColumn shortableSharesTickerColumn;
        private DataGridViewTextBoxColumn estimatedIPOMidpointTickerColumn;
        private DataGridViewTextBoxColumn finalIPOLastTickerColumn;
        private TextBox textBoxWshTotalLimit;
        private Label labelWshTotalLimit;
        private TextBox textBoxWshEndDate;
        private Label labelWshEndDate;
        private TextBox textBoxWshStartDate;
        private Label labelWshStartDate;
        private TextBox conDetIssuerId;
        private Label conDetIssuerIdLabel;
        private DataGridViewTextBoxColumn symbolSamplesConId2;
        private DataGridViewTextBoxColumn symbolSamplesSymbol2;
        private DataGridViewTextBoxColumn symbolSamplesSecType2;
        private DataGridViewTextBoxColumn symbolSamplesPrimExch2;
        private DataGridViewTextBoxColumn symbolSamplesCurrency2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private DataGridViewTextBoxColumn symbolSamplesDescription2;
        private DataGridViewTextBoxColumn symbolSamplesIssuerId2;
        private DataGridViewTextBoxColumn symbolSamplesConId;
        private DataGridViewTextBoxColumn symbolSamplesSymbol;
        private DataGridViewTextBoxColumn symbolSamplesSecType;
        private DataGridViewTextBoxColumn symbolSamplesPrimExch;
        private DataGridViewTextBoxColumn symbolSamplesCurrency;
        private DataGridViewTextBoxColumn symbolSamplesDerivativeSecTypes;
        private DataGridViewTextBoxColumn symbolSamplesDescription;
        private DataGridViewTextBoxColumn symbolSamplesIssuerId;
        private Button buttonAdditionalForm;
    }
}

