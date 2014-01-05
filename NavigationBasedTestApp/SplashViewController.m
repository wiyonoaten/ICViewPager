//
//  SplashViewController.m
//  ICViewPager
//
//  Created by Zinc on 05/01/2014.
//  Copyright (c) 2014 Ilter Cengiz. All rights reserved.
//

#import "SplashViewController.h"
#import "MainViewController.h"

@interface SplashViewController ()

@end

@implementation SplashViewController

- (id)init
{
    self = [super initWithNibName:@"SplashViewController" bundle:nil];
    if (self) {
        // Custom initialization
    }
    return self;
}

- (void)viewDidLoad
{
    [super viewDidLoad];
    // Do any additional setup after loading the view from its nib.
}

- (void)didReceiveMemoryWarning
{
    [super didReceiveMemoryWarning];
    // Dispose of any resources that can be recreated.
}

- (void)viewDidLayoutSubviews
{
    [super viewDidLayoutSubviews];
    
    // Custom initialization
    MainViewController* mainViewController = [[MainViewController alloc] init];
    [self.navigationController pushViewController:mainViewController animated:false];
    // TODO: note 'animated' has to be false,
    // try change it to true and notice the layout bug (ie. content view will be pushed down on first rendering pass)
}

@end
