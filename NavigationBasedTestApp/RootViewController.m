//
//  RootViewController.m
//  TestNavigationApp
//
//  Created by Zinc on 04/01/2014.
//  Copyright (c) 2014 Ilter Cengiz. All rights reserved.
//

#import "RootViewController.h"
#import "SplashViewController.h"

@interface RootViewController ()

@end

@implementation RootViewController

- (id)init
{
    self = [super initWithNibName:@"RootViewController" bundle:nil];
    if (self) {
        // Custom initialization
        SplashViewController* splashViewController = [[SplashViewController alloc] init];
        [self pushViewController:splashViewController animated:false];
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

@end
