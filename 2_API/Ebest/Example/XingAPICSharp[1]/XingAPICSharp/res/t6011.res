BEGIN_FUNCTION_MAP
    .Func,계좌별 예수금 조회(t6011),t6011,base21=SONAQ109,headtype=B;
    BEGIN_DATA_MAP
    t6011InBlock,기본입력,input;
    begin
        레코드갯수			            ,reccnt   		        ,reccnt   	           ,long    ,5	    ;
        관리지점번호		            ,kwbpno   		        ,kwbpno   	           ,char    ,3	    ;
        계좌번호			            ,accno    		        ,accno    	           ,char    ,20     ;
        비밀번호			            ,passwd   		        ,passwd   	           ,char    ,8	    ;
        잔고생성구분		            ,jangb  		        ,jangb  	           ,char    ,1      ;
    end
    t6011OutBlock,기본출력,output;
    begin
        레코드갯수			            ,reccnt   		        ,reccnt   	           ,long    ,5	    ;
        관리지점번호		            ,kwbpno   		        ,kwbpno   	           ,char    ,3	    ;
        계좌번호			            ,accno    		        ,accno    	           ,char    ,20     ;
        비밀번호			            ,passwd   		        ,passwd   	           ,char    ,8	    ;
        잔고생성구분		            ,jangb  		        ,jangb  	           ,char    ,1      ;
    end
    t6011OutBlock1,기본출력1,output;
    begin
        레코드갯수			            ,reccnt   		        ,reccnt   	            ,long    ,5	    ;
		지점명							,bpname					,bpname				    ,char	,40		;
		계좌명							,name					,name				    ,char	,40		;
		현금주문가능금액				,ordcamt				,ordcamt				,long	,16		;
		출금가능금액					,drawamt				,drawamt				,long	,16		;
		거래소금액						,kospiamt				,kospiamt				,long	,16		;
		코스닥금액						,kosdaqamt				,kosdaqamt				,long	,16		;
		평가금액						,evlamt					,evlamt					,long	,16		;
		미수금액						,sunapsum				,sunapsum				,long	,16		;
		예탁자산총액					,yetaktot				,yetaktot				,long	,16		;
		손익률							,sonik					,sonik					,double	,12.6	;
		투자원금						,tujawon				,tujawon				,long	,20		;
		투자손익금액					,tujason				,tujason				,long	,16		;
		신용담보주문금액				,sindambo				,sindambo				,long	,16		;
		예수금							,depoamt				,depoamt				,long	,16		;
		대용금액						,daeamt					,daeamt					,long	,16		;
		D1예수금						,d1depoamt				,d1depoamt				,long	,16		;
		D2예수금						,d2depoamt				,d2depoamt				,long	,16		;
		현금미수금액					,cashamt   				,cashamt   				,long	,16		;
		증거금현금						,margincash				,margincash				,long	,16		;
		증거금대용						,margindae				,margindae				,long	,16		;
		수표금액						,supyoamt				,supyoamt				,long	,16		;
		대용주문가능금액				,ordcamtdae				,ordcamtdae				,long	,16		;
		증거금률100퍼센트주문가능금액	,ord100					,ord100					,long	,16		;
		증거금률35%주문가능금액			,inordamt				,inordamt				,long	,16		;
		증거금률50%주문가능금액			,ord50					,ord50					,long	,16		;
		전일매도정산금액				,dmdosoamt				,dmdosoamt				,long	,16		;
		전일매수정산금액				,dmsusoamt				,dmsusoamt				,long	,16		;
		금일매도정산금액				,todosoamt				,todosoamt				,long	,16		;
		금일매수정산금액				,tosusoamt				,tosusoamt				,long	,16		;
		D1연체변제소요금액				,dmpayneed				,dmpayneed				,long	,16		;
		D2연체변제소요금액				,topayneed				,topayneed				,long	,16		;
		D1추정인출가능금액				,d1drawamt				,d1drawamt				,long	,16		;
		D2추정인출가능금액				,d2drawamt				,d2drawamt				,long	,16		;
		예탁담보대출금액				,dambore				,dambore				,long	,16		;
		신용설정보증금					,limreq					,limreq					,long	,16		;
		융자금액						,loanamt				,loanamt				,long	,16		;
		담보비율						,damborate				,damborate				,double	,9.3	;
		원담보금액						,cashjan				,cashjan				,long	,16	 	;
		부담보금액						,bucashjan				,bucashjan				,long	,16		;
		소요담보금액					,needdambo				,needdambo				,long	,16		;
		원담보부족금액					,orgdambo				,orgdambo				,long	,16		;
		담보부족금액					,dambolack				,dambolack				,long	,16		;
		추가담보현금					,chugadambo				,chugadambo				,long	,16		;
		D1주문가능금액					,d1jumun				,d1jumun				,long	,16		;
		신용이자미납금액				,sinimnap				,sinimnap				,long	,16		;
		기타대여금액					,etcloan				,etcloan				,long	,16		;
		익일추정반대매매금액			,nextbandae				,nextbandae				,long	,16		;
		원담보합계금액					,cashjantot				,cashjantot				,long	,16		;
		신용주문가능금액				,sinordamt				,sinordamt				,long	,16		;
		부담보합계금액					,bucashjantot			,bucashjantot			,long	,16 	;
		신용담보금현금					,sindamcash				,sindamcash				,long	,16		;
		신용담보대용금액				,sindamdae 				,sindamdae 				,long	,16		;
		추가신용담보현금				,addsindamcash			,addsindamcash			,long	,16		;
		신용담보재사용금액				,sindamreuseamt			,sindamreuseamt			,long	,16		;
		추가신용담보대용				,addsindamdae			,addsindamdae			,long	,16		;
		매도대금담보대출금액			,mddaedamloanamt		,mddaedamloanamt		,long	,16		;
		처분제한금액					,chlimitamt				,chlimitamt				,long	,16		;
    end
    END_DATA_MAP
END_FUNCTION_MAP
