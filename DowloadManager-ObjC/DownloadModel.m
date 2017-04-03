
#import "DownloadModel.h"

@implementation DownloadModel

- (void)openOutputStream {
    
    if (_outputStream) {
        [_outputStream open];
    }
}

- (void)closeOutputStream {
    
    if (_outputStream) {
        [_outputStream close];
        _outputStream = nil;
    }
}

@end
