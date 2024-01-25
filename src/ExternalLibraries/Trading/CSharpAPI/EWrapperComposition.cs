using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace IBApi
{
    /// <summary>
    /// Composition of wrappers
    /// </summary>
    public abstract  class EWrapperComposition : EWrapper, IClientHolder
    {

        #region Fields

        protected EClient client;

        /// <summary>
        /// Wrappers
        /// </summary>
        protected IEnumerable<EWrapper> wrappers;

        EClient IClientHolder.Client 
        { 
            get => client;
            set
            {
                client = value;
                foreach (var wrapper in wrappers)
                {
                    if (wrapper is IClientHolder)
                    {
                        (wrapper as IClientHolder).Client = client;
                    }
                }
            }
        }

        #endregion


        #region Ctor

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="wrappers">Wrappers</param>
        public EWrapperComposition(IEnumerable<EWrapper> wrappers)
        {
            if (wrappers == null)
            {
                return;
            }
            this.wrappers = wrappers;
            SetWrappers();
        }

        #endregion

        #region Members

        protected virtual void SetWrappers()
        {
            foreach (var wrapper in wrappers)
            {
                if (wrapper is IParent)
                {
                    (wrapper as IParent).Parent = this;
                }
             }
        }


  
        #endregion


        #region EWrapper implemetation

        void EWrapper.accountDownloadEnd(string account)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.accountDownloadEnd(account);
            }
        }

        void EWrapper.accountSummary(int reqId, string account, string tag, string value, string currency)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.accountSummary(reqId, account, tag, value, currency);
            }
        }

        void EWrapper.accountSummaryEnd(int reqId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.accountSummaryEnd(reqId);
            }
        }

        void EWrapper.accountUpdateMulti(int requestId, string account, string modelCode, string key, string value, string currency)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.accountUpdateMulti(requestId, account, modelCode,
                     key, value, currency);

            }
        }

        void EWrapper.accountUpdateMultiEnd(int requestId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.accountUpdateMultiEnd(requestId);
            }
        }

        void EWrapper.bondContractDetails(int reqId, ContractDetails contract)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.bondContractDetails(reqId, contract);
            }
        }

        void EWrapper.commissionReport(CommissionReport commissionReport)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.commissionReport(commissionReport);
            }
        }

        void EWrapper.completedOrder(Contract contract, Order order, OrderState orderState)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.completedOrder(contract, order, orderState);
            }
        }

        void EWrapper.completedOrdersEnd()
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.completedOrdersEnd();
            }
        }

        void EWrapper.connectAck()
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.connectAck();
            }
        }

        void EWrapper.connectionClosed()
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.connectionClosed();
            }
        }

        void EWrapper.contractDetails(int reqId, ContractDetails contractDetails)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.contractDetails(reqId, contractDetails);
            }
        }

        void EWrapper.contractDetailsEnd(int reqId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.contractDetailsEnd(reqId);
            }
        }

        void EWrapper.currentTime(long time)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.currentTime(time);
            }
        }

        void EWrapper.deltaNeutralValidation(int reqId, DeltaNeutralContract deltaNeutralContract)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.deltaNeutralValidation(reqId, deltaNeutralContract);
            }
        }

        void EWrapper.displayGroupList(int reqId, string groups)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.displayGroupList(reqId, groups);
            }
        }

        void EWrapper.displayGroupUpdated(int reqId, string contractInfo)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.displayGroupUpdated(reqId, contractInfo);
            }
        }

        void EWrapper.error(Exception e)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.error(e);
            }
        }

        void EWrapper.error(string str)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.error(str);
            }
        }

        void EWrapper.error(int id, int errorCode, string errorMsg, string advancedOrderRejectJson)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.error(id, errorCode, errorMsg, advancedOrderRejectJson);
            }
        }

        void EWrapper.execDetails(int reqId, Contract contract, Execution execution)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.execDetails(reqId, contract, execution);
            }
        }

        void EWrapper.execDetailsEnd(int reqId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.execDetailsEnd(reqId);
            }
        }

        void EWrapper.familyCodes(FamilyCode[] familyCodes)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.familyCodes(familyCodes);
            }
        }

        void EWrapper.fundamentalData(int reqId, string data)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.fundamentalData(reqId, data);
            }
        }

        void EWrapper.headTimestamp(int reqId, string headTimestamp)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.headTimestamp(reqId, headTimestamp);
            }
        }

        void EWrapper.histogramData(int reqId, HistogramEntry[] data)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.histogramData(reqId, data);
            }
        }

        void EWrapper.historicalData(int reqId, Bar bar)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalData(reqId, bar);
            }
        }

        void EWrapper.historicalDataEnd(int reqId, string start, string end)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalDataEnd(reqId, start, end);
            }
        }

        void EWrapper.historicalDataUpdate(int reqId, Bar bar)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalDataUpdate(reqId, bar);
            }
        }

        void EWrapper.historicalNews(int requestId, string time, string providerCode,
            string articleId, string headline)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalNews(requestId, time, providerCode,
                   articleId, headline);
            }
        }

        void EWrapper.historicalNewsEnd(int requestId, bool hasMore)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalNewsEnd(requestId, hasMore);
            }
        }

        void EWrapper.historicalSchedule(int reqId, string startDateTime, string endDateTime,
            string timeZone, HistoricalSession[] sessions)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalSchedule(reqId, startDateTime, endDateTime,
             timeZone, sessions);
            }
        }

        void EWrapper.historicalTicks(int reqId, HistoricalTick[] ticks, bool done)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalTicks(reqId, ticks, done);
            }
        }

        void EWrapper.historicalTicksBidAsk(int reqId, HistoricalTickBidAsk[] ticks, bool done)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalTicksBidAsk(reqId, ticks, done);
            }
        }

        void EWrapper.historicalTicksLast(int reqId, HistoricalTickLast[] ticks, bool done)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.historicalTicksLast(reqId, ticks, done);
            }
        }

        void EWrapper.managedAccounts(string accountsList)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.managedAccounts(accountsList);
            }
        }

        void EWrapper.marketDataType(int reqId, int marketDataType)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.marketDataType(reqId, marketDataType);
            }
        }

        void EWrapper.marketRule(int marketRuleId, PriceIncrement[] priceIncrements)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.marketRule(marketRuleId, priceIncrements);
            }
        }

        void EWrapper.mktDepthExchanges(DepthMktDataDescription[] depthMktDataDescriptions)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.mktDepthExchanges(depthMktDataDescriptions);
            }
        }

        void EWrapper.newsArticle(int requestId, int articleType, string articleText)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.newsArticle(requestId, articleType, articleText);
            }
        }

        void EWrapper.newsProviders(NewsProvider[] newsProviders)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.newsProviders(newsProviders);
            }
        }

        void EWrapper.nextValidId(int orderId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.nextValidId(orderId);
            }
        }

        void EWrapper.openOrder(int orderId, Contract contract, Order order, OrderState orderState)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.openOrder(orderId, contract, order, orderState);
            }
        }

        void EWrapper.openOrderEnd()
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.openOrderEnd();
            }
        }

        void EWrapper.orderBound(long orderId, int apiClientId, int apiOrderId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.orderBound(orderId, apiClientId, apiOrderId);
            }
        }

        void EWrapper.orderStatus(int orderId, string status, decimal filled,
            decimal remaining, double avgFillPrice, int permId, int parentId, double
            lastFillPrice, int clientId, string whyHeld, double mktCapPrice)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.orderStatus(orderId, status, filled,
             remaining, avgFillPrice, permId, parentId,
            lastFillPrice, clientId, whyHeld, mktCapPrice);
            }
        }

        void EWrapper.pnl(int reqId, double dailyPnL, double unrealizedPnL, double realizedPnL)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.pnl(reqId, dailyPnL, unrealizedPnL, realizedPnL);
            }
        }

        void EWrapper.pnlSingle(int reqId, decimal pos, double dailyPnL, double unrealizedPnL,
            double realizedPnL, double value)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.pnlSingle(reqId, pos, dailyPnL, unrealizedPnL, realizedPnL, value);
            }
        }

        void EWrapper.position(string account, Contract contract, decimal pos, double avgCost)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.position(account, contract, pos, avgCost);
            }
        }

        void EWrapper.positionEnd()
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.positionEnd();
            }
        }

        void EWrapper.positionMulti(int requestId, string account, string modelCode,
            Contract contract, decimal pos, double avgCost)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.positionMulti(requestId, account, modelCode,
                    contract, pos, avgCost);
            }
        }

        void EWrapper.positionMultiEnd(int requestId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.positionMultiEnd(requestId);
            }
        }

        void EWrapper.realtimeBar(int reqId, long date, double open, double high,
            double low, double close, decimal volume, decimal WAP, int count)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.realtimeBar(reqId, date, open, high,
                     low, close, volume, WAP, count);
            }
        }

        void EWrapper.receiveFA(int faDataType, string faXmlData)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.receiveFA(faDataType, faXmlData);
            }
        }

        void EWrapper.replaceFAEnd(int reqId, string text)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.replaceFAEnd(reqId, text);
            }
        }

        void EWrapper.rerouteMktDataReq(int reqId, int conId, string exchange)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.rerouteMktDataReq(reqId, conId, exchange);
            }
        }

        void EWrapper.rerouteMktDepthReq(int reqId, int conId, string exchange)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.rerouteMktDepthReq(reqId, conId, exchange);
            }
        }

        void EWrapper.scannerData(int reqId, int rank, ContractDetails contractDetails,
            string distance, string benchmark, string projection, string legsStr)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.scannerData(reqId, rank, contractDetails,
                    distance, benchmark, projection, legsStr);
            }
        }

        void EWrapper.scannerDataEnd(int reqId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.scannerDataEnd(reqId);
            }
        }

        void EWrapper.scannerParameters(string xml)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.scannerParameters(xml);
            }
        }

        void EWrapper.securityDefinitionOptionParameter(int reqId, string exchange, int underlyingConId,
            string tradingClass, string multiplier, HashSet<string> expirations, HashSet<double> strikes)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.securityDefinitionOptionParameter(reqId, exchange, underlyingConId,
                     tradingClass, multiplier, expirations, strikes);
            }
        }

        void EWrapper.securityDefinitionOptionParameterEnd(int reqId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.securityDefinitionOptionParameterEnd(reqId);
            }
        }

        void EWrapper.smartComponents(int reqId, Dictionary<int, KeyValuePair<string, char>> theMap)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.smartComponents(reqId, theMap);
            }
        }

        void EWrapper.softDollarTiers(int reqId, SoftDollarTier[] tiers)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.softDollarTiers(reqId, tiers);
            }
        }

        void EWrapper.symbolSamples(int reqId, ContractDescription[] contractDescriptions)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.symbolSamples(reqId, contractDescriptions);
            }
        }

        void EWrapper.tickByTickAllLast(int reqId, int tickType, long time, double price,
            decimal size, TickAttribLast tickAttribLast, string exchange, string specialConditions)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickByTickAllLast(reqId, tickType, time, price,
                    size, tickAttribLast, exchange, specialConditions);
            }
        }

        void EWrapper.tickByTickBidAsk(int reqId, long time, double bidPrice, double askPrice,
            decimal bidSize, decimal askSize, TickAttribBidAsk tickAttribBidAsk)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickByTickBidAsk(reqId, time, bidPrice, askPrice,
             bidSize, askSize, tickAttribBidAsk);
            }
        }

        void EWrapper.tickByTickMidPoint(int reqId, long time, double midPoint)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickByTickMidPoint(reqId, time, midPoint);
            }
        }

        void EWrapper.tickEFP(int tickerId, int tickType, double basisPoints, string formattedBasisPoints,
            double impliedFuture, int holdDays, string futureLastTradeDate, double dividendImpact,
            double dividendsToLastTradeDate)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickEFP(tickerId, tickType, basisPoints, formattedBasisPoints,
                     impliedFuture, holdDays, futureLastTradeDate, dividendImpact,
                     dividendsToLastTradeDate);
            }
        }

        void EWrapper.tickGeneric(int tickerId, int field, double value)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickGeneric(tickerId, field, value);
            }
        }

        void EWrapper.tickNews(int tickerId, long timeStamp, string providerCode, string articleId,
            string headline, string extraData)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickNews(tickerId, timeStamp, providerCode, articleId,
                     headline, extraData);
            }
        }

        void EWrapper.tickOptionComputation(int tickerId, int field, int tickAttrib,
            double impliedVolatility, double delta, double optPrice, double pvDividend,
            double gamma, double vega, double theta, double undPrice)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickOptionComputation(tickerId, field, tickAttrib,
                     impliedVolatility, delta, optPrice, pvDividend,
                     gamma, vega, theta, undPrice);
            }
        }

        void EWrapper.tickPrice(int tickerId, int field, double price, TickAttrib attribs)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickPrice(tickerId, field, price, attribs);
            }
        }

        void EWrapper.tickReqParams(int tickerId, double minTick, string bboExchange, int snapshotPermissions)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickReqParams(tickerId, minTick, bboExchange, snapshotPermissions);
            }
        }

        void EWrapper.tickSize(int tickerId, int field, decimal size)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickSize(tickerId, field, size);
            }
        }

        void EWrapper.tickSnapshotEnd(int tickerId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickSnapshotEnd(tickerId);
            }
        }

        void EWrapper.tickString(int tickerId, int field, string value)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.tickString(tickerId, field, value);
            }
        }

        void EWrapper.updateAccountTime(string timestamp)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.updateAccountTime(timestamp);
            }
        }

        void EWrapper.updateAccountValue(string key, string value, string currency, string accountName)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.updateAccountValue(key, value, currency, accountName);
            }
        }

        void EWrapper.updateMktDepth(int tickerId, int position, int operation, int side, double price, decimal size)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.updateMktDepth(tickerId, position, operation, side, price, size);
            }
        }

        void EWrapper.updateMktDepthL2(int tickerId, int position, string marketMaker, int operation, int side, double price, decimal size, bool isSmartDepth)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.updateMktDepthL2(tickerId, position, marketMaker, operation, side, price, size, isSmartDepth);

            }
        }

        void EWrapper.updateNewsBulletin(int msgId, int msgType, string message, string origExchange)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.updateNewsBulletin(msgId, msgType, message, origExchange);
            }
        }

        void EWrapper.updatePortfolio(Contract contract, decimal position, double marketPrice, double marketValue,
            double averageCost, double unrealizedPNL, double realizedPNL, string accountName)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.updatePortfolio(contract, position, marketPrice, marketValue,
             averageCost, unrealizedPNL, realizedPNL, accountName);

            }
        }

        void EWrapper.userInfo(int reqId, string whiteBrandingId)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.userInfo(reqId, whiteBrandingId);
            }
        }

        void EWrapper.verifyAndAuthCompleted(bool isSuccessful, string errorText)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.verifyAndAuthCompleted(isSuccessful, errorText);
            }
        }

        void EWrapper.verifyAndAuthMessageAPI(string apiData, string xyzChallenge)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.verifyAndAuthMessageAPI(apiData, xyzChallenge);
            }
        }

        void EWrapper.verifyCompleted(bool isSuccessful, string errorText)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.verifyCompleted(isSuccessful, errorText);
            }
        }

        void EWrapper.verifyMessageAPI(string apiData)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.verifyMessageAPI(apiData);
            }
        }

        void EWrapper.wshEventData(int reqId, string dataJson)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.wshEventData(reqId, dataJson);
            }
        }

        void EWrapper.wshMetaData(int reqId, string dataJson)
        {
            foreach (var wrapper in wrappers)
            {
                wrapper.wshMetaData(reqId, dataJson);
            }
        }

        #endregion
    }
}
