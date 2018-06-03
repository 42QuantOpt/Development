BEGIN_FUNCTION_MAP
    .Func,계좌예탁현황(선물/옵션)(t6034),t6034,base21=SONBQ105,headtype=B;
    BEGIN_DATA_MAP
    t6034InBlock,기본입력,input;
    begin
        레코드갯수                 ,reccnt               ,reccnt               ,long    ,5      ;
        계좌번호                   ,accno                ,accno                ,char    ,20     ;
        비밀번호                   ,passwd               ,passwd               ,char    ,8      ;
    end
    t6034OutBlock,기본출력,output;
    begin
        레코드갯수                 ,reccnt               ,reccnt               ,long    ,5      ;
        계좌번호                   ,accno                ,accno                ,char    ,20     ;
        비밀번호                   ,passwd               ,passwd               ,char    ,8      ;
    end
    t6034OutBlock1,기본출력1,output;
    begin
        레코드갯수                 ,reccnt              ,reccnt                ,long    ,5      ;
        계좌명                     ,accname             ,accname               ,char    ,40     ;
        예탁금총액                 ,yetaktotamt         ,yetaktotamt           ,long    ,16     ;
        예수금                     ,yesuamt             ,yesuamt               ,long    ,16     ;
        대용금액                   ,dyamt               ,dyamt                 ,long    ,16     ;
        충당예탁금총액             ,addyetaktotamt      ,addyetaktotamt        ,long    ,16     ;
        충당예수금                 ,addyesuamt          ,addyesuamt            ,long    ,16     ;
        선물손익금액               ,futprofitamt        ,futprofitamt          ,long    ,16     ;
        인출가능금액               ,outamt              ,outamt                ,long    ,16     ;
        인출가능현금액             ,outcashamt          ,outcashamt            ,long    ,16     ;
        인출가능대용금액           ,outdyamt            ,outdyamt              ,long    ,16     ;
        증거금액                   ,dipositamt          ,dipositamt            ,long    ,16     ;
        현금증거금액               ,cashdipositamt      ,cashdipositamt        ,long    ,16     ;
        주문가능금액               ,ordpoamt            ,ordpoamt              ,long    ,16     ;
        현금주문가능금액           ,cashpoamt           ,cashpoamt             ,long    ,16     ;
        추가증거금액               ,adddipositamt       ,adddipositamt         ,long    ,16     ;
        현금추가증거금액           ,cashadddipositamt   ,cashadddipositamt     ,long    ,16     ;
        금전일수표입금액           ,supyoinamt          ,supyoinamt            ,long    ,16     ;
        선물옵션전일대용매도금액   ,foptpredymedoamt    ,foptpredymedoamt      ,long    ,16     ;
        선물옵션금일대용매도금액   ,fopttodaydymedoamt  ,fopttodaydymedoamt    ,long    ,16     ;
        선물옵션전일가입금액       ,foptpreaddamt       ,foptpreaddamt         ,long    ,16     ;
        선물옵션금일가입금액       ,fopttodayaddamt     ,fopttodayaddamt       ,long    ,16     ;
        외화대용금액               ,fordyamt            ,fordyamt              ,long    ,16     ;
        선물옵션계좌사후증거금명   ,foptaccpositname    ,foptaccpositname      ,char    ,20     ;
    end
    t6034OutBlock2,기본출력2,output,occurs;
    begin
        상품군코드명               ,groupcodname        ,groupcodname          ,char    ,20     ;
        순위험증거금액             ,dangerpositamt      ,dangerpositamt        ,long    ,16     ;
        가격증거금액               ,pricepositamt       ,pricepositamt         ,long    ,16     ;
        스프레드증거금액           ,spreadpositamt      ,spreadpositamt        ,long    ,16     ;
        가격변동증거금액           ,priceratepositamt   ,priceratepositamt     ,long    ,16     ;
        최소증거금액               ,minpositamt         ,minpositamt           ,long    ,16     ;
        주문증거금액               ,ordpositamt         ,ordpositamt           ,long    ,16     ;
        옵션순매수금액             ,optsunmesuamt       ,optsunmesuamt         ,long    ,16     ;
        위탁증거금액               ,wtpositamt          ,wtpositamt            ,long    ,16     ;
        유지증거금액               ,ujpositamt          ,ujpositamt            ,long    ,16     ;
        선물매수체결금액           ,fmesucheamt         ,fmesucheamt           ,long    ,16     ;
        선물매도체결금액           ,fmedocheamt         ,fmedocheamt           ,long    ,16     ;
        옵션매수체결금액           ,optmesucheamt       ,optmesucheamt         ,long    ,16     ;
        옵션매도체결금액           ,optmedocheamt       ,optmedocheamt         ,long    ,16     ;
        선물손익금액               ,flossamt            ,flossamt              ,long    ,16     ;
		총위험위탁증거금		   ,totriskwtpositamt   ,totriskwtpositamt	   ,long    ,16     ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
