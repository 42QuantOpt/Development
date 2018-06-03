BEGIN_FUNCTION_MAP
    .Func,선옵정정주문(t5512),t5512,base21=SONBT002,headtype=B;
    BEGIN_DATA_MAP
    t5512InBlock,기본입력,input;
    begin
        레코드갯수			     ,reccnt       		,reccnt       	   ,long    ,5	    ;
        주문시장코드		     ,ordmarketcode		,ordmarketcode	   ,char    ,2	    ;
        계좌번호			     ,accno        		,accno        	   ,char    ,20     ;
        입력비밀번호		     ,passwd       		,passwd       	   ,char    ,8	    ;
        선물옵션종목번호	     ,expcode      		,expcode      	   ,char    ,32     ;
		선물옵션주문유형코드     ,fnoordptncode     ,fnoordptncode     ,char    ,2      ;	
        dummy원주문번호			 ,dummyorgordno     ,dummyorgordno     ,long    ,3      ;
        원주문번호			     ,orgordno     		,orgordno     	   ,long    ,7      ;
        선물옵션호가유형코드	 ,offergb      		,offergb      	   ,char    ,2	    ;
        주문가				     ,price        		,price        	   ,double  ,13.2   ;
        정정수량			     ,qty          		,qty          	   ,long    ,16     ;
        통신매체코드			 ,tongsingb    		,tongsingb    	   ,char    ,2	    ;
        전략코드			     ,stragb       		,stragb       	   ,char    ,6	    ;
        그룹ID				     ,groupid      		,groupid      	   ,char    ,20     ;
        주문회차			     ,ordernum     		,ordernum     	   ,long    ,10     ;
        포트폴리오번호			 ,portnum      		,portnum      	   ,long    ,10     ;
        바스켓번호			     ,basketnum    		,basketnum    	   ,long    ,10     ;
        트렌치번호			     ,tranchnum    		,tranchnum    	   ,long    ,10     ;
        아이템번호			     ,itemnum      		,itemnum      	   ,long    ,10     ;
		관리사번                 ,mgempno           ,mgempno           ,char    ,9      ;
		펀드ID                   ,fundid            ,fundid            ,char    ,12     ;
		dummy펀드원주문번호      ,dummyfundorgordno ,dummyfundorgordno ,long    ,3      ;
		펀드원주문번호           ,fundorgordno      ,fundorgordno      ,long    ,7      ;
		dummy펀드주문번호        ,dummyfundordno    ,dummyfundordno    ,long    ,3      ;
		펀드주문번호             ,fundordno         ,fundordno         ,long    ,7      ;
    end
    t5512OutBlock,기본출력,output;
    begin
        레코드갯수			     ,reccnt       		,reccnt       	   ,long    ,5	    ;
        주문시장코드		     ,ordmarketcode		,ordmarketcode	   ,char    ,2	    ;
        계좌번호			     ,accno        		,accno        	   ,char    ,20     ;
        입력비밀번호		     ,passwd       		,passwd       	   ,char    ,8	    ;
        선물옵션종목번호	     ,expcode      		,expcode      	   ,char    ,32     ;
		선물옵션주문유형코드     ,fnoordptncode     ,fnoordptncode     ,char    ,2      ;	
        dummy원주문번호			 ,dummyorgordno     ,dummyorgordno     ,long    ,3      ;
        원주문번호			     ,orgordno     		,orgordno     	   ,long    ,7      ;
        선물옵션호가유형코드	 ,offergb      		,offergb      	   ,char    ,2	    ;
        주문가				     ,price        		,price        	   ,double  ,13.2   ;
        정정수량			     ,qty          		,qty          	   ,long    ,16     ;
        통신매체코드			 ,tongsingb    		,tongsingb    	   ,char    ,2	    ;
        전략코드			     ,stragb       		,stragb       	   ,char    ,6	    ;
        그룹ID				     ,groupid      		,groupid      	   ,char    ,20     ;
        주문회차			     ,ordernum     		,ordernum     	   ,long    ,10     ;
        포트폴리오번호			 ,portnum      		,portnum      	   ,long    ,10     ;
        바스켓번호			     ,basketnum    		,basketnum    	   ,long    ,10     ;
        트렌치번호			     ,tranchnum    		,tranchnum    	   ,long    ,10     ;
        아이템번호			     ,itemnum      		,itemnum      	   ,long    ,10     ;
		관리사번                 ,mgempno           ,mgempno           ,char    ,9      ;
		펀드ID                   ,fundid            ,fundid            ,char    ,12     ;
		dummy펀드원주문번호      ,dummyfundorgordno ,dummyfundorgordno ,long    ,3      ;
		펀드원주문번호           ,fundorgordno      ,fundorgordno      ,long    ,7      ;
		dummy펀드주문번호        ,dummyfundordno    ,dummyfundordno    ,long    ,3      ;
		펀드주문번호             ,fundordno         ,fundordno         ,long    ,7      ;
    end
    t5512OutBlock1,기본출력1,output;
    begin
        레코드갯수			     ,reccnt		    ,reccnt	           ,long    ,5	    ;
        dummy주문번호			 ,dummyordno 		,dummyordno 	   ,long    ,3      ;
        주문번호			     ,ordno 		    ,ordno 	           ,long    ,7      ;
		지점명                   ,brnnm             ,brnnm             ,char    ,40     ;
		계좌명                   ,accno             ,accno             ,char    ,40     ;
		종목명                   ,isunm             ,isunm             ,char    ,40     ;
		주문가능금액             ,ordableamt        ,ordableamt        ,long    ,16     ;
		현금주문가능금액         ,mnyordableamt     ,mnyordableamt     ,long    ,16     ;
		주문증거금액             ,ordmgn            ,ordmgn            ,long    ,16     ;
		현금주문증거금액         ,mnyordmgn         ,mnyordmgn         ,long    ,16     ;
		주문가능수량             ,ordableqty        ,ordableqty        ,long    ,16     ;
    end
    END_DATA_MAP
END_FUNCTION_MAP
