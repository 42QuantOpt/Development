function y = HestonCF(phi,param,tau,S,r,q,Trap)

% Returns the Heston characteristic function,f2 (the second CF)
% Uses original Heston formulation 1,or formulation 2 from "The Little Heston Trap"
% phi = integration variable
% Heston parameters in param structure:
%    kappa  = volatility mean reversion speed parameter
%    theta  = volatility mean reversion level parameter
%    lambda = risk parameter
%    rho    = correlation between two Brownian motions
%    sigma  = volatility of variance
%    v0     = initial variance
% Option features.
%    S = spot price
%    r = risk free rate
%    q = dividend yield 
% Trap = 0 --> Original Heston Formulation
% Trap = 1 --> Little Trap formulation


kappa = param.kappa;
theta = param.theta;
sigma = param.sigma;
rho   = param.rho;
v0    = param.v0;
lambda = 0;


% Log of the stock price.
x = log(S);

% Parameter a
a = kappa.*theta;

% Parameters u,b,d,and b
u = -0.5;
b = kappa + lambda;
d = sqrt((rho.*sigma.*i.*phi - b).^2 - sigma.^2.*(2.*u.*i.*phi - phi.^2));
g = (b - rho.*sigma.*i.*phi + d) ./ (b - rho.*sigma.*i.*phi - d);

if Trap==1
	% "Little Heston Trap" formulation
	c = 1./g;
	G = (1 - c.*exp(-d.*tau))./(1-c);
	C = (r-q).*i.*phi.*tau + a./sigma.^2.*((b - rho.*sigma.*i.*phi - d).*tau - 2.*log(G));
	D = (b - rho.*sigma.*i.*phi - d)./sigma.^2.*((1-exp(-d.*tau))./(1-c.*exp(-d.*tau)));
elseif Trap==0
	% Original Heston formulation.
	G = (1 - g.*exp(d.*tau))./(1-g);
	C = (r-q).*i.*phi.*tau + a./sigma.^2.*((b - rho.*sigma.*i.*phi + d).*tau - 2.*log(G));
	D = (b - rho.*sigma.*i.*phi + d)./sigma.^2.*((1-exp(d.*tau))./(1-g.*exp(d.*tau)));
end

% The characteristic function.
y = exp(C + D.*v0 + i.*phi.*x);

