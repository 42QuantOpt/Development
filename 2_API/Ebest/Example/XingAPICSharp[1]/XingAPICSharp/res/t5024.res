BEGIN_FUNCTION_MAP
    .Func,장외단주매도주문(t5024),t5024,base21=SOFST101,headtype=B;
    BEGIN_DATA_MAP
    t5024InBlock,기본입력,input;
    begin
        레코드갯수			     ,reccnt 		,reccnt 	   ,long    ,5	    ;
        매매구분			     ,mmgb   		,mmgb   	   ,char    ,1	    ;
        계좌번호			     ,accno  		,accno  	   ,char    ,20     ;
        비밀번호			     ,passwd 		,passwd 	   ,char    ,8	    ;
        결제업무코드			 ,paycode		,paycode	   ,char    ,2	    ;
        종목번호			     ,expcode		,expcode	   ,char    ,12     ;
        주문수량			     ,qty    		,qty    	   ,long    ,16     ;
        주문단가			     ,orddan 		,orddan 	   ,double  ,15.4   ;
    end
    t5024OutBlock,기본출력,output;
    begin
        레코드갯수			     ,reccnt 		,reccnt 	   ,long    ,5	    ;
        매매구분			     ,mmgb   		,mmgb   	   ,char    ,1	    ;
        계좌번호			     ,accno  		,accno  	   ,char    ,20     ;
        비밀번호			     ,passwd 		,passwd 	   ,char    ,8	    ;
        결제업무코드			 ,paycode		,paycode	   ,char    ,2	    ;
        종목번호			     ,expcode		,expcode	   ,char    ,12     ;
        주문수량			     ,qty    		,qty    	   ,long    ,16     ;
        주문단가			     ,orddan 		,orddan 	   ,double  ,15.4   ;
    end
    t5024OutBlock1,기본출력1,output;
    begin
        레코드갯수			     ,reccnt  		,reccnt  	   ,long    ,5	    ;
        계좌명				     ,accno   		,accno   	   ,char    ,40     ;
        종목명				     ,expcode 		,expcode 	   ,char    ,40     ;
        주문번호			     ,ordno   		,ordno   	   ,long    ,10     ;
        주문금액			     ,ordprice		,ordprice	   ,long    ,16     ;
        수수료				     ,fee     		,fee     	   ,long    ,16     ;
        결제일				     ,paydate 		,paydate 	   ,char    ,8	    ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
